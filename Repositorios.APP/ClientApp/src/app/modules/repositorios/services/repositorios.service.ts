import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Linguagem } from '../models/linguagem';
import { Repositorio } from '../models/repositorio';

@Injectable({
  providedIn: 'root'
})
export class RepositoriosService {
  private baseUrl = `${environment.apiUrl}/repositorios`;

  constructor(private http: HttpClient) { }

  obterLinguagens(): Observable<Linguagem[]> {
    return this.http.get<Linguagem[]>(`${this.baseUrl}/ObterLinguagens`);
  }

  adicionar(repositorio: Repositorio): Observable<any> {
    return this.http.post(`${this.baseUrl}`, repositorio);
  }

  listarComPaginacao(linguagem: string, pagina: number, quantidadePorPagina: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/ListarComPaginacao/?linguagem=${linguagem}&pagina=${pagina}&quantidadePorPagina=${quantidadePorPagina}`);
  }

  remover(id: number | undefined): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
