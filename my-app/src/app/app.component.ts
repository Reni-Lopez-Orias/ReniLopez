import { Component, OnInit } from '@angular/core';
import { SpinnerService } from './core/services/spinner/spinner.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'my-app';
  loading: boolean = true;

  constructor(
    private _spinnerService: SpinnerService
  ){
    
  }
  ngOnInit(): void {
    this._spinnerService.spinner$.subscribe( data =>{
      this.loading = data;
    })
    
  } 

}
