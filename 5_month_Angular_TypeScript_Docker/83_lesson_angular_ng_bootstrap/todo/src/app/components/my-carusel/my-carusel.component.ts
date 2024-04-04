import { Component } from '@angular/core';
import {
  NgbCarouselConfig,
  NgbCarouselModule,
} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-my-carusel',
  standalone: true,
  imports: [NgbCarouselModule],
  templateUrl: './my-carusel.component.html',
  styleUrl: './my-carusel.component.scss',
  providers: [NgbCarouselConfig],
})
export class MyCaruselComponent {
  images = [700, 533, 807, 124].map(
    (n) => `https://picsum.photos/id/${n}/1296/500`
  );

  constructor(config: NgbCarouselConfig) {
    // customize default values of carousels used by this component tree
    config.interval = 10000;
    config.wrap = false;
    config.keyboard = false;
    config.pauseOnHover = false;
  }
}

// export class MyCaruselComponent {}
