import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home/home.component';
import { RegisterComponent } from './register/register/register.component';
import { RegisterinfoComponent } from './register/registerinfo/registerinfo.component';
import { SitterprofileComponent } from './sitters/sitterprofile/sitterprofile.component';
import { SittersComponent } from './sitters/sitters/sitters.component';
import { EditprofileComponent } from './editprofile/editprofile/editprofile.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { UserprofileComponent } from './users/userprofile/userprofile.component';
import { PetservicesComponent } from './petServices/petservices/petservices.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: '', 
  runGuardsAndResolvers:'always', 
  canActivate:[AuthGuard], 
  children:[
    {path: 'users', component: UserListComponent, canActivate: [AuthGuard]},
    {path: 'users/:id', component: UserprofileComponent},
    {path: 'sitters', component: SittersComponent},
    {path: 'sitters/:id', component: SitterprofileComponent},
    {path: 'edit', component: EditprofileComponent},
    {path: 'services', component: PetservicesComponent}
  ]},
  
  {path: 'register', component: RegisterComponent},
  {path: 'page2', component: RegisterinfoComponent},
  {path: 'not-found',component:HomeComponent},
  {path: '**', component: HomeComponent,pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
