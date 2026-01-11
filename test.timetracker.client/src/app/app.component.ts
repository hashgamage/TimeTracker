import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Person, TaskItem, TimeEntry } from './models/time-tracker.models';
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule } from '@angular/forms';
import { TimeEntryService } from './services/time-entry.service';
import { CommonModule } from '@angular/common';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  standalone:false,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

//Data state
timeEntries:TimeEntry[]=[];
people:Person[]=[];
tasks:TaskItem[]=[];

//Form State
timeEntryForm:FormGroup;
isEditMode=false;
selectedEntryId:number |null=null;
isLoading=false;

statusMessage: { text: string, type: 'success' | 'danger' } | null = null;

  constructor(
    private http: HttpClient,
    private fb:FormBuilder,
    private timeEntryService:TimeEntryService
  ) {

    //Reactive Form Client Side Validation
    this.timeEntryForm= this.fb.group({
      personId:['',Validators.required],
      taskId:['',Validators.required],
      dateTimeEntry:['',Validators.required]
    });
  }

  ngOnInit() {
    this.loadInitialData();
  }

  loadInitialData(){
    this.timeEntryService.getPeople().subscribe(data=>this.people=data);
    this.timeEntryService.getTasks().subscribe(data=>this.tasks=data);
    this.loadEntries();
  }

  loadEntries()
  {
    this.isLoading=true;
    this.timeEntryService.getTimeEntries().subscribe({
      next:(data)=>{
        this.timeEntries=data;
        this.isLoading=false;
      },
      error:(err)=>console.error("Error fetching entries",err)
    });
  }

   
  onSubmit(){
    if(this.timeEntryForm.invalid){
      this.markFormGroupTouched(this.timeEntryForm);
      return;
    }

    const payload = this.timeEntryForm.value;

    if(this.isEditMode && this.selectedEntryId){
      this.timeEntryService.updateEntry(this.selectedEntryId,payload).subscribe({
        next: () => {
           this.showNotification('Time entry update successfully!', 'success');
          this.resetForm();
          this.loadEntries();
        },
         error: (err) => {
          this.showNotification('Error updating entry. Please try again.', 'danger');
        }
      });
    }else{
      this.timeEntryService.createEntry(payload).subscribe({
        next: () => {
          this.showNotification('Time entry recorded successfully!', 'success');
          this.resetForm();
          this.loadEntries();
        },
        error: (err) => {
          this.showNotification('Error saving entry. Please try again.', 'danger');
        }
      });
    }
  }

onEdit(entry: TimeEntry) {
  this.isEditMode = true;
  this.selectedEntryId = entry.id;

  // IMPORTANT: Fix for the blank date field
  // If entry.dateTimeEntry is "2023-10-01T14:30:00", we need "2023-10-01T14:30"
  let formattedDate = '';
  if (entry.dateAndTime) {
    formattedDate = new Date(entry.dateAndTime).toISOString().substring(0, 16);
  }

  this.timeEntryForm.patchValue({
    personId: entry.personId,
    taskId: entry.taskId,
    dateTimeEntry: formattedDate // Use the cleaned string
  });
}

  onDelete(id:number){
    if(confirm('Are you sure you want to delete this time entry?')){
      this.timeEntryService.deleteEntry(id).subscribe(()=>{
        this.showNotification('Time entry deleted successfully!', 'success');
        this.loadEntries();
      })
    }
  }
 

  resetForm() {
    this.isEditMode = false;
    this.selectedEntryId = null;
    
   // Reset the form to the placeholder values (empty strings)
  this.timeEntryForm.reset({
    personId: '',
    taskId: '',
    dateTimeEntry: ''
  });
  }

  // Helper to trigger validation styling on submit attempt
  private markFormGroupTouched(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach(control => {
      control.markAsTouched();
    });
  }

  private showNotification(text:string,type: 'success' | 'danger'){
    this.statusMessage={text,type};
    setTimeout(()=> this.statusMessage = null,3000)
  }

  title = 'test.timetracker.client';
}
