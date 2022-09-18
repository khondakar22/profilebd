import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  users: any;
  currentUser$: Observable<User> | undefined;
  constructor(private  acountService: AccountService) { }

  ngOnInit(): void {
   this.currentUser$ = this.acountService.currentUser$
  }
  
  login(){
    this.acountService.login(this.model).subscribe(
      {
        next: response => {
          this.users = response
        },
        error: err => console.log(err)
      }
    )
    console.log(this.model);
    
  }
  logout() {
    this.acountService.logout();
  }
}
