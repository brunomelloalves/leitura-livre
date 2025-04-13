import { Component } from '@angular/core';
import { Service } from '../../services/services';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-livro-cadastro',
  imports: [CommonModule, FormsModule],
  templateUrl: './livro-cadastro.component.html',
  styleUrl: './livro-cadastro.component.scss'
})

  export class LivroCadastroComponent {
    livro = {
      titulo: '',
      autor: '',
      anoPublicacao: new Date().getFullYear(),
      categoria: '',
      disponivel: true,
      capa: null as File | null
      
    };
  
  constructor(private service: Service) {}
  capaPreviewUrl: string | ArrayBuffer | null = null;

  onArquivoSelecionado(event: any) {
    const file = event.target.files?.[0];
    this.livro.capa = file || null;
  
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.capaPreviewUrl = reader.result;
      };
      reader.readAsDataURL(file);
    } else {
      this.capaPreviewUrl = null;
    }
  }

  removerCapa() {
    this.livro.capa = null;
    this.capaPreviewUrl = null;
  }
  
    enviarCadastro() {
      if (!this.livro.titulo || !this.livro.autor || !this.livro.anoPublicacao || !this.livro.categoria) {
        alert('Preencha todos os campos obrigatórios.');
        return;
      }
    
      const formData = new FormData();
      formData.append('titulo', this.livro.titulo);
      formData.append('autor', this.livro.autor);
      formData.append('anoPublicacao', this.livro.anoPublicacao.toString());
      formData.append('categoria', this.livro.categoria);
      formData.append('disponivel', String(this.livro.disponivel));
      if (this.livro.capa) {
        formData.append('capa', this.livro.capa);
      }
    
      this.service.salvarLivro(formData).subscribe({
        next: () => {
          alert('Livro cadastrado com sucesso!');
          this.resetarFormulario();
          this.removerCapa();
        },
        error: (err) => {
          console.error('Erro ao salvar livro:', err);
          alert('Erro ao salvar livro.');
        }
      });
    }

    resetarFormulario() {
      this.livro = {
        titulo: '',
        autor: '',
        anoPublicacao: new Date().getFullYear(),
        categoria: '',
        disponivel: true,
        capa: null
      };
    }
  }
