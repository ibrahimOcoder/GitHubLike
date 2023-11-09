import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectDetailsComponentModule } from 'src/components/project/project-details/project-details.component.module';
import { UserComponent } from 'src/components/user/user.component';

const routes: Routes = [{ path: 'user', component: UserComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes), ProjectDetailsComponentModule],
  exports: [RouterModule],
})
export class AppRoutingModule {}
