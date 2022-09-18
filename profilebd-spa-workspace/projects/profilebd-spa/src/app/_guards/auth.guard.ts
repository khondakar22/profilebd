import { Injectable } from '@angular/core';
import {  CanActivate } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private _accountService: AccountService, private _toaster: ToastrService) {
    
  }
  canActivate(): Observable<boolean > {
    return this._accountService.currentUser$.pipe(
      map(user => {
        if(user) return true;
        this._toaster.error('You shall not passed')
        return false;
      })
    )
  }
  
}
