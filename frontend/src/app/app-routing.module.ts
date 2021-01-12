import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UsernameComponent } from './username/username.component';
import { ResetComponent } from './reset/reset.component';

const routes: Routes = [

  {path:'username',component: UsernameComponent},
  {path :' ResetComponent',component: ResetComponent},
];

//@NgModule({
  //imports: [RouterModule.forRoot(routes)],
  //exports: [RouterModule]
//})
//export class AppRoutingModule { }
export const AppRoutingModule = RouterModule.forRoot(routes);
