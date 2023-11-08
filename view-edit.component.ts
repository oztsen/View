// view-edit.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ViewService } from '../services/bi-view.service';
import { View } from '../models/view.model';

@Component({
  selector: 'app-view-edit',
  templateUrl: './view-edit.component.html',
  styleUrls: ['./view-edit.component.css']
})
export class ViewEditComponent implements OnInit {
  view: View = {
    id: '',
    viewName: '',
    databaseName: null,
    userName: null,
    password: null,
    customerKey: null,
    orderId: null,
    reportName: null,
    viewType: null,
    parameters: null,
    sampleCall: null
  };

  constructor(
    private viewService: ViewService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.viewService.getView(id).subscribe(view => {
        this.view = view;
      });
    }
  }

  save(): void {
    if (!this.view.id) {
      this.viewService.createView(this.view).subscribe(createdView => {
        this.router.navigate(['/views', createdView.id]);
      });
    } else {
      this.viewService.updateView(this.view).subscribe(() => {
        this.goBack();
      });
    }
  }

  delete(): void {
    if (this.view.id) {
      this.viewService.deleteView(this.view.id).subscribe(() => {
        this.goBack();
      });
    }
  }

  cancel(): void {
    this.goBack();
  }

  private goBack(): void {
    this.router.navigate(['/views']);
  }
}
