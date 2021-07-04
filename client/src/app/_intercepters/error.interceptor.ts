import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import {
  HttpClient,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { catchError } from 'rxjs/operators';
@Injectable()

export class ErrorInterceptor implements HttpInterceptor {
  constructor(private http: HttpClient) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error) => {
        if (error) {
          if (error.status == 400) {
            if (error.error.errors) {
              throw error.error;
            } else {
              //this.toastr.error(error.error.message,error.error.statusCode);
            }
          }
        }
        return throwError(error);
      })
    );
  }
}
