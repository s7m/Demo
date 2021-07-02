import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Company Portal';
  companies: any; //ToDo:
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getCompanies();
    this.setCurrentUser();
  }
  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
  }
  getCompanies() {
    //Any deviation should
    this.http.get('https://localhost:44356/api/Company').subscribe(
      (resposne) => {
        this.companies = resposne;
        console.log(this.companies);
      },
      (error) => {
        console.error(console.log(error));
      }
    );
  }
}
