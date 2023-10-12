import { Component, inject } from '@angular/core';
import { LoaderService } from 'src/app/shared/services/loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent {
  showLoader$ = inject(LoaderService).isLoading$;
}
