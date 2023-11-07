import { NgModule } from '@angular/core';
import { NbButtonModule, NbCardModule, NbInputModule, NbLayoutModule, NbSelectModule } from '@nebular/theme';
import { RoleComponent } from './role.component';

@NgModule({
  declarations: [
    RoleComponent,
  ],
  imports: [
    NbInputModule,
    NbCardModule,
    NbSelectModule,
    NbLayoutModule,
    NbButtonModule
  ],
  exports:[
    RoleComponent
  ]
})
export class RoleComponentModule { }
