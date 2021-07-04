import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
    private accountService: AccountService,
    private toastrService:ToastrService
  ) {}

  ngOnInit() {
    this.getCompanyByQueryParam();
  }

  saveCompany() {
    this.companyService.save(this.company).subscribe(
      (resp) => {
        if (resp == true) {
          window.location.href = '/home';
          this.toastrService.success("Successfully Saved")
        }
        else{
          this.toastrService.error("Failed, Something went wrong")
        }
      },
      (error) => {
        this.toastrService.error("Error")
        this.validationErrors = error.errors;
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
