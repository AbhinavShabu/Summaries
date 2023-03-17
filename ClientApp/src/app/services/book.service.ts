import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookService { 

  _baseURL: string = "https://localhost:7021/api/Books";

  constructor(private http: HttpClient) { }

  getAllBooks(){    
    return this.http.get(this._baseURL + "/GetBooks")
  }

  addBook(book: any[]){
     return this.http.post("https://localhost:7021/api/Books/AddBook", book);
  }

  getBookById(id: number){
    return this.http.get(this._baseURL+"/SingleBook/"+id)
  }

  updateBook(book: any[]){
    return this.http.put(this._baseURL+"/UpdateBook", book);
    
  }
  
  deleteBook(id: number){
    return this.http.delete(this._baseURL+"/DeleteBook/"+id);
  }
}
