import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  books: any;

  constructor(private service: BookService,
              private router: Router) { }

  // Shows the data of books
  ngOnInit() {
    this.service.getAllBooks().subscribe(data => {
      this.books = data;
    })
  }

  showBook(id: number) {
    this.router.navigateByUrl("/show-book/"+id);
  }

  updateBook(id: number) {
    this.router.navigateByUrl("/update-book/"+id);
  }

  deleteBook(id: number) {
    this.router.navigateByUrl("/delete-book/"+id);
  }
  
}
