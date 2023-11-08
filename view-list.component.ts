// view-list.component.ts
import { Component, OnInit } from '@angular/core';
import { ViewService } from '../services/bi-view.service';
import { View } from '../models/view.model';

@Component({
  selector: 'app-view-list',
  templateUrl: './view-list.component.html',
  styleUrls: ['./view-list.component.css']
})
export class ViewListComponent implements OnInit {
  views: View[] = [];

  constructor(private viewService: ViewService) { }

  ngOnInit(): void {
    this.loadViews();
  }

  loadViews(): void {
    this.viewService.getViews().subscribe(views => {
      this.views = views;
    });
  }

  deleteView(id: string): void {
    if (confirm('Are you sure you want to delete this view?')) {
      this.viewService.deleteView(id).subscribe(() => {
        this.loadViews();
      });
    }
  }
}
