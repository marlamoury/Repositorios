import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Repositorio } from '../models/repositorio';

@Injectable({
  providedIn: 'root'
})
export class GithubService {
  private baseUrl = `${environment.apiUrl}/github`;

  constructor(private http: HttpClient) { }

  listarRepositorios(linguagem: string, pagina: number, quantidadePorPagina: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/ListarRepositorios/?linguagem=${linguagem}&pagina=${pagina}&quantidadePorPagina=${quantidadePorPagina}`);
  }

}
