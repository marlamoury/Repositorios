import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Linguagem } from '../models/linguagem';
import { Repositorio } from '../models/repositorio';
import { GithubService } from '../services/github.service';
import { RepositoriosService } from '../services/repositorios.service';

export interface Section {
  name: string;
  updated: Date;
}

@Component({
  selector: 'app-repositorios-github',
  templateUrl: './repositorios-github.component.html',
  styleUrls: ['./repositorios-github.component.css']
})
export class RepositoriosGithubComponent implements OnInit {

  linguagens: Linguagem[] | undefined;

  linguagem: string = "";
  repositorios: Repositorio[] = [];

  pagina: number = 0;
  quantidadePorPagina = 5;
  total: number = 0;

  constructor(private repositoriosService: RepositoriosService
            , private gitHubService: GithubService
            , private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.obterLinguagens();
  }
  
  private obterLinguagens() {
    this.repositoriosService.obterLinguagens()
      .subscribe({
        next: (resultado) => this.linguagens = resultado,
        error: (error) => this._snackBar.open(error.error, undefined, {
          duration: 5000
        })
      })
  }

  private listarRepositorios(linguagem: string, pagina: number, quantidadePorPagina: number) {
    this.gitHubService.listarRepositorios(linguagem, pagina, quantidadePorPagina)
      .subscribe({
        next: (resultado) => { 
          this.repositorios = resultado.repositorios;
          this.total = resultado.total; 
        },
        error: (error) => this._snackBar.open(error.error, undefined, {
          duration: 5000
        })
      })
  }

  onChangeLanguage(event: any) {
    this.pagina = 0;
    this.quantidadePorPagina = 5;
    this.linguagem = event.value;
    this.listarRepositorios(event.value, this.pagina, this.quantidadePorPagina);
  }

  onPage(event: any) {
    this.listarRepositorios(this.linguagem, event.pageIndex, event.pageSize); 
  }

  onFavorite(repositorio: Repositorio) {
    this.repositoriosService.adicionar(repositorio)
      .subscribe({
        next: () => {
           this._snackBar.open(`O repositorio "${repositorio.nome}" foi favoritado com sucesso!`, undefined, {
            duration: 5000
          })
        },
        error: (error) => this._snackBar.open(error.error, undefined, {
          duration: 5000
        })
      })
  }
}
