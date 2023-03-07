import { HttpErrorResponse, HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log('entra interceptor');

    let codToken = btoa("ABC123:ABC123")

    const headers = new HttpHeaders()
      .set('content-type', 'application/json')
      .set('Access-Control-Allow-Origin', '*')
      .set('Authorization', `Basic ${codToken}`);
 
    const reqClone = req.clone({ headers });

    return next.handle(reqClone).pipe(
      catchError(this.manejoErrores)
    );

  }
  manejoErrores(error: HttpErrorResponse) {
    return throwError(error)
  }

}
