import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from '../models/company';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css'],
})
export class CompanyComponent implements OnInit {
  company: any = {}; //ToDo
  companyId: string;
  constructor(
    private companyService: CompanyService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.getCompanyByQueryParam();
  }

  saveCompany() {
    this.companyService.save(this.company).subscribe(
      resp =>{
        console.log(resp);
      }
    );
  }

  getCompanyByQueryParam() {
    this.activatedRoute.queryParams.subscribe((params) => {
      this.companyId = params.id;
    });
    this.companyService.searchById(this.companyId).subscribe(resp =>{
      this.company = resp;
      //console.log(resp);
    },
    error =>{
      console.log(error);
    });
  }
}
