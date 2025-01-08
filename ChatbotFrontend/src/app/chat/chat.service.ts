import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// Interfejs dla wiadomości
export interface ChatMessage {
  id: number;
  userMessage: string;
  botResponse: string;
  rating?: string;
}

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private apiUrl = 'http://localhost:5189/api/chat'; // Adres API

  constructor(private http: HttpClient) { }

  // Pobierz historię czatu
  getChatHistory(): Observable<ChatMessage[]> {
    return this.http.get<ChatMessage[]>(`${this.apiUrl}/messages`);
  }

  // Wyślij wiadomość
  sendMessage(userMessage: string): Observable<ChatMessage> {
    const command = { userMessage, botResponse: 'Lorem ipsum...' }; // Zakładam statyczną odpowiedź dla prostoty
    return this.http.post<ChatMessage>(`${this.apiUrl}/messages`, command);
  }

  // Oceń wiadomość
  rateMessage(id: number, rating: string): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/messages/${id}/rating`, rating);
  }
}
