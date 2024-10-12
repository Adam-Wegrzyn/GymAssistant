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

    @Input() entity: any;
    @Output() isConfirmed: EventEmitter<boolean> = new EventEmitter<boolean>;
    @ViewChild('closeBtn') closeBtn: ElementRef;

    ngOnInit(): void {
    }
  public confirm(): void {
    this.isConfirmed.emit();
    this.closeBtn.nativeElement.click();
  }
}
