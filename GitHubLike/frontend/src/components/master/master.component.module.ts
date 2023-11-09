import { NgModule } from '@angular/core';
import { NbButtonModule } from '@nebular/theme';
import { MasterComponent } from './master.component';

@NgModule({
  declarations: [MasterComponent],
  imports: [NbButtonModule],
  exports: [MasterComponent],
})
export class MasterComponentModule {}
