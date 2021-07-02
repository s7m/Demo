import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Company } from './models/company';
import { User } from './models/user';
import { CompanyService } from './_services/company.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Company Portal';
  companies: Company[]; //ToDo:
  isin: string;
  id: string;
  constructor(
    private companyService: CompanyService,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.getCompanies();
    this.setCurrentUser();
  }
  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
  }

  getCompanyById(id) {
    this.companies = [];

    this.companyService.searchById(id).subscribe(
      (resp) => {
        this.companies[0] = resp;
        //console.log(this.companies);
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getCompanyByISIN(id) {
    this.companies = [];
    this.companyService.searchByISIN(id).subscribe(
      (resp) => {
        this.companies[0] = resp;
        // console.log(this.companies);
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getCompanies() {
    this.companyService.getCompanies().subscribe(
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
