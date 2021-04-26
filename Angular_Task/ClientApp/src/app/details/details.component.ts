import { Component, Inject } from '@angular/core';
import { DataService } from '../service/data.service';
import { Model } from '../model';


@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})

export class DetailsComponent {

  public summary: Model[];
  public selected?: Model;
  
  
  constructor(private dataService: DataService) {
    this.dataService.getData().subscribe((result: Model[]) => {
      this.summary = result;
      this.selected = this.summary[0];
    }, error => console.error(error));
  }


  onSelect(detail: Model): void {
    this.selected = detail;
  }

  updateData(item: Model) {
    this.dataService.updateData(item).subscribe((result: Model) => {
      this.selected = result;
      alert("Data saved successfully");
    }, error => console.error(error));
  }
}
