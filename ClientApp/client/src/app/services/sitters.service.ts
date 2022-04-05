import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { Sitter } from '../models/Sitter';

@Injectable({
  providedIn: 'root'
})
export class SittersService {
  sitters: Sitter[] = [];

  constructor(private http: HttpClient) { }

  getSitters(){

    if(this.sitters.length>0)
      return of(this.sitters);
 
    return this.http.get<Sitter[]>('https://localhost:5001/api/sitters').pipe(
      map((usrs:Sitter[]) =>{
        this.sitters = usrs;
        return usrs;
      })
    );
  }

  getSitter(sitter: string){
    var savedSittter = this.sitters.find(x=> x.username == sitter);
    if(savedSittter !== undefined)
      return of(savedSittter);

    this.http.get<Sitter>(`https://localhost:5001/api/sitters/${sitter}`);
  }
}
