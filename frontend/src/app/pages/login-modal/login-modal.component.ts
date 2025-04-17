import { AfterViewInit, Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.component.html',
  styleUrls: ['./login-modal.component.scss'],
  standalone: true,
  imports: [CommonModule, FormsModule],
})
export class LoginModalComponent implements AfterViewInit {
  usuario = '';
  senha = '';
  erro = false;
  private modalInstance?: Modal;

  constructor(private auth: AuthService) {}

  ngAfterViewInit(): void {
    const el = document.getElementById('loginModal');
    if (el) {
      this.modalInstance = new Modal(el);
    }
  }

  abrirModal() {
    this.modalInstance?.show();
  }

  login() {
    const sucesso = this.auth.login(this.usuario, this.senha);
    this.erro = !sucesso;

    if (sucesso) {
      this.modalInstance?.hide();
    }
  }
}

