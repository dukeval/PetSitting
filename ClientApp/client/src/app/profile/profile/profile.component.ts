import { Component, Input, OnInit } from '@angular/core';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  @Input() profileInfo: any
  @Input() source: string
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor() { }

  ngOnInit(): void {
    this.galleryOptions=[
    {
      width: "300px",
      height:"300px",
      imagePercent:100,
      thumbnailsColumns:4,
      imageAnimation: NgxGalleryAnimation.Slide,
      preview:false
    }
  ];
  }

  ngAfterViewInit(){
    this.galleryImages = this.getImages();
  }

  getImages():NgxGalleryImage[]{
    const imageUrl =[];
    for(const pet of this.profileInfo.pets){
      for(const petPhoto of pet?.photos){
        imageUrl.push({
          small:petPhoto?.url,
          medium:petPhoto?.url,
          big: petPhoto?.url
        });
      }
    }
    console.log(imageUrl);
    
    return imageUrl;
  }

}
