import { NgModule } from '@angular/core';
import {
  NbButtonModule,
  NbCardModule,
  NbInputModule,
  NbLayoutModule,
} from '@nebular/theme';
import { LoginComponent } from './login.component';

@NgModule({
  declarations: [LoginComponent],
  imports: [NbButtonModule, NbLayoutModule, NbCardModule, NbInputModule],
  exports: [LoginComponent],
})
export class LoginComponentModule {}
