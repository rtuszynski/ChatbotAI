import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { ChatComponent } from './chat/chat/chat.component';  // Importowanie standalone komponentu
import { RouterModule, Routes } from '@angular/router';  // Import RouterModule

// Zdefiniuj trasy (w tym przypadku tylko jedna)
const routes: Routes = [
  { path: '', component: ChatComponent },
  // Możesz dodać inne trasy tutaj, jeśli chcesz
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),  // Dodaj RouterModule i zdefiniowane trasy
    ChatComponent  // Używamy standalone komponentu
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
