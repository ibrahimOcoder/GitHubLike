import {
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler) {
    let currentUser = JSON.parse(localStorage.getItem('currentUser')!);
    if (currentUser && currentUser.token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentUser.token}`,
          //'Access-Control-Allow-Origin' : '*'
        },
      });
    }

    return next.handle(request);
  }
}
