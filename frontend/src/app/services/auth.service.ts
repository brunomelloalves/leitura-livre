import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAdminSubject = new BehaviorSubject<boolean>(false);
  private isLoggedInSubject = new BehaviorSubject<boolean>(false);

  private apiUrl = 'http://localhost:5049';

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
    return this.http.post<any>(this.apiUrl + '/api/usuario/login', {
      nomeUsuario: usuario,
      senha: senha
    }).pipe(
      tap((res) => {
        this.isAdminSubject.next(res.isAdmin);
        this.isLoggedInSubject.next(true);

        localStorage.setItem('isAdmin', res.isAdmin.toString());
        localStorage.setItem('isLoggedIn', 'true');
        localStorage.setItem('usuario', res.nomeUsuario);
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
