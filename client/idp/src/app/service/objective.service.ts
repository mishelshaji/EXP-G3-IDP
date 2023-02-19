import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**
 * This service is used to manage objectives. It will be used by the components
 * to fetch the list of objectives, create a new objective, update an existing
 * objective, and delete a objective.
 */
@Injectable({
    providedIn: 'root'
})
export class ObjectiveService {

    /**
     * This is the base URL of the API. It will be used to make HTTP requests.
     */
    url = 'https://localhost:7264/api/user/ObjectivesControllers';

    constructor(private http: HttpClient) { }

    /**
     * The getAll method will fetch the list of objectives from the server.
     * @returns {Observable<ObjectiveViewDto[]>} Return the list of objectives from the server.
     */
    getAll() {
        return this.http.get<ObjectiveViewDto[]>(this.url);
    }

    /**
     * Used to fetch a objective by its unique identifier.
     * @param id The unique identifier of the objective.
     * @returns {Observable<any>} An observable that will emit the objective with the specified id.
     */
    getById(id: number) {
        return this.http.get<ObjectiveViewDto>(this.url + '/' + id);
    }

    /**
     * Creates a new objective on the server. It will send a POST request to the
     * server with the objective data in the request body.
     * @param model The objective data that will be sent to the server.
     * @returns {Observable<any>} An observable that will emit the newly created objective.
     */
    create(model: ObjectiveCreateDto) {
        return this.http.post<ObjectiveViewDto>(this.url, model);
    }
}