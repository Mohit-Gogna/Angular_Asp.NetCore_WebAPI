import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Model } from '../model';

@Injectable()
export class DataService {
  public baseUrl: string = "http://localhost:61959/api/data/";
  constructor(private client: HttpClient) {  }

  getData() {
    return this.client.get<Model[]>(this.baseUrl);
  }

  updateData(item: Model) {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json');
   
    return this.client.put(this.baseUrl, JSON.stringify(item), {
      headers: headers
    });
  }
}
