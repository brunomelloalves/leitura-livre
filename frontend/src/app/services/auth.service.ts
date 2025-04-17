import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAdminSubject = new BehaviorSubject<boolean>(false);

  get isAdmin$() {
    return this.isAdminSubject.asObservable();
  }

  login(usuario: string, senha: string): boolean {
    if (usuario === 'admin' && senha === 'admin') {
      this.isAdminSubject.next(true);
      return true;
    }

    return false;
  }

  logout(): void {
    this.isAdminSubject.next(false);
  }
}
