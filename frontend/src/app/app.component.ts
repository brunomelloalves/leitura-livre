import { Component, ViewChild, AfterViewChecked } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { AuthService } from './services/auth.service';
import { LoginModalComponent } from "./pages/login-modal/login-modal.component";
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule, LoginModalComponent, CommonModule],
  templateUrl: './app.component.html'
})
export class AppComponent implements AfterViewChecked {
  title = 'frontend';
  private dropdownInitialized = false;

  @ViewChild('loginModal') loginModalComponent!: LoginModalComponent;
  isAdmin = false;
  isLoggedIn = false;
  
  constructor(private auth: AuthService, private router: Router) {
    this.auth.isAdmin$.subscribe(val => this.isAdmin = val);
    this.auth.isLoggedIn$.subscribe(val => this.isLoggedIn = val);
  }
  

  abrirLoginModal() {
    this.loginModalComponent.abrirModal();
  }

  async ngAfterViewChecked() {
    if (this.isAdmin && !this.dropdownInitialized) {
      const el = document.getElementById('gestaoDropdown');
      if (el) {
        const bootstrap = await import('bootstrap');
        new bootstrap.Dropdown(el);
        this.dropdownInitialized = true;
      }
    }
  }
  deslogar() {
    this.auth.logout();
    this.router.navigate(['/']);
  }
}
