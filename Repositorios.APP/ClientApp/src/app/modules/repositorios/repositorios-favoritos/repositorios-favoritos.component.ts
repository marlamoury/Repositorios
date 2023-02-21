import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Linguagem } from '../models/linguagem';
import { Repositorio } from '../models/repositorio';
import { RepositoriosService } from '../services/repositorios.service';

@Component({
  selector: 'app-repositorios-favoritos',
  templateUrl: './repositorios-favoritos.component.html',
  styleUrls: ['./repositorios-favoritos.component.css']
})
export class RepositoriosFavoritosComponent implements OnInit {

  linguagens: Linguagem[] | undefined;

  linguagem: string = "";
  repositorios: Repositorio[] = [];

  pagina: number = 0;
  quantidadePorPagina = 5;
  total: number = 0;

  constructor(private repositoriosService: RepositoriosService
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
    this.repositoriosService.listarComPaginacao(linguagem, pagina, quantidadePorPagina)
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

  onRemove(repositorio: Repositorio) {
    this.repositoriosService.remover(repositorio.id)
      .subscribe({
        next: () => {
          this.listarRepositorios(this.linguagem, 0, 5);
           this._snackBar.open(`O repositorio "${repositorio.nome}" foi removido dos favoritos com sucesso!`, undefined, {
            duration: 5000
          })
        },
        error: (error) => this._snackBar.open(error.error, undefined, {
          duration: 5000
        })
      })
  }

}
