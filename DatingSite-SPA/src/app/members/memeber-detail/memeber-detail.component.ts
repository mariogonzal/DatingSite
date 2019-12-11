import { Component, OnInit, Input } from '@angular/core';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { User } from 'src/app/_models/user';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-memeber-detail',
  templateUrl: './memeber-detail.component.html',
  styleUrls: ['./memeber-detail.component.css']
})
export class MemeberDetailComponent implements OnInit {
  @Input() id: number;
user: User;
  constructor(private userService: UserService, private alertify: AlertifyService,
              private routes: ActivatedRoute) { }

  ngOnInit() {
    this.getUser();
  }

  getUser() {
    this.userService.getUser( this.routes.snapshot.params.id ).subscribe((user: User) => {
      this.user = user;
    }, error => {
      this.alertify.error( 'Error at fetching user' );
        });
  }

}
