import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NbButtonModule, NbThemeModule } from '@nebular/theme';
import { OrganizationDetailsComponentModule } from 'src/components/organization/organization-details/organization-details.component.module';
import { AuthenticationService } from 'src/components/user/auth/authentication-service';
import { JwtInterceptor } from 'src/components/user/auth/jwt-interceptor';
import { LoginComponentModule } from 'src/components/user/login/login.component.module';
import { UserComponentModule } from 'src/components/user/user.component.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UserComponentModule,
    OrganizationDetailsComponentModule,
    LoginComponentModule,
    NbButtonModule,
    NbThemeModule.forRoot(),
  ],
  providers: [
    AuthenticationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
