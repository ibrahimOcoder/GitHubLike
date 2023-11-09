import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
import { DeleteOrganizationUserDto } from 'src/models/organizations/DeleteOrganizationUserDto';
import { OrganizationDetailsViewDto } from 'src/models/organizations/OrganizationDetailViewDto';

@Injectable()
export class OrganizationDetailsApiService {
  constructor(private httpClient: HttpClient) {}

  getOrganizationDetails(
    OrganizationId: number,
    userId: number,
  ): Observable<OrganizationDetailsViewDto> {
    const params = new HttpParams()
      .append('id', OrganizationId)
      .append('userId', userId);

    return this.httpClient.get<OrganizationDetailsViewDto>(
      environment.apiUrl + 'organization',
      {
        params: params,
        headers: { 'Access-Control-Allow-Origin': '*' },
      },
    );
  }

  removeOrganizationUser(
    removeUserDto: DeleteOrganizationUserDto,
  ): Observable<OrganizationDetailsViewDto> {
    return this.httpClient.delete<OrganizationDetailsViewDto>(
      environment.apiUrl + 'organizationUser',
      {
        headers: { 'Access-Control-Allow-Origin': '*' },
        body: removeUserDto,
      },
    );
  }
}
