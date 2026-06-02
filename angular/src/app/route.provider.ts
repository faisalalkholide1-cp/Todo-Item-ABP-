import { RoutesService, eLayoutType } from '@abp/ng.core';
import { inject, provideAppInitializer } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routes = inject(RoutesService);
  routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/todo',
        name: 'Todo Items',          // الاسم في القائمة
        iconClass: 'ti ti-checklist', // الأيقونة
        layout: eLayoutType.application,
        order: 3,                    // الترتيب في القائمة
      }
  ]);
}
