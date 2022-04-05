import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Sitter } from 'src/app/models/Sitter';
import { SittersService } from 'src/app/services/sitters.service';

@Component({
  selector: 'app-sitterprofile',
  templateUrl: './sitterprofile.component.html',
  styleUrls: ['./sitterprofile.component.css']
})
export class SitterprofileComponent implements OnInit {
  sitter: Sitter;

  constructor(private sitterService: SittersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadSitter();
  }

  loadSitter(){
    this.sitterService.getSitter(this.route.snapshot.paramMap.get('id')).subscribe(sitr=>{
      this.sitter = sitr;
    });
  }

}
