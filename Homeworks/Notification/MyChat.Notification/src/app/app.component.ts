import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NotificationService } from '../service/notification.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'MyChat.Notification';
  constructor(private notificationService: NotificationService) {}

  ngOnInit(): void {
    this.notificationService.onReceiveNotification((message: string) => {
      window.alert(message)
    });
  }
}
