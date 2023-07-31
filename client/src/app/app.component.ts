import { Component, OnInit } from '@angular/core';
import { WeatherService } from './services/weather.service';
import { WeatherRequest } from './services/weather-request';
import { FormBuilder, FormGroup } from '@angular/forms';
import { WeatherResponse } from './services/weather-response';
import { Response } from './services/response';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  form!: FormGroup;
  result!: Response<WeatherResponse> | null;

  constructor(private fb: FormBuilder, private svc: WeatherService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      type: ['city'],
      city: [],
      zipcode: [],
      lat: [],
      long: []
    });
  }

  search(): void {
    this.result = null;
    this.svc.get(this.form.value).subscribe(result => {
      this.result = result;
    });
  }

  getTemp(kelvin: number) {
    return Math.round((kelvin - 273.15) * (9/5) + 32);
  }
}
