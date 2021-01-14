import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app.routing.module';
import { CoreModule } from './core/core.module';
import { AppComponent } from './app.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { NavbarComponent } from '../app/core/navbar/navbar.component';
import { AppInitializerService } from '../app/app-initializer.service';
import { environment } from 'src/environments/environment';
import { ConstantsMaster } from './shared/constants/constantsMaster';

import { IPublicClientApplication, PublicClientApplication, InteractionType, BrowserCacheLocation } from '@azure/msal-browser';
import { MsalGuard, MsalInterceptor, MsalBroadcastService, MsalInterceptorConfiguration, MsalModule, MsalService, MSAL_GUARD_CONFIG, MSAL_INSTANCE, MSAL_INTERCEPTOR_CONFIG, MsalGuardConfiguration } from '@azure/msal-angular';

import * as auth from './auth-config.json';

const isIE = window.navigator.userAgent.indexOf("MSIE ") > -1 || window.navigator.userAgent.indexOf("Trident/") > -1;

/**
 * Here we pass the configuration parameters to create an MSAL instance.
 * For more info, visit: https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-angular/docs/v2-docs/configuration.md
 */
export function MSALInstanceFactory(): IPublicClientApplication {
  return new PublicClientApplication({
    auth: {
      clientId: auth.credentials.clientId,
      authority: 'https://login.microsoftonline.com/' + auth.credentials.tenantId,
      redirectUri: auth.configuration.redirectUri
    },
    cache: {
      cacheLocation: BrowserCacheLocation.LocalStorage,
      storeAuthStateInCookie: isIE, // set to true for IE 11
    },
  });
}

/**
 * MSAL Angular will automatically retrieve tokens for resources 
 * added to protectedResourceMap. For more info, visit: 
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-angular/docs/v2-docs/initialization.md#get-tokens-for-web-api-calls
 */

 export function MSALInterceptorConfigFactory(): MsalInterceptorConfiguration {

  const protectedResourceMap = new Map<string, Array<string>>();
  //protectedResourceMap.set(auth.resources.todoListApi.resourceUri, auth.resources.todoListApi.resourceScopes);
  protectedResourceMap.set(environment.settings.applicationBaseUrl+"/"+ConstantsMaster.apiEndPoints.lookup.trainingTypes, ConstantsMaster.resourceScopes);
  protectedResourceMap.set(environment.settings.applicationBaseUrl+"/"+ConstantsMaster.apiEndPoints.lookup.employeeTrainingsDetails, ConstantsMaster.resourceScopes);
  protectedResourceMap.set(environment.settings.applicationBaseUrl+"/"+ConstantsMaster.apiEndPoints.lookup.addEmployeeTraining, ConstantsMaster.resourceScopes);
  protectedResourceMap.set(environment.settings.applicationBaseUrl+"/"+ConstantsMaster.apiEndPoints.lookup.deleteEmployeeTraining, ConstantsMaster.resourceScopes);  
  return {
    interactionType: InteractionType.Redirect,
    protectedResourceMap
  };
}

/**
 * Set your default interaction type for MSALGuard here. If you have any
 * additional scopes you want the user to consent upon login, add them here as well.
 */
export function MSALGuardConfigFactory(): MsalGuardConfiguration {
  return { interactionType: InteractionType.Redirect };
}


// export function intializeApp(appInitalizerService: AppInitializerService): Function {
//   return () => appInitalizerService.initializeApp();
// }


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule,
    MatSelectModule,
    MatButtonModule,
    BrowserAnimationsModule,
    BrowserModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CoreModule,
    AppRoutingModule    
  ],
  providers: [
    //{
      //provide: APP_INITIALIZER,
      //useFactory: intializeApp,
      //multi: true,
      //deps: [AppInitializerService]
    //},
    {
      provide: MSAL_INSTANCE,
      useFactory: MSALInstanceFactory
    },
    {
      provide: MSAL_GUARD_CONFIG,
      useFactory: MSALGuardConfigFactory
    },
    {
      provide: MSAL_INTERCEPTOR_CONFIG,
      useFactory: MSALInterceptorConfigFactory
    },
    MsalService,
    MsalGuard,
    MsalBroadcastService,
    AppInitializerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
