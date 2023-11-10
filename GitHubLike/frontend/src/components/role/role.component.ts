import { Component } from '@angular/core';
import { RxState } from '@rx-angular/state';
import { ToPermissionValues } from 'src/models/permissions';
import { RoleViewDto } from 'src/models/role/RoleViewDto';
import { LoginResponseDto } from 'src/models/user/LoginDto';
import { RoleComponentService } from './role.component.service';

export interface State {
  userRoles: RoleViewDto[];
}

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss'],
  providers: [RoleComponentService, RxState],
})
export class RoleComponent {
  state$ = this.state.select('userRoles');
  constructor(
    private roleService: RoleComponentService,
    private state: RxState<State>,
  ) {
    const currentUser = JSON.parse(
      localStorage.getItem('currentUser')!,
    ) as LoginResponseDto;
    this.state.connect(
      'userRoles',
      this.roleService.getRoles(currentUser.userId),
      (_, data) => {
        const userRoles = [...data];
        userRoles.map((userRole) => {
          userRole.permissionsLabels = ToPermissionValues(userRole.permissions);
        });
        return userRoles;
      },
    );
  }
}
