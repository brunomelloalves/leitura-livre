import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'cadastro', loadComponent: () => import('./pages/cadastro/cadastro.component').then(m => m.CadastroComponent) },
  { path: 'saiba-mais', loadComponent: () => import('./pages/saiba-mais/saiba-mais.component').then(m => m.SaibaMaisComponent) },
  { path: 'usuarios-listagem', loadComponent: () => import('./pages/usuarios-listagem/usuarios-listagem.component').then(m => m.UsuariosListagemComponent) }

];
