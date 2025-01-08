import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms'; // Importuj FormsModule

@NgModule({
  imports: [
    CommonModule,
    MatToolbarModule, // Dodaj MatToolbarModule
    MatIconModule,    // Dodaj MatIconModule
    MatFormFieldModule, // Dodaj MatFormFieldModule
    MatInputModule,     // Dodaj MatInputModule
    FormsModule,        // Dodaj FormsModule
  ],
  exports: [
    // Nie deklarujemy już ChatComponent
  ]
})
export class ChatModule { }
