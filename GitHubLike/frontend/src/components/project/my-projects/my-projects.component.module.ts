import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgLetModule } from 'ng-let';
import { ListComponentModule } from 'src/components/list/list.component.module';
import { MyProjectsComponent } from './my-projects.component';

@NgModule({
  declarations: [MyProjectsComponent],
  imports: [ListComponentModule, BrowserModule, NgLetModule],
  exports: [MyProjectsComponent],
})
export class MyProjectsComponentModule {}
