import {
  HttpClient,
  HttpHeaders,
  JsonpClientBackend,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Company } from '../models/company';

//ToDo:
const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
  }),
};

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getCompanies() {
    var url = this.baseUrl + 'Company';
    console.log(url);
    return this.http.get<Company[]>(url, httpOptions);
  }

  searchById(id) {
    var url = this.baseUrl + 'Company/id/' + id;
    console.log(url);
    return this.http.get<Company>(url, httpOptions);
  }

  searchByISIN(id) {
    console.log(httpOptions);
    var url = this.baseUrl + 'Company/isin/' + id;
    console.log(url);
    return this.http.get<Company>(url, httpOptions);
  }
}
