import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
registerMode = false;
values: any;

  constructor(private http: HttpClient, private route: Router, private auth: AuthService) { }

  ngOnInit() {
    this.validateSigned();

  }

  toogleRegister() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

  validateSigned() {
    if  (this.auth.loggedIn()) {
      this.route.navigate(['/members']);
    }
  }
}
