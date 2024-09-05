import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { interval } from 'rxjs';

@Component({
  selector: 'app-training-active',
  templateUrl: './training-active.component.html',
  styleUrl: './training-active.component.css'
})
export class TrainingActiveComponent implements OnInit {
  trainingId: number;
  showTimer: number;
  durationOfTraining: number;

  constructor(private route: ActivatedRoute,
    private el: ElementRef,
    private renderer: Renderer2
  ) {}
  
  ngOnInit(): void {
    this.route.queryParams.subscribe(params =>{this.trainingId = params ["id"]; })
    this.startTimer();
    console.log(this.trainingId);
  }

  startTimer() {
    interval(1000)
    .subscribe(seconds => {
      this.showTimer = seconds;
      this.durationOfTraining = seconds;  
    }
    )
  }


  setComplete(idExercise: number, idSet: number) {
    const rowId = `setRow${idExercise}-${idSet}`;
    const chkId = `chkDone${idExercise}-${idSet}`;
    const row = this.el.nativeElement.querySelector(`#${rowId}`);
    const chk = this.el.nativeElement.querySelector(`#${chkId}`);
    const allSets = this.el.nativeElement.querySelectorAll(`.chkDone${idExercise}`);
    if(row){
      if(chk.checked){
        this.renderer.setStyle(row, 'background-color', '#80ff00');
      }
      else {
        this.renderer.setStyle(row, 'background-color', 'white');
      
    }
    const exercise = this.el.nativeElement.querySelector(`#exercise${idExercise}`);
    if(AreAllSetsChecked(allSets)){
      this.renderer.setStyle(exercise, 'background-color', '#80ff00');
    }
    else{
      this.renderer.setStyle(exercise, 'background-color', 'white');
    };
    let completedCount = CountCompletedSets(allSets);
    
    var showCountSets = this.el.nativeElement.querySelector(`#showCountSets${idExercise}`);
    showCountSets.innerHTML = `Completed sets: ${completedCount}/${allSets.length}`;
    if(completedCount == allSets.length){
    }    
  }}
  
  }
  
  function AreAllSetsChecked(allSets: any): boolean {
  for(let i=0; i<allSets.length; i++){
    if(!allSets[i].checked){
      return false;
    }
  }
  return true
  }
  
  
  function CountCompletedSets(allSets: any): number {
  let count = 0;
  for (let i = 0; i < allSets.length; i++ ){
    if(allSets[i].checked) count++;
  }
  return count;
  }


