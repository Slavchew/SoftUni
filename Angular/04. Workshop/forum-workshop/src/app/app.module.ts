import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ThemeListComponent } from './theme-list/theme-list.component';
import { AsideComponent } from './aside/aside.component';
import { UserService } from './services/user.service';
import { storageServiceProvider } from './services/storage.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ThemeListComponent,
    AsideComponent,
  ],
  imports: [
    BrowserModule
  ],
  providers: [
    UserService,
    storageServiceProvider
  ],
  bootstrap: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
  ]
})
export class AppModule { }
