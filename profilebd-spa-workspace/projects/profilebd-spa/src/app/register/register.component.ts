import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RequestUser } from '../_models/request.user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  model = {} as RequestUser;
  @Output() cancelRegister = new EventEmitter();
  constructor(public acountService: AccountService,
              private _toaster: ToastrService) {}

  ngOnInit(): void {}
  register() {
    this.acountService.register(this.model).subscribe({
      next: (_res) => this.cancel(),
      error: (error) => {
        console.log(error);
        if(typeof error.error === 'object') {
          const errorMessages =`${error.error.errors.Username[0]} and ${error.error.errors.Password[0]}`
          this._toaster.error(errorMessages);
        } else {
          this._toaster.error( error.error);
        }
      
      },
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
