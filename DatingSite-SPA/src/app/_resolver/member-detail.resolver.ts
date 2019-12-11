import { Injectable } from '@angular/core';
import { User } from '../_models/user';
import { Resolve,  ActivatedRouteSnapshot, Router  } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class UserDetailResolver implements Resolve<User> {

    constructor(private userService: UserService, private alertify: AlertifyService,
                private routeService: Router) {

    }
    resolve(route: ActivatedRouteSnapshot ): Observable<User> {
        return this.userService.getUser(route.params.id).pipe( catchError( error => {
            this.alertify.error('there is a problem loading data user data' );
            this.routeService.navigate(['/members']);
        }));
    }
}