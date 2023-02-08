import { Injectable } from '@angular/core';
import { Subscription } from 'rxjs';
import Information from '../models/Information';
import { LocalStrageService } from './local-strage.service';
import * as FileSaver from 'file-saver';
import Chaild from '../models/Chaild';
@Injectable({
  providedIn: 'root'
})
export class ExelService {
sub:Subscription;
information:Information;
processedData:Information[]=[];
processedData2:Chaild[]=[];
chaildren:Chaild[];
  constructor(public localStorage:LocalStrageService) { }
  async generateExcel() {
    this.localStorage.currentUser.next(this.localStorage.getFromStorage("user"))
    this.sub = this.localStorage.currentUser.subscribe(data => { this.information = data })
    const data = this.information;
      this.processedData.push(this.information);
   
    const dataParsed = JSON.stringify(this.processedData);
    const JSobj = JSON.parse(dataParsed);
    console.log(JSobj);
    const header = Object.keys(data);
    const csv = JSobj.map((row: Information) =>
      header
        .map((fieldName) => row[fieldName as keyof Information])
        .join('\t')
    );
    csv.unshift(header.join('\t'));
    const csvArray = csv.join('\r\n');
    if(this.chaildren!=null){
      this.localStorage.currentChaildren.next(this.localStorage.getFromStorage("chaild"))
    this.sub = this.localStorage.currentChaildren.subscribe(data => { this.chaildren = data })
    this.processedData2=this.chaildren;
    const dataParsed2 = JSON.stringify(this.processedData2);
    const JSobj2 = JSON.parse(dataParsed2);
    const header2 = Object.keys(this.processedData2[0]);
    const csv2 = JSobj2.map((row: Chaild) =>
    header2
  .map((fieldName) => row[fieldName as keyof Chaild])
  .join('\t')
   );

   csv2.unshift(header2.join('\t'));
  const csvArray2 = csv2.join('\r\n');

  const cvsFina=[csv,csv2];
 const cvsFinal= cvsFina.join('\r\n');
 const a = document.createElement('a');
    const blob = new Blob([cvsFinal], { type: 'application/vnd.ms-excel;charset=utf-8' });
     FileSaver.saveAs(blob, 'form.xls');
    }
    else
    {
      const a = document.createElement('a');
    const blob = new Blob([csvArray], { type: 'application/vnd.ms-excel;charset=utf-8' });
    FileSaver.saveAs(blob, 'form.xls');

  }
    
   
  }
}


