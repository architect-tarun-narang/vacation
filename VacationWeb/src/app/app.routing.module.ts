import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { CommonModule, } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { VacationComponent } from './vacation/vacation.component';
import { TravelComponent } from './travel/travel.component';
import { AdhocWFHComponent } from './adhocwfh/adhocwfh.component';
import { TrainingComponent } from './training/training.component';
import { WFHDaysComponent } from './wfhdays/wfhdays.component';


const routes: Routes =[
  {
    path: '',
    loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule), 
    component: DashboardComponent
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule), 
    component: DashboardComponent
  },
  {
    path: 'employeesdashboard',
    loadChildren: () => import('./employeesdashboard/employeesdashboard.module').then(m => m.EmployeesDashboardModule), 
    
  },
  {
    path: 'vacation',
    loadChildren: () => import('./vacation/vacation.module').then(m => m.VacationModule), 
    component: VacationComponent
  },
  {
    path: 'travel',
    loadChildren: () => import('./travel/travel.module').then(m => m.TravelModule), 
    component: TravelComponent
  },
  {
    path: 'training',
    loadChildren: () => import('./training/training.module').then(m => m.TrainingModule), 
    component: TrainingComponent
  },
  {
    path: 'adhocwfh',
    loadChildren: () => import('./adhocwfh/adhocwfh.module').then(m => m.AdhocWFHModule), 
    component: AdhocWFHComponent
  },{
    path: 'wfhdays',
    loadChildren: () => import('./wfhdays/wfhdays.module').then(m => m.WFHDaysModule), 
    component: WFHDaysComponent
  }
];

@NgModule({
  imports: [    
    BrowserModule,
    //RouterModule.forRoot(routes,{ onSameUrlNavigation: 'reload', preloadingStrategy: PreloadAllModules, useHash: true}
    RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload', preloadingStrategy: PreloadAllModules})
      ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
