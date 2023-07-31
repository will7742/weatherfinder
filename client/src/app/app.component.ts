import { Component } from '@angular/core';
import { WeatherService } from './services/weather.service';
import { WeatherRequest } from './services/weather-request';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(svc: WeatherService) {
    svc.get({
      city: 'Saint Louis',
      zipcode: ''
    } as WeatherRequest).subscribe();
  }
}
