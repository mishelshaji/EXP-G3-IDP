import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**
 * This service is used to manage idps. It will be used by the components
 * to fetch the list of idps, create a new idp, update an existing
 * idp, and delete a idp.
 */
@Injectable({
    providedIn: 'root'
})
export class IdpService {

    /**
     * This is the base URL of the API. It will be used to make HTTP requests.
     */
    url = 'https://localhost:7264/api/user/idp';

    constructor(private http: HttpClient) { }

    /**
     * The getAll method will fetch the list of idps from the server.
     * @returns {Observable<IdpViewDto[]>} Return the list of idps from the server.
     */
    getAll() {
        return this.http.get<IdpViewDto[]>(this.url);
    }

    /**
     * Used to fetch a idp by its unique identifier.
     * @param id The unique identifier of the idp.
     * @returns {Observable<any>} An observable that will emit the idp with the specified id.
     */
    getById(id: number) {
        return this.http.get<IdpViewDto>(this.url + '/' + id);
    }

    /**
     * Creates a new idp on the server. It will send a POST request to the
     * server with the idp data in the request body.
     * @param model The idp data that will be sent to the server.
     * @returns {Observable<any>} An observable that will emit the newly created idp.
     */
    create(model: IdpCreateDto) {
        return this.http.post<IdpViewDto>(this.url, model);
    }
}