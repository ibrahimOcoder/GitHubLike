import { Component, Input, OnInit } from '@angular/core';
import { RxState } from '@rx-angular/state';
import {
  OrganizationProjectsUserDetailViewDto,
  OrganizationProjectsViewDto,
} from 'src/models/organizations/OrganizationProjectsViewDto';
import { LoginResponseDto } from 'src/models/user/LoginDto';
import { OrganizationProjectsApiService } from './organization-projects.api.service';

export interface State {
  organizationProjects: OrganizationProjectsViewDto[];
}

@Component({
  selector: 'app-organization-projects',
  templateUrl: './organization-projects.component.html',
  styleUrls: ['./organization-projects.component.scss'],
  providers: [RxState, OrganizationProjectsApiService],
})
export class OrganizationProjectsComponent implements OnInit {
  @Input() organizationId!: number;

  state$ = this.state.select('organizationProjects');

  constructor(
    private state: RxState<State>,
    private organizationProjectsService: OrganizationProjectsApiService,
  ) {}

  ngOnInit(): void {
    const currentUser = JSON.parse(
      localStorage.getItem('currentUser')!,
    ) as LoginResponseDto;

    this.state.connect(
      'organizationProjects',
      this.organizationProjectsService.getOrganizations(
        currentUser.userId,
        this.organizationId,
      ),
      (_, data) => {
        data.forEach((projectUser) => {
          if (projectUser.organizationProjectUsers) {
            projectUser.orgProjectUsers = this.GetUsers(
              projectUser.organizationProjectUsers,
            );
          }
        });

        return data;
      },
    );
  }

  private GetUsers(users: OrganizationProjectsUserDetailViewDto[]): string {
    return users
      .map((u) => {
        return u.userName;
      })
      .join(',');
  }
}
