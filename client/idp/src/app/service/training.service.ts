import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**
 * This service is used to manage training. It will be used by the components
 * to fetch the list of trainings, create a new training, update an existing
 * training, and delete a training.
 */
@Injectable({
    providedIn: 'root'
})
export class TrainingService {

    /**
     * This is the base URL of the API. It will be used to make HTTP requests.
     */
    url = 'https://localhost:7264/api/user/training';

    constructor(private http: HttpClient) { }

    /**
     * The getAll method will fetch the list of trainings from the server.
     * @returns {Observable<trainingViewDto[]>} Return the list of trainings from the server.
     */
    getAll() {
        return this.http.get<TrainingViewDto[]>(this.url);
    }

    /**
     * Used to fetch a training by its unique identifier.
     * @param id The unique identifier of the training.
     * @returns {Observable<any>} An observable that will emit the training with the specified id.
     */
    getById(id: number) {
        return this.http.get<TrainingViewDto>(this.url + '/' + id);
    }

    /**
     * Creates a new training on the server. It will send a POST request to the
     * server with the training data in the request body.
     * @param model The training data that will be sent to the server.
     * @returns {Observable<any>} An observable that will emit the newly created training.
     */
    create(model: TrainingCreateDto) {
        return this.http.post<TrainingViewDto>(this.url, model);
    }

    /**
     * Updates an existing training on the server. It will send a PUT request to
     * the server with the training data in the request body.
     * @param id The unique identifier of the training.
     * @param model The training data that will be sent to the server.
     * @returns {Observable<any>} An observable that will emit the response from the server.
     */
    update(id: number, model: TrainingCreateDto) {
        return this.http.put(this.url + '/' + id, model);
    }
}