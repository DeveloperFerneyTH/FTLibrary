import { Component } from '@angular/core';
import { DataService } from '../data.service';
import { Categories } from '../interfaces';

@Component({
  selector: 'app-category',
  templateUrl: "./category.component.html",
  providers: [DataService]
})

export class CategoryComponent {
  public categories: Categories[];
  public isShowDetails: boolean = true;
  public isShowCreated: boolean = false;
  public categoryInsert: Categories;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getCategories();
  }

  getCategories() {
    this.dataService.getAllCategories().subscribe(res => {
      console.log(res);
      this.categories = res;
    }, error => console.log(error));
  }

  showInsert() {
    this.isShowDetails = false;
    this.isShowCreated = true;
  }

  hideInsert() {
    this.isShowDetails = true;
    this.isShowCreated = false;
  }
}
