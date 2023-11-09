import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NbButtonModule, NbCardModule, NbLayoutModule } from '@nebular/theme';
import { NgLetModule } from 'ng-let';
import { ListComponentModule } from 'src/components/list/list.component.module';
import { ProjectDetailsComponent } from './project-details.component';

@NgModule({
  imports: [
    ListComponentModule,
    NbLayoutModule,
    NbCardModule,
    BrowserModule,
    NgLetModule,
    NbButtonModule,
  ],
  declarations: [ProjectDetailsComponent],
  exports: [ProjectDetailsComponent],
})
export class ProjectDetailsComponentModule {}
