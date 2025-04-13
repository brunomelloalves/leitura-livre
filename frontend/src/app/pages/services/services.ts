import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuarioDto } from '../../Models/usuarioDto';



@Injectable({
  providedIn: 'root'
})
export class Service {
  private apiUrl = 'http://localhost:5049/api/usuario';

  constructor(private http: HttpClient) {}

  salvarUsuario(usuario: UsuarioDto): Observable<UsuarioDto> {

    console.log('usuario', usuario)
    return this.http.post<UsuarioDto>(this.apiUrl, usuario);
  }
}
