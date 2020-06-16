import { Component } from '@angular/core';
import { DataService } from '../data.service';
import { Authors } from '../interfaces';

@Component({
  selector: 'app-author',
  templateUrl: "./author.component.html",
  providers: [DataService]
})

export class AuthorComponent {
  public authors: Authors[];
  public isShowDetails: boolean = true;
  public isShowCreated: boolean = false;
  public authorInsert: Authors;
  private txtFirtsName: string;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.getAuthors();
  }

  getAuthors() {
    this.dataService.getAllAuthors().subscribe(res => {
      console.log(res);
      this.authors = res;
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

  createAuthor() {
    this.dataService.createAuthor(this.authorInsert).subscribe(res => {
      if (res.ExecuteSuccess) {
        alert(res.Message);
        this.hideInsert();
        this.getAuthors();
      } else {
        alert(res.Message);
      }
    });

    
  }
}
