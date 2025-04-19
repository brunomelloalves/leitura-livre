import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Service } from '../../services/services';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss'],
  providers: [Service]
})
export class CadastroComponent {
  cliente = {
    nome: '',
    telefone: '',
    email: '',
    numeroImovel: '',
    nomeUsuario:'',
    senha: '',
    senhaConfirma: ''
  };

  constructor(private service: Service) {}

  enviarFormulario() {
    const { nome, telefone, email, numeroImovel, senha, nomeUsuario, senhaConfirma } = this.cliente;
  
    if (!nome || !telefone || !email || !numeroImovel || !senha || !senhaConfirma || !nomeUsuario) {
      alert('Por favor, preencha todos os campos. São obrigatórios.');
      return;
    }
  
    if (senha !== senhaConfirma) {
      alert('As senhas digitadas não são iguais.');
      return;
    }
  
    const usuarioPayload = {
      nome,
      telefone,
      email,
      nrImovel: +numeroImovel,
      nomeUsuario,
      senha,
      aprovado: false
    };
  

    this.service.salvarUsuario(usuarioPayload).subscribe({
      next: () => {
        alert('Cadastro enviado com sucesso!');
        this.limparFormulario();
      },
      error: (error) => {
        console.error('Erro ao salvar usuário:', error);
        alert('Ocorreu um erro ao salvar o cadastro.');
      }
    });
  }

  limparFormulario() {
    this.cliente.nome = ''; 
    this.cliente.telefone = '';
    this.cliente.email = '';
    this.cliente.numeroImovel = '';
    this.cliente.senha = '';
    this.cliente.senhaConfirma = '';
  }

  formatarTelefone(event: any) {
    let valor = event.target.value.replace(/\D/g, '');
  
    if (valor.length === 0) {
      event.target.value = '';
      this.cliente.telefone = '';
      return;
    }
  
    if (valor.length > 11) {
      valor = valor.slice(0, 11);
    }
    let telefoneFormatado = valor;
  
    if (valor.length === 11) {
      telefoneFormatado = valor.replace(/(\d{2})(\d{5})(\d{4})/, '($1) $2-$3');
    } else if (valor.length === 10) {
      telefoneFormatado = valor.replace(/(\d{2})(\d{4})(\d{4})/, '($1) $2-$3');
    } else if (valor.length > 6) {
      telefoneFormatado = valor.replace(/(\d{2})(\d{4})(\d{0,4})/, '($1) $2-$3');
    } else if (valor.length > 2) {
      telefoneFormatado = valor.replace(/(\d{2})(\d{0,4})/, '($1) $2');
    } else {
      telefoneFormatado = valor.replace(/(\d{0,2})/, '($1');
    }
  
    event.target.value = telefoneFormatado;
    this.cliente.telefone = telefoneFormatado;
  }
}
