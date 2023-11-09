import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectDetailsComponentModule } from 'src/components/project/project-details/project-details.component.module';
import { AuthGuard } from 'src/components/user/auth/auth-guard';
import { LoginComponent } from 'src/components/user/login/login.component';
import { UserComponent } from 'src/components/user/user.component';

const routes: Routes = [
  { path: 'user', component: UserComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ProjectDetailsComponentModule],
  exports: [RouterModule],
  providers: [AuthGuard],
})
export class AppRoutingModule {}
