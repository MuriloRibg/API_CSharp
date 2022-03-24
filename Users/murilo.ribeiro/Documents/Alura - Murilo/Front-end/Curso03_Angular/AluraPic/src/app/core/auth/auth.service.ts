import { UserService } from './../user/user.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';
import { environment } from 'src/environments/environment';

const API = environment.api;

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private userService: UserService
  ) {}

  authenticate(Username: string, Password: string) {
    return this.httpClient
      .post(`${API}/login`, { Username, Password }, { observe: 'response' })
      .pipe(
        tap((res) => {
          const authToken: string =
            'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MSwiZW1haWwiOiJtdXJpbG9zLnJpYmVpcm8yMUBnbWFpbC5jb20iLCJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6Ik11cmlsbyIsImlhdCI6MTUxNjIzOTAyMn0.zeAUV3OACG5rpRPCA5oR5ma1Fg5dRmMDKhKVkrQ2HnY';
          this.userService.setToken(authToken);
        })
      );
  }
}
