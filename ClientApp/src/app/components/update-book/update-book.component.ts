import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {
  updateBookForm: any = {
    id: null,
    title: "",
    author: "",
    description: "",
    rate: null,
    dateStart: null,
    dateRead: null,
  }

  constructor(private service: BookService,  private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void { 
    this.service.getBookById(this.route.snapshot.params.id).subscribe({
    next: (res:any) => {
      this.updateBookForm = res;
    }
    })
  }

  onSubmit(){
    this.service.updateBook(this.updateBookForm.id,this.updateBookForm).subscribe({
      next: (res: any) => {
        console.log(res);
        this.router.navigateByUrl("/books");
      }

    })    
}
}
