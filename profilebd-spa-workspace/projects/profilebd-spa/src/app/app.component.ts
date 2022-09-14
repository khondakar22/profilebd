import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'profilebd-spa';
  users: any;
  constructor(private _http: HttpClient) {}
  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    this._http.get('https://localhost:5001/api/user').subscribe(
      {
        next: response => this.users = response,
        error: err => console.log(err)
      }
    );
  }
}
