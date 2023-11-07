import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgLetModule } from 'ng-let';
import { ListComponentModule } from 'src/components/list/list.component.module';
import { SharedProjectsComponent } from './shared-projects.component';

@NgModule({
  declarations: [SharedProjectsComponent],
  imports: [ListComponentModule, BrowserModule, NgLetModule],
  exports: [SharedProjectsComponent],
})
export class SharedProjectsComponentModule {}
