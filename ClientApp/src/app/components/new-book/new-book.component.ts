import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css']
})
export class NewBookComponent {

  // There is a chance of error here. If occured add FormGroup instead of any.
  addBookForm: any = {
    id: null,
    title: "",
    author: "",
    description: "",
    rate: null,
    dateStart: null,
    dateRead: null,
  }
  fb: any;
  showError: boolean = false;

  // The code below is inside the constructor
  //  private fb: FormBuilder
  constructor(private service: BookService,  private router: Router) { }

  onSubmit(){
    console.log(this.addBookForm.title);
    console.log(this.addBookForm.author);
    console.log(this.addBookForm.description);
    console.log(this.addBookForm.rate);
    this.service.addBook(this.addBookForm).subscribe({
      next: (res: any) => {
        console.log(res);
        this.router.navigateByUrl("/books");
      }
     })
    //  this.service.addBook(this.addBookForm).subscribe(error =>{
    //   this.showError = true;
    //  })
  }
}
