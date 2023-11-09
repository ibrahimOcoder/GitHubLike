import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RxState } from '@rx-angular/state';
import { LoginDto } from 'src/models/user/LoginDto';
import { AuthenticationService } from '../auth/authentication-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [AuthenticationService, RxState],
})
export class LoginComponent implements OnInit {
  returnUrl!: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private state: RxState<never>,
  ) {}

  ngOnInit() {
    this.authenticationService.logout();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  login(userId: string, password: string) {
    const loginDto: LoginDto = {
      userId,
      password,
    };

    this.state.hold(this.authenticationService.login(loginDto), (resp) => {
      if (resp) {
        localStorage.setItem('currentUser', JSON.stringify(resp));
        this.router.navigate(['user']);
      }
    });
  }
}
