import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterLink, RouterOutlet } from '@angular/router';
import { NgLetModule } from 'ng-let';
import { ListComponentModule } from 'src/components/list/list.component.module';
import { OrganizationProjectsComponent } from './organization-projects.component';

@NgModule({
  imports: [
    ListComponentModule,
    RouterOutlet,
    RouterLink,
    NgLetModule,
    BrowserModule,
  ],
  declarations: [OrganizationProjectsComponent],
  exports: [OrganizationProjectsComponent],
})
export class OrganizationProjectsComponentModule {}
