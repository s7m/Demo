import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from '../models/company';
import { AccountService } from '../_services/account.service';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  companies: Company[];
  company: Company;
  isin: string;
  id: string;
  isLoggedIn: boolean;

  constructor(private companyService: CompanyService,
    private router: Router,
    public accountService: AccountService) {}

  ngOnInit(): void {
    //this.isLoggedIn=this.accountService.isloggedIn();
    console.log(this.isLoggedIn);
    this.getCompanies();
  }
  getCompanyById(id) {
    this.companies = [];

    this.companyService.searchById(id).subscribe(
      (resp) => {
        this.companies[0] = resp;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getCompanyByISIN(isin) {
    console.log(isin);
    this.companies = [];
    this.companyService.searchByISIN(isin).subscribe(
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

  navigateToCompany() {
    this.router.navigateByUrl('/company');
  }
}
