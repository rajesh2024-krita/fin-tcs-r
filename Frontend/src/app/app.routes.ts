
import { Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { RoleGuard } from './core/guards/role.guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/auth/login',
    pathMatch: 'full'
  },
  {
    path: 'auth',
    loadChildren: () => import('./features/auth/auth.routes').then(m => m.authRoutes)
  },
  {
    path: 'dashboard',
    canActivate: [AuthGuard],
    loadChildren: () => import('./features/dashboard/dashboard.routes').then(m => m.dashboardRoutes)
  },
  {
    path: 'societies',
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] },
    loadChildren: () => import('./features/societies/societies.routes').then(m => m.societiesRoutes)
  },
  {
    path: 'users',
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin'] },
    loadChildren: () => import('./features/users/users.routes').then(m => m.usersRoutes)
  },
  {
    path: 'members',
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin', 'User'] },
    loadChildren: () => import('./features/members/members.routes').then(m => m.membersRoutes)
  },
  {
    path: 'loans',
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin', 'User'] },
    loadChildren: () => import('./features/loans/loans.routes').then(m => m.loansRoutes)
  },
  {
    path: 'vouchers',
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin', 'User'] },
    loadChildren: () => import('./features/vouchers/vouchers.routes').then(m => m.vouchersRoutes)
  },
  {
    path: 'demand',
    canActivate: [AuthGuard, RoleGuard],
    data: { roles: ['SuperAdmin', 'SocietyAdmin', 'User'] },
    loadChildren: () => import('./features/demand/demand.routes').then(m => m.demandRoutes)
  },
  {
    path: '**',
    redirectTo: '/auth/login'
  }
];
