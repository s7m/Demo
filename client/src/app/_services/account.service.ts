import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = 'https://localhost:44356/api/';
  //private currentUserSource = new ReplaySubject<User>(1);
  //currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  //ToDo
  login(model: any) {
    return this.http.post(this.baseUrl + 'Account/Login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          //this.currentUserSource.next(user);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('user');
  }
}
