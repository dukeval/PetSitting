import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { RegisterComponent } from './register/register/register.component';
import { RegisterinfoComponent } from './register/registerinfo/registerinfo.component';
import { SittersComponent } from './sitters/sitters/sitters.component';
import { UserListComponent } from './users/user-list/user-list.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'users', component: UserListComponent},
  {path: 'sitters', component: SittersComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'page2', component: RegisterinfoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
