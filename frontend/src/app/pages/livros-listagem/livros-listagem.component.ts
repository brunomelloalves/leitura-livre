import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Service } from '../../services/services';
import { LivroDto } from '../../Models/livroDto';

@Component({
  selector: 'app-livros-listagem',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './livros-listagem.component.html',
  styleUrls: ['./livros-listagem.component.scss']
})
export class LivrosListagemComponent implements OnInit {
  livros: LivroDto[] = [];
  carregando = true;

  constructor(private service: Service) {}

  ngOnInit(): void {
    this.service.obterTodosLivros().subscribe({
      next: (res) => {
        console.log('res', res),
        this.livros = res;
        this.carregando = false;
      },
      error: (err) => {
        console.error('Erro ao carregar livros:', err);
        this.carregando = false;
      }
    });
  }
  
  getImageType(base64: string | null): string {
    if (!base64) return 'jpeg';
    return base64.startsWith('/9j/') ? 'jpeg' : 'png'; // exemplo simples
  }
  
}
