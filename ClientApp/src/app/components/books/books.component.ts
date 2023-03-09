import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  // There is a chance of error appearing here.
  books: any;

  constructor(private service: BookService,
              private router: Router) { }

  ngOnInit() {
    // this.service.getAllBooks().subscribe({
    //   next : (res: any) => {
    //     this.books = res;
    //   }
    // })
    // The code above also works
    this.service.getAllBooks().subscribe(data => {
      this.books = data;
    })
  }

  showBook(id: number) {
    this.router.navigateByUrl("/show-book/"+id);
    
  }
  
}
