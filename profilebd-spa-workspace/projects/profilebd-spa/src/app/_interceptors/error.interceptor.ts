import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private toaster: ToastrService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error) => {
        if (error) {
          switch (error.status) {
            case 400:
              if (error.error.errors) {
                const modalStatErrors = [];
                for (const key in error.error.errors) {
                  if (error.error.errors[key]) {
                    modalStatErrors.push(error.error.errors[key]);
                  }
                }
                throw modalStatErrors.flat();
              } else {
                this.toaster.error(error.error.title, error.status);
              }
              break;
            case 401:
              this.toaster.error('Not Authorized', error.status);
              break;
            case 404:
              this.toaster.error(error.error.title, error.status);
              this.router.navigateByUrl('/not-found');
              break;
            case 500:
              const navigationExtras: NavigationExtras = {state: { error: error.error }};
              this.router.navigateByUrl('/server-error', navigationExtras);
              break;
            default:
              this.toaster.error('Something unexpected went wrong');
              break;
          }
        }
        return throwError(error);
      })
    );
  }
}
