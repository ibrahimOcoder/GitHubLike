import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
import { ProjectUserUpdateDto } from 'src/models/projects/sharedprojects/SharedProjectsPatchDto';
import { SharedProjectsViewDto } from 'src/models/projects/sharedprojects/SharedProjectsViewDto';

@Injectable()
export class SharedProjectsApiService {
  constructor(private httpClient: HttpClient) {}

  getSharedProjects(userId: number): Observable<SharedProjectsViewDto[]> {
    const params = new HttpParams().append('id', userId);
    return this.httpClient.get<SharedProjectsViewDto[]>(
      environment.apiUrl + 'projects/GetSharedProjectsByUserId',
      {
        params: params,
        headers: { 'Access-Control-Allow-Origin': '*' },
      },
    );
  }

  rejectInvitation(
    rejectInvitationDto: ProjectUserUpdateDto,
  ): Observable<SharedProjectsViewDto[]> {
    return this.httpClient.patch<SharedProjectsViewDto[]>(
      environment.apiUrl + 'projectUsers',
      rejectInvitationDto,
      {
        headers: { 'Access-Control-Allow-Origin': '*' },
      },
    );
  }
}
