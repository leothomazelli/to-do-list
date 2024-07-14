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
   *
   * @returns
   */
  getAll(): Observable<ServiceResponse<Tasks[]>> {
    return this.apiService.get('Tasks', 'GetAll');
  }

  /**
   *
   * @param id
   * @returns
   */
  getTaskById(id: number): Observable<ServiceResponse<Tasks>> {
    return this.apiService.get('Tasks', `GetById/${id}`);
  }

  /**
   *
   * @param data
   * @returns
   */
  addTask(data: Tasks): Observable<ServiceResponse<Tasks>> {
    return this.apiService.post(this.normalizeData(data), 'Tasks', 'Add');
  }

  /**
   *
   * @param data
   * @returns
   */
  editTask(data: Tasks): Observable<ServiceResponse<Tasks>> {
    return this.apiService.put(this.normalizeData(data), 'Tasks', 'Update');
  }

  /**
   *
   * @param id
   * @returns
   */
  deleteTask(id: number): Observable<ServiceResponse<Tasks>> {
    return this.apiService.delete(id, 'Tasks', 'Delete');
  }

  /**
   *
   * @param data
   * @returns
   */
  private normalizeData(data: Tasks): Tasks {
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
