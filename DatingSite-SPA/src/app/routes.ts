import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListComponent } from './list/list.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemeberDetailComponent } from './members/memeber-detail/memeber-detail.component';
import { UserDetailResolver } from './_resolver/member-detail.resolver';

export const appRoutes: Routes = [
    {  path: '', component: HomeComponent },
    {
        path: '',
        canActivate: [ AuthGuard ],
        runGuardsAndResolvers: 'always',
        children: [
            {  path: 'members', component: MemberListComponent},
            {  path: 'messages', component: MessagesComponent },
            {  path: 'members/:id', component: MemeberDetailComponent, resolve: { user: UserDetailResolver }},
            {  path: 'list', component: ListComponent  }
        ]
    },
    {  path: '**', redirectTo: '' , pathMatch: 'full'}
];
