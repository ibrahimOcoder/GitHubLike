import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgLetModule } from 'ng-let';
import { ListComponentModule } from 'src/components/list/list.component.module';
import { DetailGuard } from '../detail-guard';
import { OrganizationDetailsComponent } from '../organization-details/organization-details.component';
import { OrganizationsComponent } from './organizations.component';

@NgModule({
  declarations: [OrganizationsComponent],
  imports: [
    ListComponentModule,
    BrowserModule,
    NgLetModule,
    RouterModule.forChild([
      {
        path: 'orgDetail/:id',
        canActivate: [DetailGuard],
        component: OrganizationDetailsComponent,
      },
    ]),
  ],
  exports: [OrganizationsComponent],
})
export class OrganizationComponentModule {}
