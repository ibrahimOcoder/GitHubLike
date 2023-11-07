import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
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
}
