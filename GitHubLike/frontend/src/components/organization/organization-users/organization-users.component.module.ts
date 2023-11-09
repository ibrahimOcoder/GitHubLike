import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NbButtonModule, NbCardModule, NbLayoutModule } from '@nebular/theme';
import { NgLetModule } from 'ng-let';
import { ListComponentModule } from 'src/components/list/list.component.module';
import { OrganizationUsersComponent } from '../organization-users/organization-users.component';

@NgModule({
  imports: [
    ListComponentModule,
    NbLayoutModule,
    NbCardModule,
    BrowserModule,
    NgLetModule,
    NbLayoutModule,
    NbCardModule,
    NbButtonModule,
  ],
  declarations: [OrganizationUsersComponent],
  exports: [OrganizationUsersComponent],
})
export class OrganizationUsersComponentModule {}
