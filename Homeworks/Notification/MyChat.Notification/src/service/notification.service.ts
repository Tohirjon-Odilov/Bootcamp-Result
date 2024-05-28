import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private hubConnection: signalR.HubConnection;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7000/notificationHub')
      .build();
    
    this.hubConnection.start()
      .catch(err => console.error('Error while starting connection: ' + err));
  }

  public onReceiveNotification(callback: (message: string) => void): void {
    this.hubConnection.on('ReceiveNotification', callback);
  }
}
