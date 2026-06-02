import { authGuard, permissionGuard } from '@abp/ng.core';
import { Routes } from '@angular/router';

export const APP_ROUTES: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadComponent: () => import('./home/home.component').then(c => c.HomeComponent),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(c => c.createRoutes()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(c => c.createRoutes()),
  },
  {
    path: 'tenant-management',
    loadChildren: () => import('@abp/ng.tenant-management').then(c => c.createRoutes()),
  },
  {
    path: 'setting-management',
    loadChildren: () => import('@abp/ng.setting-management').then(c => c.createRoutes()),
  },
  // {
  //   path: 'todos',
  //   pathMatch: 'full',
  //   loadComponent: () => import('./todo-item/todo-item').then(c => c.TodoItem),
  // },
  {
    path: 'todo',
    loadComponent: () =>
      import('./todo-item/todo-item')
        .then(m => m.TodoItem),
    // canActivate: [authGuard]  // اختياري — يحتاج تسجيل دخول
  }

];

