import { Component } from '@angular/core';
import { DataService } from '../data.service';
import { Books } from '../interfaces';
import { Authors } from '../interfaces';
import { Categories } from '../interfaces';

@Component({
  selector: 'app-book',
  templateUrl: "./book.component.html",
  providers: [DataService]
})

export class BookComponent {
  public books: Books[];
  public authors: Authors[];
  public categories: Categories[];
  public isShowDetails: boolean = true;
  public isShowCreated: boolean = false;
  public bookInsert: Books;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getBooks();
    this.getAuthors();
    this.getCategories();
  }

  getBooks() {
    this.dataService.getAllBooks().subscribe(res => {
      console.log(res);
      this.books = res;
    }, error => console.log(error));
  }

  getAuthors() {
    this.dataService.getAllAuthors().subscribe(res => {
      console.log(res);
      this.authors = res;
    }, error => console.log(error));
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
