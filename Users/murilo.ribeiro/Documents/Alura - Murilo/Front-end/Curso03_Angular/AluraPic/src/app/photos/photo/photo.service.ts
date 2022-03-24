import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Photo } from './photo';

const API = environment.api;

@Injectable({ providedIn: `root` }) //dando acesso a todos os componentes da minha apricação
export class PhotoService {
  constructor(private http: HttpClient) {}

  listFromUser(userName: string) {
    return this.http.get<Photo[]>(API + '/foto');
  }

  listFromUserPaginated(userName: string, page: number) {
    const params = new HttpParams()
        .append('page', page.toString());

    return this.http
        .get<Photo[]>(API + '/' + userName + '/foto', { params });
  }

  upload(description: string, allowComments: boolean, file: File) {

    const formData = new FormData();
    formData.append("description", description);
    formData.append("allowComments", allowComments ? "true" : "false");
    formData.append("imageFile", file);

    return this.http.post(`${API}/photos/upload`, formData);
  }
}
