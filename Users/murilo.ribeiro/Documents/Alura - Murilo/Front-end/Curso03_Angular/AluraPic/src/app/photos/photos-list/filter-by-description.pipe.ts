import { Photo } from './../photo/photo';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterByDescription',
})
export class FilterByDescription implements PipeTransform {
  //pegando o array de fotos, e o que o usuário digitou.
  transform(photos: Photo[], descriptionQuery: string) {
    descriptionQuery = descriptionQuery.trim().toLowerCase();

    if (descriptionQuery) {
      return photos.filter((photos) =>
        photos.description.toLowerCase().includes(descriptionQuery)
      );
    } else {
      return photos;
    }
  }
}
