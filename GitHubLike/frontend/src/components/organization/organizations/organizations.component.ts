import { Component } from '@angular/core';
import { RxState } from '@rx-angular/state';
import { SharedOrganizationsViewDto } from 'src/models/organizations/SharedOrganizationsViewDto';
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
    this.state.connect(
      'organizations',
      this.organizationsApiService.getOrganizations(1),
      (_, organizations) => {
        return organizations;
      },
    );
  }
}
