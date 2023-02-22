import { TokenHelper } from '../helpers/tokenHelper';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ManagerGuard implements CanActivate {

    constructor(
        private tokenHelper: TokenHelper,
        private router: Router) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        const hasToken = this.tokenHelper.hasToken();
        const role = this.tokenHelper.getDecodedToken();
        console.log(hasToken);
        if (!hasToken) {
            this.router.navigate(['/login']);
            return false;
        }
        if (role.userrole !== "Manager") {
            this.router.navigate(['']);
            return false;
        }
        return true;
    }

}