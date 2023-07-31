import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { WeatherRequest } from './weather-request';
import { Response } from './response';
import { WeatherResponse } from './weather-response';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  constructor(private http: HttpClient){}

  get(request: WeatherRequest): Observable<Response<WeatherResponse>> {
    return this.http.post<Response<WeatherResponse>>(`${environment.apiBase}Weather/?code=${environment.apiCodes['weather']}`, request, { });
  }
}
