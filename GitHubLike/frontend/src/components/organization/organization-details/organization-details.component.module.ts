import { NgModule } from '@angular/core';
import { NbTabsetModule } from '@nebular/theme';
import { MasterComponentModule } from 'src/components/master/master.component.module';

import { OrganizationProjectsComponentModule } from '../organization-projects/organization-projects.component.module';
import { OrganizationUsersComponentModule } from '../organization-users/organization-users.component.module';
import { OrganizationDetailsComponent } from './organization-details.component';

@NgModule({
  imports: [
    NbTabsetModule,
    OrganizationUsersComponentModule,
    MasterComponentModule,
    OrganizationProjectsComponentModule,
  ],
  declarations: [OrganizationDetailsComponent],
  exports: [OrganizationDetailsComponent],
})
export class OrganizationDetailsComponentModule {}
