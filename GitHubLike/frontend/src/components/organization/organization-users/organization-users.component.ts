import { Component, Input, OnInit } from '@angular/core';
import { RxState } from '@rx-angular/state';
import { DeleteOrganizationUserDto } from 'src/models/organizations/DeleteOrganizationUserDto';
import { OrganizationDetailsViewDto } from 'src/models/organizations/OrganizationDetailViewDto';
import {
  Admin,
  Member,
  Owner,
} from 'src/models/organizations/OrganizationRolesConstants';
import { OrganizationUserUpdateDto } from 'src/models/organizations/OrganizationUserPatchDto';
import { OrganizationDetailsApiService } from './organization-users.api.service';

interface State {
  organizationUsers: OrganizationDetailsViewDto;
}

@Component({
  selector: 'app-organization-users',
  templateUrl: './organization-users.component.html',
  styleUrls: ['./organization-users.component.scss'],
  providers: [RxState, OrganizationDetailsApiService],
})
export class OrganizationUsersComponent implements OnInit {
  state$ = this.state.select('organizationUsers');
  @Input() organizationId!: number;

  ownerRole = Owner;
  adminRole = Admin;
  memberRole = Member;

  constructor(
    private state: RxState<State>,
    private organizationDetailsApi: OrganizationDetailsApiService,
  ) {}

  ngOnInit(): void {
    this.state.connect(
      'organizationUsers',
      this.organizationDetailsApi.getOrganizationDetails(
        this.organizationId,
        1,
      ),
      (_, data) => {
        return data;
      },
    );
  }

  patchOrganizationUser(userId: number, roleName: string) {
    const patchUserDto: OrganizationUserUpdateDto = {
      userId,
      roleName,
      organizationId: this.organizationId,
    };

    this.state.hold(
      this.organizationDetailsApi.patchOrganizationUser(patchUserDto),
      (resp) => {
        if (resp) {
          const organizationUsers = { ...this.state.get('organizationUsers') };
          organizationUsers.organizationUsersList = resp.organizationUsersList;
          this.state.set({ organizationUsers: organizationUsers });
        }
      },
    );
  }

  removeUser(userId: number) {
    const removeUserDto: DeleteOrganizationUserDto = {
      organizationId: this.organizationId,
      userId,
    };

    this.state.hold(
      this.organizationDetailsApi.removeOrganizationUser(removeUserDto),
      (resp) => {
        if (resp) {
          const organizationUsers = { ...this.state.get('organizationUsers') };
          organizationUsers.organizationUsersList = resp.organizationUsersList;
          this.state.set({ organizationUsers: organizationUsers });
        }
      },
    );
  }
}
