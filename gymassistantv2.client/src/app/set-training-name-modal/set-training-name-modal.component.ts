import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { NgbActiveModal, NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-set-training-name-modal',
  templateUrl: './set-training-name-modal.component.html',
  styleUrl: './set-training-name-modal.component.css'
})
export class SetTrainingNameModalComponent implements OnInit {
  constructor(public activeModal: NgbActiveModal) {} // Add the NgbModal service as a dependency

  ngOnInit(): void {

  }
  @Output() name = new EventEmitter<string>();
  @ViewChild('content') content: ElementRef;
  private modalRef: NgbModalRef;
  setName(name: string){
    this.name.emit(name);
    this.activeModal.close();
  }

  ngAfterViewInit (): void {
 // this.open(this.content)

  }

  // private openModal() {
  //   console.log(this.setNameModal.nativeElement);
  //   this.setNameModal.nativeElement.style.display = 'block';
  //   this.setNameModal.nativeElement.classList = 'modal fade show';
  //   this.setNameModal.nativeElement.setAttribute('aria-hidden', 'false');
  // }

  // private closeModal() {
  //   console.log(this.setNameModal.nativeElement);
  //   this.setNameModal.nativeElement.style.display = 'none';
  //   this.setNameModal.nativeElement.classList = 'modal fade';
  //   this.setNameModal.nativeElement.setAttribute('aria-hidden', 'true');
  // }
  
  // open(content: any) {
  //   this.modalRef = this.modalService.open(content);
  // }

}

