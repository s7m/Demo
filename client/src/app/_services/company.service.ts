import {
  HttpClient,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Company } from '../models/company';
import { TokenService } from './token.service';


@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient,
    private tokenService:TokenService) {}

  getCompanies() {
    var url = this.baseUrl + 'Company';
    //console.log(url);
    return this.http.get<Company[]>(url);
  }

  searchById(id) {
    var httpOptions=this.tokenService.setHttpOptions();
    var url = this.baseUrl + 'Company/id/' + id;
    return this.http.get<Company>(url, httpOptions);
  }

  searchByISIN(id) {
    var httpOptions=this.tokenService.setHttpOptions();
    var url = this.baseUrl + 'Company/isin/' + id;
    return this.http.get<Company>(url, httpOptions);
  }

  save(company: Company) {
    var url = this.baseUrl + 'company';
    var httpOptions=this.tokenService.setHttpOptions();
    return this.http.post(url, company,httpOptions);
  }


}
