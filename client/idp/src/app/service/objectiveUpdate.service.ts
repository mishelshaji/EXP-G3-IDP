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
export class ObjectiveUpdateService {

    /**
     * This is the base URL of the API. It will be used to make HTTP requests.
     */
    url = 'https://localhost:7264/api/Manager/ManagerObjectiveControllers';

    constructor(private http: HttpClient) { }


    update(id: number, model: ObjectiveUpdateDto) {
        return this.http.put(this.url + '/' + id, model);
    }
}