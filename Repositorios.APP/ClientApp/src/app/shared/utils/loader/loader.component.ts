import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { LoaderService } from './loader.service';

@Component({
  selector: 'app-loader',
  template: '<mat-progress-bar *ngIf="loading | async" mode="query"></mat-progress-bar>',
  styleUrls: ['./loader.component.css']
})
export class LoaderComponent implements OnInit {

  public loading: Subject<boolean> = this.loaderService.isLoading;

  constructor(private loaderService: LoaderService) { }

  ngOnInit() { }

}
