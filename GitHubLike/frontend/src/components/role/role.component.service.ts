import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
import { RoleViewDto } from 'src/models/role/RoleViewDto';

@Injectable()
export class RoleComponentService {
  constructor(private httpClient: HttpClient) {}

  getRoles(userId: number): Observable<RoleViewDto[]> {
    const params = new HttpParams().append('id', userId);
    return this.httpClient.get<RoleViewDto[]>(
      environment.apiUrl + 'role/GetRolesByUserId',
      {
        params: params,
        headers: { 'Access-Control-Allow-Origin': '*' },
      },
    );
  }
}
