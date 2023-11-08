import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ViewService } from '../services/bi-view.service'; // Importeer de service indien nodig

@Component({
  selector: 'app-view-details',
  templateUrl: './view-details.component.html',
  styleUrls: ['./view-details.component.css']
})
export class ViewDetailsComponent implements OnInit {
  view: any; // Definieer de view-eigenschap

  constructor(private route: ActivatedRoute, private viewService: ViewService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.viewService.getView(id).subscribe((data) => {
        this.view = data;
      });
    }
  }
}

