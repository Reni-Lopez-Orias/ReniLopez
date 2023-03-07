import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-mensaje-error',
  templateUrl: './mensaje-error.component.html',
  styleUrls: ['./mensaje-error.component.css']
})
export class MensajeErrorComponent {


  @Input("control")
  control: any;

  errorMsg: string = '';

  constructor() { }

  ngDoCheck() {
    if (this.control) {
      this.errorMsg = this.getErrors();
    }
  }

  getErrors(): string {
    return Object.entries(this.control?.errors ?? {})
      .map(([key, msg]: [string, any]) => ({ key, msg }))[0]?.msg;
  }


}
