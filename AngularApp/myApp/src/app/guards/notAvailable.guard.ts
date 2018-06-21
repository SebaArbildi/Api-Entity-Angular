import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { empty } from 'rxjs';


@Injectable()
export class NotAvailableGuard implements CanActivate {

    constructor(private _router: Router) { }

    canActivate(): boolean {
        if (!(localStorage.getItem('userToken'))) {
            alert('Debes estar logeado para acceder a esta funcionaldiad');
            console.log('Debes estar logeado para acceder a esta funcionaldiad');
            this._router.navigate(['/welcome']);
            return false;
        }
        else {
            if (localStorage.getItem('isAdmin') == 'false') {
                alert('No tiene permisos para acceder a esta funcionalidad');
                console.log('No tiene permisos para acceder a esta funcionalidad');
                this._router.navigate(['/welcome']);
                return false;
            };
        }

        return true;
    }
}