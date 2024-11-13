import { HttpClient, HttpXsrfTokenExtractor } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../classes/Category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  url: string = 'https://localhost:7284/api/Category/';
  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(this.url + 'GetAll');
  }

  getById(categoryId: number): Observable<Category> {
    return this.http.get<Category>(this.url + 'GetById/' + categoryId);
  }

  add(category: Category): Observable<Array<Category>> {
    return this.http.post<Array<Category>>(this.url + 'Post', category);
  }

  update(category: Category): Observable<Array<Category>> {
    return this.http.put<Array<Category>>(this.url + 'Put', category);
  }

  delete(categoryId: number): Observable<Array<Category>> {
    return this.http.delete<Array<Category>>(this.url + 'Delete/' + categoryId);
  }
}
