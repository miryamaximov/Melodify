import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { Category } from '../classes/Category';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-list',
  standalone: true,
  imports: [NgFor],
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css',
})
export class CategoryListComponent {
  categories: Array<Category> = new Array<Category>();
  showSongsOfCategory(categoryId:any){
    console.log(categoryId);
    
    this.router.navigate(['category-details/'+categoryId])
  }
  constructor(public categoryServ: CategoryService, public router:Router) {
    categoryServ.getAll().subscribe(
      (data) => {
        this.categories = data;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
