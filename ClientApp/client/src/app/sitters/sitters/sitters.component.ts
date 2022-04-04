import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Sitter } from 'src/app/models/Sitter';
import { SittersService } from 'src/app/services/sitters.service';

@Component({
  selector: 'app-sitters',
  templateUrl: './sitters.component.html',
  styleUrls: ['./sitters.component.css']
})
export class SittersComponent implements OnInit {

  sitters$: Observable<Sitter[]>;
  source: string = "Sitter";

  constructor(private sitterService: SittersService) { }

  ngOnInit(): void {
    this.sitters$ = this.sitterService.getSitters();
  }

}
