import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { INomes } from './nomes'

@Injectable({
  providedIn: 'root'
})
export class NomesService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  private apiURL = this.baseUrl + "api/nomes";

  // Lista os usuários do banco de dados
  ListarNomes(): Observable<INomes[]> {
    return this.http.get<INomes[]>(this.apiURL);
  }

  // Obtem o usuário por id
  obterNomes(usuarioId: string): Observable<INomes> {
    return this.http.get<INomes>(this.apiURL + '/' + usuarioId);
  }

  // Criar usuário
  criarNomes(usuario: INomes): Observable<INomes> {
    return this.http.post<INomes>(this.apiURL, usuario);
  }

  // Atualiza o usuario
  atualizarNomes(usuario: INomes): Observable<INomes> {
    return this.http.put<INomes>(this.apiURL + '/' + usuario.id, usuario);
  }

  // Excluir o usuário
  excluirNomes(usuarioId: string): Observable<INomes> {
    return this.http.delete<INomes>(this.apiURL + '/' + usuarioId.toString());
  }

}
