import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuarioDto } from '../Models/usuarioDto';
import { LivroDto } from '../Models/livroDto';
import { environment } from '../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class Service {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // Usuario

  salvarUsuario(usuario: UsuarioDto): Observable<UsuarioDto> {
    return this.http.post<UsuarioDto>(`${this.apiUrl}/usuario`, usuario);
  }

  obterTodos(): Observable<UsuarioDto[]> {
    return this.http.get<UsuarioDto[]>(`${this.apiUrl}/usuario`);
  }

  atualizarUsuario(id: number, usuario: UsuarioDto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/usuario/${id}`, usuario);
  }

  // Livro

  salvarLivro(formData: FormData): Observable<any> {
    return this.http.post(`${this.apiUrl}/livro`, formData);
  }

  obterTodosLivros(): Observable<LivroDto[]> {
    return this.http.get<LivroDto[]>(`${this.apiUrl}/livro`);
  }

  registrarEmprestimo(dto: any) {
    return this.http.post(`${this.apiUrl}/emprestimo`, dto);
  }
}
