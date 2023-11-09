import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgLetModule } from 'ng-let';
import { ListComponentModule } from 'src/components/list/list.component.module';
import { DetailGuard } from 'src/components/project/detail-guard';
import { ProjectDetailsComponent } from '../project-details/project-details.component';
import { MyProjectsComponent } from './my-projects.component';

@NgModule({
  declarations: [MyProjectsComponent],
  imports: [
    ListComponentModule,
    BrowserModule,
    NgLetModule,
    RouterModule.forChild([
      {
        path: 'detail/:id',
        canActivate: [DetailGuard],
        component: ProjectDetailsComponent,
      },
    ]),
  ],
  exports: [MyProjectsComponent],
})
export class MyProjectsComponentModule {}
