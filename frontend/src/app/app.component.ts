import { Component, ViewChild, AfterViewChecked } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { AuthService } from './services/auth.service';
import { LoginModalComponent } from "./pages/login-modal/login-modal.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule, LoginModalComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewChecked {
  title = 'frontend';
  isAdmin = false;
  private dropdownInitialized = false;

  @ViewChild('loginModal') loginModalComponent!: LoginModalComponent;

  constructor(private auth: AuthService) {
    this.auth.isAdmin$.subscribe(val => {
      this.isAdmin = val;
      this.dropdownInitialized = false;
    });
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
}
