// view.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { View } from '../models/view.model';

@Injectable({
  providedIn: 'root'
})
export class ViewService {
  private apiUrl = 'https://localhost:7114/api/Views';

  constructor(private http: HttpClient) { }

  getViews(): Observable<View[]> {
    return this.http.get<View[]>(this.apiUrl);
  }

  getView(id: string): Observable<View> {
    return this.http.get<View>(`${this.apiUrl}/${id}`);
  }

  createView(view: View): Observable<View> {
    return this.http.post<View>(this.apiUrl, view);
  }

  updateView(view: View): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${view.id}`, view);
  }

  deleteView(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
