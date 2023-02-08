import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import Chaild from '../models/Chaild';
import Information from '../models/Information';

@Injectable({
  providedIn: 'root'
})
export class LocalStrageService {
  currentUser = new BehaviorSubject<Information>(null);
  currentChaildren=new BehaviorSubject<Chaild[]>(null);
  constructor() {  }
  setInStorage(user:Information,chaildren:Chaild[]) {
      localStorage.setItem("currentUser", JSON.stringify(user));
      localStorage.setItem("currentChaildren", JSON.stringify(chaildren));

}
getFromStorage(identifier:string) {
  let u =identifier=="user"? localStorage.getItem("currentUser"):localStorage.getItem("currentChaildren");
  if (!u)
    return null;
  return JSON.parse(u);
}
removeFromStorage() {
  localStorage.removeItem("currentUser");
  localStorage.removeItem("currentChaildren");

}
}
