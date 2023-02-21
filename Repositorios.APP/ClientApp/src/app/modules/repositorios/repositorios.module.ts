import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RepositoriosGithubComponent } from './repositorios-github/repositorios-github.component';
import { RepositoriosRoutingModule } from './repositorios-routing-module';

import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RepositoriosFavoritosComponent } from './repositorios-favoritos/repositorios-favoritos.component';

@NgModule({
  declarations: [
    RepositoriosGithubComponent,
    RepositoriosFavoritosComponent
  ],
  imports: [
    CommonModule,
    RepositoriosRoutingModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule,
    MatSelectModule,
    MatCardModule,
    MatDividerModule,
    MatTooltipModule,
    MatSnackBarModule
  ]
})
export class RepositoriosModule { }
