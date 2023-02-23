import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**
 * This service is used to manage profile. It will be used by the components
 * to fetch the list of profile and update profile
 */
@Injectable({
    providedIn: 'root'
})
export class ProfileService {

    /**
     * This is the base URL of the API. It will be used to make HTTP requests.
     */
    url = 'https://localhost:7264/api/User/Accounts/profile';

    constructor(private http: HttpClient) { }

    /**
     * Used to fetch a category by its unique identifier.
     * @param id The unique identifier of the profile.
     * @returns {Observable<any>} An observable that will emit the category with the specified id.
     */
    get() {
        return this.http.get<ProfileViewDto>(this.url + '/');
    }

    getManager() {
        return this.http.get<ProfileViewDto[]>(this.url + '/');
    }
  
    /**
     * Updates an existing Profile on the server. It will send a PUT request to
     * the server with the Profile data in the request body.
     * @param id The unique identifier of the Profile.
     * @param model The Profile data that will be sent to the server.
     * @returns {Observable<any>} An observable that will emit the response from the server.
     */
    update(id: number, model: ProfileViewDto) {
        return this.http.put(this.url + '/' + id, model);
    }
}
