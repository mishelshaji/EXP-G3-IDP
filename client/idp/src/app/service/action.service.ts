import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**
 * This service is used to manage action. It will be used by the components
 * to fetch the list of actions, create a new action, update an existing
 * action, and delete a action.
 */
@Injectable({
    providedIn: 'root'
})
export class ActionService {

    /**
     * This is the base URL of the API. It will be used to make HTTP requests.
     */
    url = 'https://localhost:7264/api/user/objectiveaction';

    constructor(private http: HttpClient) { }

    /**
     * The getAll method will fetch the list of actions from the server.
     * @returns {Observable<ActionViewDto[]>} Return the list of actions from the server.
     */
    getAll() {
        return this.http.get<ActionViewDto[]>(this.url);
    }

    /**
     * Used to fetch a action by its unique identifier.
     * @param id The unique identifier of the action.
     * @returns {Observable<any>} An observable that will emit the action with the specified id.
     */
    getById(id: number) {
        return this.http.get<ActionViewDto>(this.url + '/' + id);
    }

    /**
     * Creates a new action on the server. It will send a POST request to the
     * server with the action data in the request body.
     * @param model The action data that will be sent to the server.
     * @returns {Observable<any>} An observable that will emit the newly created action.
     */
    create(model: ActionCreateDto) {
        return this.http.post<ActionViewDto>(this.url, model);
    }

    /**
     * Updates an existing action on the server. It will send a PUT request to
     * the server with the action data in the request body.
     * @param id The unique identifier of the action.
     * @param model The action data that will be sent to the server.
     * @returns {Observable<any>} An observable that will emit the response from the server.
     */
    update(id: number, model: ActionCreateDto) {
        return this.http.put(this.url + '/' + id, model);
    }
}