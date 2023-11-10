import { Component } from '@angular/core';
import { RxState } from '@rx-angular/state';
import { SharedOrganizationsViewDto } from 'src/models/organizations/SharedOrganizationsViewDto';
import { LoginResponseDto } from 'src/models/user/LoginDto';
import { OrganizationsApiService } from './organizations.component.api.service';

export interface State {
  organizations: SharedOrganizationsViewDto[];
}

@Component({
  selector: 'app-organizations',
  templateUrl: './organizations.component.html',
  styleUrls: ['./organizations.component.scss'],
  providers: [OrganizationsApiService, RxState],
})
export class OrganizationsComponent {
  state$ = this.state.select('organizations');

  constructor(
    private state: RxState<State>,
    private organizationsApiService: OrganizationsApiService,
  ) {
    const currentUser = JSON.parse(
      localStorage.getItem('currentUser')!,
    ) as LoginResponseDto;
    this.state.connect(
      'organizations',
      this.organizationsApiService.getOrganizations(currentUser.userId),
      (_, organizations) => {
        return organizations;
      },
    );
  }
}
