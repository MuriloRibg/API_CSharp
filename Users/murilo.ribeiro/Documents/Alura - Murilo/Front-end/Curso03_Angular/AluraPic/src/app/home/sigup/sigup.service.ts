import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NewUser } from './new-user';

const API = environment.api;

@Injectable({ providedIn: 'root' })
export class SigUpService {
  constructor(private http: HttpClient) {}

  checkUserNameTaken(userName: string): Observable<string> {
    return this.http.get<string>(`${API}/login`);
  }

  sigup(newUser: NewUser): Observable<string>{
    return this.http.post<string>(`${API}/login`, newUser)
  }
}
