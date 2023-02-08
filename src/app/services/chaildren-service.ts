import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Chaild from '../models/Chaild';

@Injectable({
  providedIn: 'root'
})
export class ChaildrenService {

  constructor(public http:HttpClient) { }
  routeUrl = `https://localhost:7014/api/Chaild`;
 getAllChaild() {
   return this.http.get<Chaild[]>(`${this.routeUrl}`);//מחזיר הבטחה שעוד מעט יגיע מערך של רולים
 }
 getChaildById(id:number){
   return this.http.get<Chaild>(`${this.routeUrl}/${id}`);
 }
 addChaild(chaild:Chaild){
   return this.http.post<Chaild>(`${this.routeUrl}`,chaild);
 }
 deleteChaild(id:number){
   return this.http.delete<Chaild>(`${this.routeUrl}/ ${id}`);
 }
 putRecipe(chaild:Chaild){
   return this.http.put<Chaild>(`${this.routeUrl}/${chaild.id}`,chaild);
 }
}
