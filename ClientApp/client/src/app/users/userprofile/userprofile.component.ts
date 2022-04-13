import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { User } from 'src/app/models/User';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css']
})
export class UserprofileComponent implements OnInit {
  user: User;
  source: "user";
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private userService: UsersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadUser();

    this.galleryOptions=[
      {
        width: "200px",
        height:"200px",
        
      }
    ]
  }

  loadUser(){
    this.userService.getUser(this.route.snapshot.paramMap.get('id')).subscribe(usr=>{
      this.user = usr;
    })
  }
}
