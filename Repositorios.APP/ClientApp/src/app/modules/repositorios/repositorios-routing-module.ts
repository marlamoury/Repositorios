import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RepositoriosFavoritosComponent } from './repositorios-favoritos/repositorios-favoritos.component';
import { RepositoriosGithubComponent } from './repositorios-github/repositorios-github.component';

const routes: Routes = [
    { path: 'github', component: RepositoriosGithubComponent },
    { path: 'favoritos', component: RepositoriosFavoritosComponent },
    { path: '', redirectTo: 'github', pathMatch: 'full' },
    { path: '**', redirectTo: 'github', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forChild (routes)],
    exports: [RouterModule]
})
export class RepositoriosRoutingModule { }