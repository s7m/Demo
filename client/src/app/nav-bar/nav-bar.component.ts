import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  //ToDo:
  model: any = {};
  loggedIn: boolean;
  constructor(private accountService: AccountService) {}

  ngOnInit(): void {}

  login() {
    this.accountService.login(this.model).subscribe(
      (response) => {
        console.log(response);
        this.loggedIn = true;
        //this.model=response
      },
      (error) => {
        console.error();
      }
    );
  }

  logout() {
    this.accountService.logout();
    this.loggedIn = false;
  }
}
