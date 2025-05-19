import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAdminSubject = new BehaviorSubject<boolean>(false);
  private isLoggedInSubject = new BehaviorSubject<boolean>(false);

  private apiUrl = environment.apiUrl;

  get isAdmin$() {
    return this.isAdminSubject.asObservable();
  }

  get isLoggedIn$() {
    return this.isLoggedInSubject.asObservable();
  }

  constructor(private http: HttpClient) {
    const isAdmin = localStorage.getItem('isAdmin') === 'true';
    const isLoggedIn = localStorage.getItem('isLoggedIn') === 'true';

    this.isAdminSubject.next(isAdmin);
    this.isLoggedInSubject.next(isLoggedIn);
  }

  login(usuario: string, senha: string): Observable<boolean> {
    return this.http.post<any>(this.apiUrl + '/usuario/login', {
      nomeUsuario: usuario,
      senha: senha
    }).pipe(
      tap((res) => {
        this.isAdminSubject.next(res.isAdmin);
        this.isLoggedInSubject.next(true);

        localStorage.setItem('isAdmin', res.isAdmin.toString());
        localStorage.setItem('isLoggedIn', 'true');
        localStorage.setItem('usuario', res.nomeUsuario);
        localStorage.setItem('id', res.id);
      }),
      catchError(() => {
        return of(false);
      }),
      tap(() => true)
    );
  }

  logout(): void {
    this.isAdminSubject.next(false);
    this.isLoggedInSubject.next(false);
    localStorage.clear();
  }
}
