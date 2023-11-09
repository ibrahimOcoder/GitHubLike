import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.scss'],
})
export class MasterComponent {
  constructor(private router: Router) {}
  logout() {
    this.router.navigate(['login']);
  }

  gotToHome() {
    this.router.navigate(['user']);
  }
}
