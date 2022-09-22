import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RequestUser } from '../_models/request.user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model = {} as RequestUser;
  constructor(public acountService: AccountService,
              private _router: Router,
              private _toaster: ToastrService) {}

  ngOnInit(): void {}

  login() {
    this.acountService.login(this.model).subscribe({
      next: (_response) => {
        this._router.navigateByUrl('/members');
      }
    });
    console.log(this.model);
  }
  logout() {
    this.acountService.logout();
    this._router.navigateByUrl('/');
  }
}
