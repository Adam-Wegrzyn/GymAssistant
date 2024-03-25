import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Training } from 'src/app/domain/Training';

@Component({
  selector: 'app-delete-pop-up',
  standalone: true,
  imports: [],
  templateUrl: './delete-pop-up.component.html',
  styleUrl: './delete-pop-up.component.css'
})
export class DeletePopUpComponent implements OnInit {

    @Input() training: Training;
    @Output() isConfirmed: EventEmitter<Training> = new EventEmitter<Training>;
    @ViewChild('closeBtn') closeBtn: ElementRef;

    ngOnInit(): void {
      console.log(this.training);
    }
  public confirm(): void {
    this.isConfirmed.emit(this.training);
    this.closeBtn.nativeElement.click();
  }
}
