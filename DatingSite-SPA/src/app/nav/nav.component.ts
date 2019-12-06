import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
username: any;

  constructor(private authService: AuthService, private alertifyService: AlertifyService,
              private routeService: Router) { }

  ngOnInit() {
    if ( this.authService.decodedToken ) {
    this.username = this.username = this.authService.decodedToken.nameid[1];
    }
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertifyService.success('logged in successfully');
      console.log('logged in successfully');
      this.username = this.authService.decodedToken.nameid[1];
      this.routeService.navigate(['/members']);
    }, error => {
      this.alertifyService.error(error);
      console.log(error);
    });

    console.log(this.model);
  }

  loggedin() {
   return this.authService.loggedIn();
  }

  logout() {
    this.authService.loggedOut();
    this.alertifyService.message('logged out');
    console.log('logged out');
    this.routeService.navigate(['/home']);
  }

}
