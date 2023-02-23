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
export class GetManagerHomeProgressService {

    /**
     * This is the base URL of the API. It will be used to make HTTP requests.
     */
    url = 'https://localhost:7264/api/Manager/GetManagerHomeProgress';

    constructor(private http: HttpClient) { }

    /**
     * Used to fetch a training by its unique identifier.
     * @param id The unique identifier of the training.
     * @returns {Observable<any>} An observable that will emit the training with the specified id.
     */
    getValue() {
        return this.http.get<GetManagerHomeProgressDto>(this.url);
    }
}