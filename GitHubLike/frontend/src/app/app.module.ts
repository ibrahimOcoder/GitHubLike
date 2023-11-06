import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { OrganizationDetailsComponent } from 'src/components/organization/organization-details/organization-details.component';
import { OrganizationProjectsComponent } from 'src/components/organization/organization-projects/organization-projects.component';
import { MyProjectsComponent } from 'src/components/project/my-projects/my-projects.component';
import { ProjectDetailsComponent } from 'src/components/project/project-details/project-details.component';
import { SharedProjectsComponent } from 'src/components/project/shared-projects/shared-projects.component';
import { ListComponent } from '../components/list/list.component';
import { OrganizationsComponent } from '../components/organization/organizations/organizations.component';
import { RoleComponent } from '../components/role/role.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    OrganizationProjectsComponent,
    OrganizationsComponent,
    RoleComponent,
    ProjectDetailsComponent,
    MyProjectsComponent,
    SharedProjectsComponent,
    OrganizationProjectsComponent,
    OrganizationDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
