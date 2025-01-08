import { Component, OnInit } from '@angular/core';
import { ChatService, ChatMessage } from '../chat.service';

// Zaimportuj odpowiednie moduły, które są wymagane dla dyrektyw i komponentów Angulara
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';  // Dla ngModel
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-chat',
  standalone: true,  // Deklarujemy, że komponent jest standalone
  imports: [
    CommonModule,
    FormsModule,  // Dodajemy FormsModule, aby używać [(ngModel)]
    MatToolbarModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  chatHistory: ChatMessage[] = [];  // Historia czatu
  userMessage: string = ''; // Wiadomość użytkownika

  constructor(private chatService: ChatService) { }

  ngOnInit(): void {
    this.getChatHistory();
  }

  getChatHistory(): void {
    this.chatService.getChatHistory().subscribe(
      (data) => {
        this.chatHistory = data;
      },
      (error) => {
        console.error('Błąd podczas pobierania historii czatu', error);
      }
    );
  }

  sendMessage(): void {
    if (this.userMessage.trim()) {
      this.chatService.sendMessage(this.userMessage).subscribe(
        (response) => {
          this.chatHistory.push(response);  // Dodaj odpowiedź do historii
          this.userMessage = '';  // Wyczyść pole wejściowe
        },
        (error) => {
          console.error('Błąd podczas wysyłania wiadomości', error);
        }
      );
    }
  }

  rateMessage(id: number, rating: string): void {
    this.chatService.rateMessage(id, rating).subscribe(
      () => {
        const message = this.chatHistory.find((msg) => msg.id === id);
        if (message) {
          message.rating = rating; // Zaktualizuj ocenę wiadomości
        }
      },
      (error) => {
        console.error('Błąd podczas oceniania wiadomości', error);
      }
    );
  }
}
