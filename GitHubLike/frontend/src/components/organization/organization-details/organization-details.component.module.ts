import { NgModule } from '@angular/core';
import { NbTabsetModule } from '@nebular/theme';
import { OrganizationUsersComponentModule } from '../organization-users/organization-users.component.module';
import { OrganizationDetailsComponent } from './organization-details.component';

@NgModule({
  imports: [NbTabsetModule, OrganizationUsersComponentModule],
  declarations: [OrganizationDetailsComponent],
  exports: [OrganizationDetailsComponent],
})
export class OrganizationDetailsComponentModule {}
