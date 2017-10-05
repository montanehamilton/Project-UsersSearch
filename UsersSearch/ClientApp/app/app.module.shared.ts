import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ContactUsComponent } from './components/contactus/contactus.component';
import { DemoDataComponent } from './components/demodata/demodata.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        ContactUsComponent,
        HomeComponent,
        DemoDataComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'contact-us', component: ContactUsComponent },
            { path: 'demo-data', component: DemoDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
