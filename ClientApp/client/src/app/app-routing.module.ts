import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { SittersComponent } from './sitters/sitters/sitters.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'sitters', component: SittersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
