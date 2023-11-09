import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NbThemeModule } from '@nebular/theme';
import { OrganizationDetailsComponentModule } from 'src/components/organization/organization-details/organization-details.component.module';
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
    NbThemeModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
