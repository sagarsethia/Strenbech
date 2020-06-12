import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UploadService {

  SERVER_URL = 'https://localhost:5001/api/csv/Upload';
  constructor(private httpClient: HttpClient) { }
  public upload(formData) {
    return this.httpClient.post<any>(this.SERVER_URL, formData);
  }
}
