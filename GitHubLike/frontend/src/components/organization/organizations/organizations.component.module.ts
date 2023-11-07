import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgLetModule } from 'ng-let';
import { ListComponentModule } from 'src/components/list/list.component.module';
import { OrganizationsComponent } from './organizations.component';

@NgModule({
  declarations: [OrganizationsComponent],
  imports: [ListComponentModule, BrowserModule, NgLetModule],
  exports: [OrganizationsComponent],
})
export class OrganizationComponentModule {}
