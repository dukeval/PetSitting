import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { NavMenuComponent } from './nav-menu/nav-menu/nav-menu.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home/home.component';
import { SittersComponent } from './sitters/sitters/sitters.component';
import { RegisterComponent } from './register/register/register.component';
import { RegisterinfoComponent } from './register/registerinfo/registerinfo.component';
import { MembercardComponent } from './users/membercard/membercard.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    UserListComponent,
    NavMenuComponent,
    HomeComponent,
    SittersComponent,
    RegisterComponent,
    RegisterinfoComponent,
    MembercardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot(),
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi:true
  },{
    provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
