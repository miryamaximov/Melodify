import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriesDetail } from '../classes/CategoriesDetail';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root',
})
export class CategoriesDetailService {
  url: string = 'https://localhost:7284/api/CategoriesDetail/';
  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<CategoriesDetail>> {
    return this.http.get<Array<CategoriesDetail>>(this.url + 'GetAll');
  }

  getAllByCategoryId(categoryId: number): Observable<Array<CategoriesDetail>> {
    return this.http.get<Array<CategoriesDetail>>(
      this.url + 'GetAllByCategoryId/' + categoryId
    );
  }
  getByCategoryId(categoryId: number): Observable<CategoriesDetail> {
    return this.http.get<CategoriesDetail>(
      this.url + 'GetByCategoryId/' + categoryId
    );
  }
  getAllBySongId(songId: number): Observable<Array<CategoriesDetail>> {
    return this.http.get<Array<CategoriesDetail>>(
      this.url + 'GetAllBySongId/' + songId
    );
  }
  getBySongId(songId: number): Observable<CategoriesDetail> {
    return this.http.get<CategoriesDetail>(this.url + 'GetBySongId/' + songId);
  }
  add(detail: CategoriesDetail): Observable<Array<CategoriesDetail>> {
    return this.http.post<Array<CategoriesDetail>>(this.url + 'Post', detail);
  }
  delete(
    songId: number,
    categoryId: number
  ): Observable<Array<CategoriesDetail>> {
    return this.http.delete<Array<CategoriesDetail>>(
      this.url + 'Deltet/' + songId + '/' + categoryId
    );
  }
}
