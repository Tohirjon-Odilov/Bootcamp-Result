import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-to-task',
  templateUrl: './to-task.component.html',
  styleUrl: './to-task.component.scss',
})
export class ToTaskComponent {
  @Input() item = '';
  @Input() itemTwo = '';
}
