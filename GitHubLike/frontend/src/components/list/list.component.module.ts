import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NbCardModule, NbLayoutModule } from '@nebular/theme';
import { ListComponent } from './list.component';

@NgModule({
  declarations: [ListComponent],
  imports: [NbCardModule, NbLayoutModule, BrowserModule],
  exports: [ListComponent],
})
export class ListComponentModule {}
