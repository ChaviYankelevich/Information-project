import { Component, OnDestroy, OnInit } from '@angular/core';
import Information from '../models/Information';
import {Form, FormControl,ReactiveFormsModule, Validators} from '@angular/forms';
import {ThemePalette} from '@angular/material/core';
import Chaild from '../models/Chaild';
import { InfornationService } from '../services/infornation-service';
import { ChaildrenService } from '../services/chaildren-service';
import { LocalStrageService } from '../services/local-strage.service';
import { Subscription } from 'rxjs';
import Swal from 'sweetalert2'; 
import { ExelService } from '../services/exel.service';
// import swal from 'sweetalert';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit,OnDestroy{
information:Information=new Information(null,null,null,null,null,null);
colorControl = new FormControl('primary' as ThemePalette);
select:string;
hmo:string;
numChildren:number;
arrNum:number[]=[];
chaildren:Chaild[]=[];
sub: Subscription;
myForm:any;
hmoArr:string[]=["מכבי","מאוחדת","כללית","לאומית"]
/**
 *
 */
constructor(public informationService:InfornationService,public chaildrenService:ChaildrenService,public localStorage:LocalStrageService,public exelService:ExelService){ }
  ngOnDestroy(): void {
    this.sub.unsubscribe();

  }
  ngOnInit(): void {
    this.localStorage.currentUser.next(this.localStorage.getFromStorage("user"))
    this.sub = this.localStorage.currentUser.subscribe(data => {data!=null? this.information = data :0})
    this.localStorage.currentChaildren.next(this.localStorage.getFromStorage("chaildren"))
    // this.sub = this.localStorage.currentChaildren.subscribe(data => {data!=null? this.numChildren = data.length:0})
   if(this.information.eMOF!=null)
    this.select=this.information.eMOF==1?"male":"female";
    // this.showChildren()
    this.sub = this.localStorage.currentChaildren.subscribe(data => {data!=null? this.chaildren = data:0}) ;

    console.log(this.chaildren,"chaildren");

    for(let i=0;i<this.chaildren.length;i++)
    {
      this.arrNum.push(i);
    }
    console.log(this.arrNum);

  }
showChildren(){
  console.log(this.numChildren,this.chaildren)
  for(let i=this.chaildren.length-1;i<this.numChildren;i++)
  {
    this.chaildren.push(new Chaild(null,null,null,null));
    this.arrNum.push(i+1);
  }
  console.log(this.arrNum);
this.chaildren.splice(this.numChildren);
this.arrNum.splice(this.numChildren);
  this.setInStorage()
}
setInStorage()
{
 console.log(this.chaildren,"cccccccccccccccccccc") 
 this.localStorage.currentChaildren.next(this.chaildren);
  this.localStorage.setInStorage(this.information,this.chaildren)
  this.localStorage.currentUser.next(this.information);
  this.localStorage.setInStorage(this.information,this.chaildren)
 
}
clean(form){
  Swal.fire({
    title: 'האם אתה בטוח?',
    text: "אחרי הניקוי הטופס ימחק ולא תהיה אפשרות שחזור!",
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'כן!',
    cancelButtonText: 'ביטןל!',
  })
  .then((willDelete) => {
    if (willDelete.isConfirmed) {
      form.reset();
      this.localStorage.currentUser.next(this.information);
  this.localStorage.removeFromStorage()
  this.select=null;
  this.arrNum=[];
    } 
  });
}
save(form){
this.information.eMOF=this.select=="זכר"?1:2;
this.informationService.addInformation(this.information);
for(let i=0;i<this.numChildren;i++)
  {
    this.chaildren[i].parentId=this.information.id;
    
  }
this.chaildrenService.addChaild(this.chaildren);
Swal.fire({
  title: "האם ברצונך לקבל את הנתונים בקובץ אקסל?",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonText: 'כן!',
  cancelButtonText: 'לא!',
}).then((downLowd) => {
    if (downLowd.isConfirmed) {
    this.exelService.generateExcel();
    Swal.fire({
    title: "עבודה טובה!",
    text: "מילית בהצלחה את הטופס!",
    icon: "success",
   
  });
    } 
    else{
      Swal.fire({
        title: "עבודה טובה!",
        text: "מילית בהצלחה את הטופס!",
        icon: "success",
       
      });
    }
  });

  form.reset();
  this.localStorage.currentUser.next(this.information);

  
  this.localStorage.removeFromStorage();
  this.select=null;
}
}
