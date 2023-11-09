import { NgModule } from '@angular/core';
import { NbDialogService, NbTabsetModule } from '@nebular/theme';
import { OrganizationComponentModule } from '../organization/organizations/organizations.component.module';
import { MyProjectsComponentModule } from '../project/my-projects/my-projects.component.module';
import { SharedProjectsComponentModule } from '../project/shared-projects/shared-projects.moodule';
import { RoleComponentModule } from '../role/role.component.module';
import { UserComponent } from './user.component';

@NgModule({
  declarations: [UserComponent],
  imports: [
    NbTabsetModule,
    RoleComponentModule,
    MyProjectsComponentModule,
    SharedProjectsComponentModule,
    OrganizationComponentModule,
  ],
  exports: [UserComponent],
  providers: [NbDialogService],
})
export class UserComponentModule {}
