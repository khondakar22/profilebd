import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {
  model: any = {};
  registerSubscription: Subscription = new Subscription();
  @Output() cancelRegister = new EventEmitter();
  constructor( public  acountService: AccountService) { }
  ngOnDestroy(): void {
    this.registerSubscription.unsubscribe();
  }

  ngOnInit(): void {
  }
  register() {
   this.registerSubscription = this.acountService.register(this.model).subscribe({
      next: (_res) => this.cancel(),
      error: (error) => console.log(error)
      
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
