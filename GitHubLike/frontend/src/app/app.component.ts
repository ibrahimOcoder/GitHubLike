import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'GitHub';
  constructor(private router: Router) {
    if (localStorage.getItem('currentUser')) {
      this.router.navigate(['user']);
    } else {
      this.router.navigate(['login']);
    }
  }
}
