import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person, TaskItem, TimeEntry } from '../models/time-tracker.models';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root'
})
export class TimeEntryService {

  private baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  //Get Read only Lookups
  getPeople():Observable<Person[]>{
    return this.http.get<Person[]>(`${this.baseUrl}/People`);
  }

  getTasks():Observable<TaskItem[]>{
    return this.http.get<TaskItem[]>(`${this.baseUrl}/Tasks`);
  }

  //Get all Time Entries
  getTimeEntries():Observable<TimeEntry[]>{
    return this.http.get<TimeEntry[]>(`${this.baseUrl}/TimeEntries`);
  }

  //CURD Operations for TimeEntry

  createEntry(entry:any) : Observable<any>{
    return this.http.post(`${this.baseUrl}/TimeEntries`,entry);
  }

  updateEntry(id:number,entry:any):Observable<any>{
    return this.http.put(`${this.baseUrl}/TimeEntries/${id}`,entry);
  }

  deleteEntry(id:number):Observable<any>{
    return this.http.delete(`${this.baseUrl}/TimeEntries/${id}`);
  }
}
