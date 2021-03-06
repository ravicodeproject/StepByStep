import { AuthService } from '../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  model: any = {};

  constructor(
    public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Login successful');
      },
      error => {
        this.alertify.error(error);
      },
      () => {
         this.router.navigate(['/lists']);
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
  loggedOut() {
    localStorage.removeItem('token');
    this.alertify.message('logout successful');
    this.router.navigate(['/']);
  }
}
