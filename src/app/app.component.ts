import { Component } from '@angular/core';
import Information from './models/Information';
import { InfornationService } from './services/infornation-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Information-client';
  /**
   *
   */
  // date:Date=new Date()
  // i:Information=new Information(0,"מרים","אמזלג",this.date,2,"מאוחדת");
  
  // constructor(public infornationService:InfornationService) {
  //   this.infornationService.deleteInformation(9).subscribe(r => {
      
  //     console.log(r);
  // });
    
  // }
}
