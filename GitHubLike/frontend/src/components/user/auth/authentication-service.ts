import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
import { LoginDto, LoginResponseDto } from 'src/models/user/LoginDto';

@Injectable()
export class AuthenticationService {
  constructor(private httpClient: HttpClient) {}

  login(loginDto: LoginDto): Observable<LoginResponseDto> {
    return this.httpClient.post<LoginResponseDto>(
      environment.apiUrl + 'user',
      loginDto,
      {
        headers: {
          'Access-Control-Allow-Origin': '*',
        },
      },
    );
  }

  logout() {
    localStorage.removeItem('currentUser');
  }
}
