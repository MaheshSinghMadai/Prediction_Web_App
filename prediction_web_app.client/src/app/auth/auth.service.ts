import { Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, map } from 'rxjs';
import { User } from './model/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'https://localhost:7076';
  public currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) {
    let user = localStorage.getItem('user');
    if (user) {
      const returnUser: User = JSON.parse(user);
      this.currentUserSource.next(returnUser);
    }
  }

  public getCurrentUserValue() {
    return this.currentUserSource.value;
  }

  login(body: any) {
    return this.http.post<any>(`${this.baseUrl}/Account/Login`, body).pipe(
      map((user: User) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }

  logout() {
    localStorage.clear();
    this.currentUserSource.next(null);
    this.router.navigate(['/']);
  }

  //for interceptor
  getToken() {
    return localStorage.getItem('token');
  }

  private refreshTokenTimeout : any;

  refreshToken() {
    return this.http.post<User>(`${this.baseUrl}/Account/refresh-token`, this.getCurrentUserValue())
      .pipe(map((user: User) => {
        if (user && user.token) {
          localStorage.setItem('expiresAt', user.expiresAt)
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
          this.startRefreshTokenTimer();
        }
        return user;
      }));
  }

  startRefreshTokenTimer() {
    clearTimeout(this.refreshTokenTimeout);

    let expires: Date;
    let currentDate: any;

    if (this.currentUserSource.value?.expiresAt == null) {
      currentDate = localStorage.getItem('expiresAt');
      expires = new Date(currentDate);
    } else {
      expires = new Date(this.currentUserSource.value.expiresAt);
    }
    const timeout = expires.getTime() - Date.now() - (120 * 1000);

    this.refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout);
  }

  private stopRefreshTokenTimer() {
    clearTimeout(this.refreshTokenTimeout);
  }

  sessionExpire() {
    if (localStorage.getItem("token") == null) {
      this.router.navigateByUrl("/");
    }
    // console.log('expired');
  }

}
