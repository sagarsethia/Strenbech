import { Component, ViewChild, ElementRef } from '@angular/core';
import { UploadService } from '../upload.service';
import { ICsvFileUpload } from '../../model/csvRecords';
@Component({
  selector: 'app-fileupload',
  templateUrl: './fileupload.component.html',
  styleUrls: ['./fileupload.component.css']
})
export class FileuploadComponent {
  @ViewChild('fileUpload', { static: false })
  fileUpload: ElementRef;
  files = [];
  processedList: ICsvFileUpload[];
  rejectedList: ICsvFileUpload[];
  constructor(private uploadService: UploadService) { }

  uploadFile(file) {
    const formData = new FormData();
    formData.append('file', file);
    this.uploadService.upload(formData).subscribe(
      (response) => {
        if (response) {
          this.processedList = [...response['lstProcessedRecords']];
          this.rejectedList = [...response['lstRejectedRecords']];
          this.fileUpload.nativeElement = null;
        }
      },
      err=>{
        console.log(err);
      }
    );
  }

  onClick() {
    const fileUpload = this.fileUpload.nativeElement;
    this.uploadFile(fileUpload.files[0]);
  }

}
