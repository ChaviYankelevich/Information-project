import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Information from '../models/Information';

@Injectable({
  providedIn: 'root'
})
export class InfornationService {

  constructor(public http:HttpClient) { }
   routeUrl = `https://localhost:7014/api/Information`;
  getAllInformation() {
    return this.http.get<Information[]>(`${this.routeUrl}`);//מחזיר הבטחה שעוד מעט יגיע מערך של רולים
  }
  getInformationById(id:number){
    return this.http.get<Information>(`${this.routeUrl}/${id}`);
  }
  addInformation(i:Information){
    return this.http.post<Information>(`${this.routeUrl}`,i);
  }
  deleteInformation(id:number){
    return this.http.delete<Information>(`${this.routeUrl}/ ${id}`);
  }
  putRecipe(i:Information){
    return this.http.put<Information>(`${this.routeUrl}/${i.id}`,i);
  }
}
