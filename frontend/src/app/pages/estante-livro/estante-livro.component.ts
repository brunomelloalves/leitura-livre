import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Service } from '../../services/services';
import { CommonModule } from '@angular/common';
import { ViewChild, ElementRef } from '@angular/core';


interface Livro {
  id: number;
  titulo: string;
  autor: string;
  anoPublicacao: number;
  categoria: string;
  capaBase64?: string;
  disponivel: boolean;
}

@Component({
  selector: 'app-estante-livro',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './estante-livro.component.html',
  styleUrls: ['./estante-livro.component.scss']
})

export class EstanteLivroComponent {
  livros: Livro[] = [];
  carregando: boolean = false;
  livroSelecionado: Livro | null = null;

  constructor(private http: HttpClient, private service: Service) { }

  @ViewChild('closeBtn') closeBtn!: ElementRef<HTMLButtonElement>;

  ngOnInit(): void {
    this.carregarLivros();
  }

  abrirModal(livro: Livro): void {
    this.livroSelecionado = livro;
  }

  carregarLivros(): void {
    this.service.obterTodosLivros().subscribe({
      next: (res) => {
        this.livros = res;
        this.carregando = false;
      },
      error: (err) => {
        console.error('Erro ao carregar livros:', err);
        this.carregando = false;
      }
    });
  }

  confirmarEmprestimo(): void {
    if (!this.livroSelecionado) return;

    const usuarioId = Number(localStorage.getItem('id'));
    if (!usuarioId) {
      alert('Usuário não identificado.');
      return;
    }

    const agora = new Date();
    const previsao = this.adicionarDias(agora, 7);

    const emprestimoDto = {
      dataEmprestimo: agora.toISOString(),
      dataDevolucaoPrevista: previsao.toISOString(),
      livroId: this.livroSelecionado.id,
      usuarioId: usuarioId
    };

    this.service.registrarEmprestimo(emprestimoDto).subscribe({
      next: () => {
        alert('Empréstimo registrado com sucesso!');
        this.closeBtn.nativeElement.click();
        this.carregarLivros();
      },
      error: (err) => {
        console.error('Erro ao registrar empréstimo:', err);
        alert('Erro ao registrar empréstimo.');
      }
    });
  }

  adicionarDias(data: Date, dias: number): Date {
    const resultado = new Date(data);
    resultado.setDate(resultado.getDate() + dias);
    return resultado;
  }

  getImageType(base64: string): string {
    if (base64.startsWith('/9j/')) return 'jpeg';
    if (base64.startsWith('iVBOR')) return 'png';
    if (base64.startsWith('R0lGOD')) return 'gif';
    return 'jpeg';
  }
}
