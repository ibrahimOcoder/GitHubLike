import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {
  NbButtonModule,
  NbCardModule,
  NbInputModule,
  NbLayoutModule,
  NbSelectModule,
} from '@nebular/theme';
import { NgLetModule } from 'ng-let';
import { ListComponentModule } from '../list/list.component.module';
import { RoleComponent } from './role.component';

@NgModule({
  declarations: [RoleComponent],
  imports: [
    NbInputModule,
    NbCardModule,
    NbSelectModule,
    NbLayoutModule,
    NbButtonModule,
    HttpClientModule,
    ListComponentModule,
    BrowserModule,
    NgLetModule,
  ],
  exports: [RoleComponent],
})
export class RoleComponentModule {}
