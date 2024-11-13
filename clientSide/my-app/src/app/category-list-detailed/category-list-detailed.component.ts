import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoriesDetailService } from '../services/categories-detail.service';
import { CategoriesDetail } from '../classes/CategoriesDetail';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-category-list-detailed',
  standalone: true,
  imports: [NgFor],
  templateUrl: './category-list-detailed.component.html',
  styleUrl: './category-list-detailed.component.css',
})
export class CategoryListDetailedComponent {
  categoriesDetails: Array<CategoriesDetail> = new Array<CategoriesDetail>();
  constructor(
    public activeRout: ActivatedRoute,
    public categoriesDetailServ: CategoriesDetailService
  ) {
    activeRout.params.subscribe((k: any) => {
      categoriesDetailServ.getAllByCategoryId(k['categoryId']).subscribe(
        (data) => {
          this.categoriesDetails = data;
        },
        (err) => {
          console.log(err);
        }
      );
    });
  }
}
