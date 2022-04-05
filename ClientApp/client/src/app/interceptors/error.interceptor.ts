import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { NavigationExtras, Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private toastr: ToastrService, private router: Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(err =>{
        if(err){
          switch (err.status) {
            case 400:
              if(err.error.errors)
              {
                const modalStateError =[];
                for(const error in err.error.errors){
                  if(err.error.errors[error]){
                    modalStateError.push(err.error.errors[error]);
                  }
                }
                throw modalStateError.flat();
              }
              else{
                this.toastr.error(err.error, err.statusText);
              }
              break;
            case 401:
              this.toastr.error(err.error,err.statusText);
              break;
            case 404:
              this.router.navigateByUrl('/not-found');
              break;
            case 500:
              const navigationExtras:NavigationExtras = {state: {error: err.error}}
              this.router.navigateByUrl('/server-error',navigationExtras);
              break;
            default:
              this.toastr.error("Something unexpected happened!");
              console.log(err);              
              break;
          }
        }

        return throwError(err);
      })
    );
  }
}
