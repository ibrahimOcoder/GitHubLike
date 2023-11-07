import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
import { SharedOrganizationsViewDto } from 'src/models/organizations/SharedOrganizationsViewDto';

@Injectable()
export class OrganizationsApiService {
  constructor(private httpClient: HttpClient) {}

  getOrganizations(userId: number): Observable<SharedOrganizationsViewDto[]> {
    const params = new HttpParams().append('id', userId);
    return this.httpClient.get<SharedOrganizationsViewDto[]>(
      environment.apiUrl + 'organization/GetSharedOrganizationsByUserId',
      {
        params: params,
        headers: { 'Access-Control-Allow-Origin': '*' },
      },
    );
  }
}
