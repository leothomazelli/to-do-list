import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceResponse } from 'src/app/models/ServiceResponse';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private _url = 'https://localhost:7067';

  constructor(private httpClient: HttpClient) {}

  /**
   * Method that searches the database for a register.
   * @param entity defines the object that's being returned.
   * @param apiRoute contains the endpoint that's going to be used.
   * @returns an observable that'll return a ServiceResponse<T> defined by request data.
   */
  get(entity: string, apiRoute: string): Observable<ServiceResponse<any>> {
    return this.httpClient.get<ServiceResponse<any>>(
      `${this._url}/${entity}/${apiRoute}`
    );
  }

  /**
   * Method responsible to communicate with an external api through post.
   * @param data object containing the data that's being used in the api.
   * @param entity defines the object that's being returned.
   * @param apiRoute contains the endpoint that's going to be used.
   * @returns an observable that'll return a ServiceResponse<T> defined by request data.
   */
  post(
    data: any,
    entity: string,
    apiRoute: string
  ): Observable<ServiceResponse<any>> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: 'my-auth-token',
      }),
    };
    return this.httpClient.post<ServiceResponse<any>>(
      `${this._url}/${entity}/${apiRoute}`,
      data,
      httpOptions
    );
  }

  /**
   * Method responsible to communicate with an external api through put.
   * @param data object containing the data that's being used in the api.
   * @param entity defines the object that's being returned.
   * @param apiRoute contains the endpoint that's going to be used.
   * @returns an observable that'll return a ServiceResponse<T> defined by request data.
   */
  put(
    data: any,
    entity: string,
    apiRoute: string
  ): Observable<ServiceResponse<any>> {
    return this.httpClient.put<ServiceResponse<any>>(
      `${this._url}/${entity}/${apiRoute}`,
      data
    );
  }

  /**
   * Method responsible to communicate with an external api through delete
   * @param data object containing the data that's being used in the api.
   * @param entity defines the object that's being returned.
   * @param apiRoute contains the endpoint that's going to be used.
   * @returns an observable that'll return a ServiceResponse<T> defined by request data.
   */
  delete(
    id: number,
    entity: string,
    apiRoute: string
  ): Observable<ServiceResponse<any>> {
    return this.httpClient.delete<ServiceResponse<any>>(
      `${this._url}/${entity}/${apiRoute}/${id}`
    );
  }
}
