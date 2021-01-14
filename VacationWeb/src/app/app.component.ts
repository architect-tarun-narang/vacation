import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  dateFrom: string;
  dateTo: string;
  
  addDateFrom(dateFrom: string) {
    this.dateFrom = dateFrom;
  }
  addDateTo(dateTo: string) {
    this.dateTo = dateTo;
  }

}
