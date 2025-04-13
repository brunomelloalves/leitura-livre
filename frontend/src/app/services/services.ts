import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuarioDto } from '../Models/usuarioDto';

@Injectable({
  providedIn: 'root'
})
export class Service {
  private apiUrl = 'http://localhost:5049';

  constructor(private http: HttpClient) {}

  salvarUsuario(usuario: UsuarioDto): Observable<UsuarioDto> {
    return this.http.post<UsuarioDto>(this.apiUrl + '/api/usuario', usuario);
  }
  
  obterTodos(): Observable<UsuarioDto[]> {
    return this.http.get<UsuarioDto[]>(this.apiUrl + '/api/usuario');
  }

  atualizarUsuario(id: number, usuario: UsuarioDto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, usuario);
  }
}
