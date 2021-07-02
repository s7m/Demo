import { Component, OnInit } from '@angular/core';
import { Company } from '../models/company';
import { CompanyService } from '../_services/company.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css'],
})
export class CompanyComponent implements OnInit {
  company:any={};
  constructor(private companyService: CompanyService) {}

  ngOnInit(
  ): void {}
  saveCompany() {

    this.companyService.save(this.company).subscribe();
  }
}
