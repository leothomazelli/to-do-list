import { Injectable } from '@angular/core';
import { ApiService } from '../api/api.service';
import { Observable } from 'rxjs';
import { ServiceResponse } from 'src/app/models/ServiceResponse';
import { Tasks } from 'src/app/models/Tasks';
import { DatePipe, formatDate } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  constructor(private apiService: ApiService, private datePipe: DatePipe) {}

  /**
   * Get all tasks registered in the database.
   * @returns an observable that returns a ServiceResponse<Tasks[]> with the result for the operation.
   */
  getAll(): Observable<ServiceResponse<Tasks[]>> {
    return this.apiService.get('Tasks', 'GetAll');
  }

  /**
   * Get a task based on the id received.
   * @param id is id from the task that's being returned.
   * @returns an observable that returns a ServiceResponse<Tasks> with the result for the operation.
   */
  getTaskById(id: number): Observable<ServiceResponse<Tasks>> {
    return this.apiService.get('Tasks', `GetById/${id}`);
  }

  /**
   * Create a new task based on the object received.
   * @param data is the Task object that's being added.
   * @returns an observable that returns a ServiceResponse<Tasks> with the result for the operation.
   */
  addTask(data: Tasks): Observable<ServiceResponse<Tasks>> {
    return this.apiService.post(this.normalizeData(data), 'Tasks', 'Add');
  }

  /**
   * Edit a task based on the object received.
   * @param data is the Task object that's being edited.
   * @returns an observable that returns a ServiceResponse<Tasks> with the result for the operation.
   */
  editTask(data: Tasks): Observable<ServiceResponse<Tasks>> {
    return this.apiService.put(this.normalizeData(data), 'Tasks', 'Update');
  }

  /**
   * Delete a task based on the id received.
   * @param id is the id from the task that's being deleted.
   * @returns an observable that returns a ServiceResponse<Tasks> with the result for the operation.
   */
  deleteTask(id: number): Observable<ServiceResponse<Tasks>> {
    return this.apiService.delete(id, 'Tasks', 'Delete');
  }

  /**
   * Method that cast, format and transforms user object data.
   * @param data is the user object that's going to be affected.
   * @returns a data object with affected data.
   */
  private normalizeData(data: Tasks): Tasks {
    data.userId = Number(data.userId);
    data.status = Number(data.status);
    data.createdAt = <Date>(
      (this.datePipe.transform(data.createdAt, 'yyyy-MM-dd') as any)
    );
    data.dueDate = <Date>(
      (this.datePipe.transform(data.dueDate, 'yyyy-MM-dd') as any)
    );
    return data;
  }
}
