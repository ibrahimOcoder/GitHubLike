import { NgModule } from '@angular/core';
import { NbTabsetModule } from '@nebular/theme';
import { RoleComponentModule } from '../role/role.component.module';
import { UserComponent } from './user.component';

@NgModule({
  declarations: [
    UserComponent,
  ],
  imports: [
    NbTabsetModule,
    RoleComponentModule
  ],
  exports:[
    UserComponent
  ]
})
export class UserComponentModule { }
