import { HttpEvent, HttpHandler, 
    HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import {  delay, finalize } from "rxjs/operators";
import { BusyService } from "../services/busy.service";

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

constructor(private busySer: BusyService) {

}

intercept(req: HttpRequest<any>, next: HttpHandler)
: Observable<HttpEvent<any>> {  
    this.busySer.busy();
    return next.handle(req).pipe(
        delay(1000),
        finalize( ()=> {
            this.busySer.idle();
        })
       
    );
}


}