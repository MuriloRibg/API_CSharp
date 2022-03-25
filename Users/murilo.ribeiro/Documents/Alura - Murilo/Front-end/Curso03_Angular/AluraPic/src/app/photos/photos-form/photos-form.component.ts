import { Router } from '@angular/router';
import { PhotoService } from './../photo/photo.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, EventEmitter, OnInit } from '@angular/core';

@Component({
  selector: 'app-photos-form',
  templateUrl: './photos-form.component.html',
  styleUrls: ['./photos-form.component.scss'],
})
export class PhotosFormComponent implements OnInit {
  formPhotos!: FormGroup;
  file!: any;
  preview!: string;

  constructor(
    private formBuilder: FormBuilder,
    private photoService: PhotoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.formPhotos = this.formBuilder.group({
      file: ['', [Validators.required]],
      description: ['', [Validators.maxLength(300)]],
      allowComments: [true],
    });
  }

  upload() {
    const description = this.formPhotos.get(['description'])?.value;
    const allowComments = this.formPhotos.get(['allowComments'])?.value;

    this.photoService
      .upload(description, allowComments, this.file)
      .subscribe(() => {
        this.router.navigate(['']);
      });
  }

  handleFile(event: any){
    this.file = event.target.files[0] ?? null;
    const READER = new FileReader();
    READER.onload = (event: any) => {
      this.preview = event.target.result;
    }
    READER.readAsDataURL(this.file)
  }
}
