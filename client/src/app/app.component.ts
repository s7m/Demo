import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Company } from './models/company';
import { User } from './models/user';
import { AccountService } from './_services/account.service';
import { CompanyService } from './_services/company.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Company Portal';
  companies: Company[]; //ToDo:

  constructor(
    private companyService: CompanyService,
    private accountService: AccountService,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }
}
