import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
import { DeleteProjectUserDto } from 'src/models/projects/myprojects/DeleteProjectUserDto';
import { ProjectDetailsViewDto } from 'src/models/projects/myprojects/ProjectDetailsViewDto';

@Injectable()
export class ProjectDetailsApiService {
  constructor(private httpClient: HttpClient) {}

  getProjectDetails(projectId: number): Observable<ProjectDetailsViewDto> {
    const params = new HttpParams().append('id', projectId);
    return this.httpClient.get<ProjectDetailsViewDto>(
      environment.apiUrl + 'projects/GetProjectDetails',
      {
        params: params,
        headers: { 'Access-Control-Allow-Origin': '*' },
      },
    );
  }

  removeProjectUser(
    removeUserDto: DeleteProjectUserDto,
  ): Observable<ProjectDetailsViewDto> {
    return this.httpClient.delete<ProjectDetailsViewDto>(
      environment.apiUrl + 'projectUsers',
      {
        headers: { 'Access-Control-Allow-Origin': '*' },
        body: removeUserDto,
      },
    );
  }
}
