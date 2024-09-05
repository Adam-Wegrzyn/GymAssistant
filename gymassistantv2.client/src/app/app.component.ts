import { Component, OnInit } from '@angular/core';
import { faDumbbell, faBook, faGear, faShapes } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  faDumbbell = faDumbbell;
  faBook = faBook;
  faGear = faGear;
  faShapes = faShapes;

  constructor() {}

  ngOnInit() {
  }


  title = 'gymassistantv2.client';
}
