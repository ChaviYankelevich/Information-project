import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import Information from '../models/Information';
import { LocalStrageService } from '../services/local-strage.service';

@Component({
  selector: 'app-instructions',
  templateUrl: './instructions.component.html',
  styleUrls: ['./instructions.component.css']
})
export class InstructionsComponent implements OnInit,OnDestroy{
  /**
   *
   */
  sub: Subscription;
  information:Information;
  constructor(public localStorage:LocalStrageService) {  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
  ngOnInit(): void {
    this.localStorage.currentUser.next(this.localStorage.getFromStorage("user"))
    this.sub = this.localStorage.currentUser.subscribe(data => { this.information = data })
    console.log(this.information)
  }

}
