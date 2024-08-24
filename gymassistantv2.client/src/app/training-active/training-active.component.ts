import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-training-active',
  templateUrl: './training-active.component.html',
  styleUrl: './training-active.component.css'
})
export class TrainingActiveComponent implements OnInit {
  trainingId: number;

  constructor(private route: ActivatedRoute) {}
  
  ngOnInit(): void {
    this.route.queryParams.subscribe(params =>{this.trainingId = params ["id"]; })
    console.log(this.trainingId);
  }

}
