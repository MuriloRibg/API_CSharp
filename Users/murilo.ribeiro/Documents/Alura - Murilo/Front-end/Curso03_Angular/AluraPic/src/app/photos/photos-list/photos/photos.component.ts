import { Photo } from './../../photo/photo';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-photos',
  templateUrl: './photos.component.html',
  styleUrls: ['./photos.component.scss'],
})
export class PhotosComponent implements OnChanges {
  @Input() public photos: Photo[] = [];
  rows: any = [];

  constructor() {}

  ngOnChanges(changes: SimpleChanges): void {
    this.rows = this.groupColumns(this.photos);
  }

  public groupColumns(photos: Photo[]) {
    const newRows = [];

    for (let i = 0; i < photos.length; i += 3) {
      //fatiando o array, o primeiro e o inicio, o segundo é o final (não incluso)
      newRows.push(photos.slice(i, i + 3));
    }
    return newRows;
  }
}
