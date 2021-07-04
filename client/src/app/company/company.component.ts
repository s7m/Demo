import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from '../models/company';
import { AccountService } from '../_services/account.service';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css'],
})
export class CompanyComponent implements OnInit {
  company: any = {}; //ToDo
  companyId: string;
  isin = '';
  isloggedIn: boolean;
  validationErrors: any;
  constructor(
    private companyService: CompanyService,
    private activatedRoute: ActivatedRoute,
    private accountService: AccountService
  ) {}

  ngOnInit() {
    //this.isloggedIn=this.accountService.isloggedIn();
    console.log(this.isloggedIn);

    this.getCompanyByQueryParam();
  }

  saveCompany() {
    this.companyService.save(this.company).subscribe(
      (resp) => {
        console.log(resp);
        if (resp == true) {
          window.location.href = '/home';
        }
      },
      (error) => {
        this.validationErrors = error.errors;
        console.log(this.validationErrors);
      }
    );
  }

  getCompanyByQueryParam() {
    this.activatedRoute.queryParams.subscribe((params) => {
      this.companyId = params.id;
    });
    this.companyService.searchById(this.companyId).subscribe(
      (resp) => {
        this.company = resp;
      },
      (error) => {

      }
    );
  }
}
