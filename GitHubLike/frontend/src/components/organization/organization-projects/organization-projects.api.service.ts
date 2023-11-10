import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
import { OrganizationProjectsViewDto } from 'src/models/organizations/OrganizationProjectsViewDto';

@Injectable()
export class OrganizationProjectsApiService {
  constructor(private httpClient: HttpClient) {}

  getOrganizations(
    userId: number,
    organizationId: number,
  ): Observable<OrganizationProjectsViewDto[]> {
    const params = new HttpParams()
      .append('userId', userId)
      .append('id', organizationId);
    return this.httpClient.get<OrganizationProjectsViewDto[]>(
      environment.apiUrl + 'organizationUser/GetOrganizationProjects',
      {
        params: params,
        headers: { 'Access-Control-Allow-Origin': '*' },
      },
    );
  }
}
