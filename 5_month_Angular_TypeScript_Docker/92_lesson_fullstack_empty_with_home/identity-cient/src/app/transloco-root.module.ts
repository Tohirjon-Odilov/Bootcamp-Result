import {
  provideTransloco,
  TranslocoModule
} from '@ngneat/transloco';
import { NgModule } from '@angular/core';
import { TranslocoHttpLoader } from './transloco-loader';
// import { environment } from '../../Users/Tohirjon Odilov/source/repos/Tohirjon-Odilov/Bootcamp-Result/5_month_Angular_TypeScript_Docker/92_lesson_fullstack_empty_with_home/identity-cient/src/environments/environment';

@NgModule({
  exports: [ TranslocoModule ],
  providers: [
      provideTransloco({
        config: {
          availableLangs: ['en', 'ru', 'uz'],
          defaultLang: 'en',
          // Remove this option if your application doesn't support changing language in runtime.
          reRenderOnLangChange: true,
          // prodMode: environment.production,
        },
        loader: TranslocoHttpLoader
      }),
  ],
})
export class TranslocoRootModule {}
