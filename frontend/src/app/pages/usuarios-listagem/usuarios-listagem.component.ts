import { Component, OnInit } from '@angular/core';
import { UsuarioDto } from '../../Models/usuarioDto';
import { Service } from '../../services/services';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-usuarios-listagem',
  templateUrl: './usuarios-listagem.component.html',
  styleUrl: './usuarios-listagem.component.scss',
  imports: [CommonModule]
})

export class UsuariosListagemComponent implements OnInit {
  usuarios: UsuarioDto[] = [];
  carregando = true;

  constructor(private service: Service) {}

  ngOnInit(): void {
    this.service.obterTodos().subscribe({
      next: (res) => {
        this.usuarios = res;
        this.carregando = false;
      },
      error: (err) => {
        console.error('Erro ao carregar usuários:', err);
        this.carregando = false;
      }
    });
  }

  alternarAprovacao(usuario: UsuarioDto) {
    const novoStatus = !usuario.aprovado;
  
    this.service.atualizarUsuario(usuario.id!, { ...usuario, aprovado: novoStatus }).subscribe({
      next: () => {
        usuario.aprovado = novoStatus;
      },
      error: () => {
        alert('Erro ao atualizar aprovação do usuário.');
      }
    });
  }

}