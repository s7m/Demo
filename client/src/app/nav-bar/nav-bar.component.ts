import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  //ToDo:
  model: any = {};

  constructor(public accountService: AccountService,
    private toastrService:ToastrService) {}

  ngOnInit(): void {

  }

  login() {
    this.accountService.login(this.model).subscribe(
      (response) => {
        this.toastrService.success("Logged In")
      },
      (error) => {
        this.toastrService.error("Error")
      }
    );
  }

  logout() {
    this.accountService.logout();
    this.toastrService.error("Logged Out")
  }
}
