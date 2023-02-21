import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: 'repositorios', loadChildren: () => import('./modules/repositorios/repositorios.module').then(m => m.RepositoriosModule)},
    { path: '', redirectTo: 'repositorios', pathMatch: 'full'}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }