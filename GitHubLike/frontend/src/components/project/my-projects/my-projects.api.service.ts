import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
import { MyProjectsViewDto } from 'src/models/projects/myprojects/MyProjectsViewDto';

@Injectable()
export class MyProjectsApiService {
  constructor(private httpClient: HttpClient) {}

  getMyProjects(userId: number): Observable<MyProjectsViewDto[]> {
    const params = new HttpParams().append('id', userId);
    return this.httpClient.get<MyProjectsViewDto[]>(
      environment.apiUrl + 'projects/GetProjectsByUserId',
      {
        params: params,
        headers: { 'Access-Control-Allow-Origin': '*' },
      },
    );
  }
}
