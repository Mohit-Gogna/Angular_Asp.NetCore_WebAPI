import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Model } from '../model';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public summary: Model[];
  public baseUrl: string = "http://localhost:61959/api/data";
  constructor(http: HttpClient) {
    http.get<Model[]>(this.baseUrl).subscribe(result => {
      this.summary = result;
    }, error => console.error(error));
  }
}
