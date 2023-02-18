import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**
 * This service is used to manage profile. It will be used by the components
 * to fetch the list of profile and update profile
 */
@Injectable({
    providedIn: 'root'
})
export class EmployeeService {

    /**
     * This is the base URL of the API. It will be used to make HTTP requests.
     */
    url = 'https://localhost:7264/api/user/employee';

    constructor(private http: HttpClient) { }

    create(employee: FormData) {
        return this.http.post(this.url, employee);
    }
}
