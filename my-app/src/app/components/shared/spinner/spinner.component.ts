import { Component, OnInit } from '@angular/core';
import { SpinnerService } from 'src/app/core/services/spinner/spinner.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent implements OnInit {

  loading: boolean = true;

  constructor(
    private _spinnerService: SpinnerService
  ) {
  }

  ngOnInit(): void {
    this._spinnerService.spinner$.subscribe(data => {
      this.loading = data;
    })

  }

}
