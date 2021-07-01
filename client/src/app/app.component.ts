import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

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
    this.http.get('https://localhost:5001/api/Company').subscribe(
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
function GetCompanies() {
  //Any deviation should

}


