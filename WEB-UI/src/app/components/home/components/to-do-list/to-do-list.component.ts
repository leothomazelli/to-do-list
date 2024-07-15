import { Component, OnInit } from '@angular/core';
import {
  CdkDragDrop,
  CdkDrag,
  CdkDropList,
  moveItemInArray,
  transferArrayItem,
} from '@angular/cdk/drag-drop';
import { NgFor } from '@angular/common';
import { RouterLink } from '@angular/router';
import { TasksService } from 'src/app/services/tasks/tasks.service';
import { ServiceResponse } from 'src/app/models/ServiceResponse';
import { Tasks } from 'src/app/models/Tasks';
import { StatusEnum } from 'src/app/enum/StatusEnum';

@Component({
  selector: 'app-to-do-list',
  templateUrl: './to-do-list.component.html',
  styleUrls: ['./to-do-list.component.scss'],
  standalone: true,
  imports: [NgFor, RouterLink, CdkDropList, CdkDrag],
})
export class ToDoListComponent implements OnInit {
  private _tasks: Tasks[] = [];
  todo: Tasks[] = [];
  doing: Tasks[] = [];
  done: Tasks[] = [];

  constructor(private tasksService: TasksService) {}

  ngOnInit(): void {
    this.tasksService
      .getAll()
      .subscribe((response: ServiceResponse<Tasks[]>) => {
        this._tasks = response.data;
        this.todo = this.getFilteredTasks(StatusEnum.ToDo);
        this.doing = this.getFilteredTasks(StatusEnum.Doing);
        this.done = this.getFilteredTasks(StatusEnum.Done);
      });
  }

  /**
   * Method responsible for drag and drop behavior.
   * @param event is the task card that's being moved.
   */
  drop(event: CdkDragDrop<Tasks[]>) {
    if (event.previousContainer != event.container) {
      let task = event.previousContainer.data[event.previousIndex];
      let newStatus = Number(event.container.element.nativeElement.id);
      task.status = newStatus;
      this.tasksService.editTask(task).subscribe();
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
    }
  }

  /**
   * Method is responsible of filtering the tasks.
   * @param status is the StatusEnum object.
   * @returns filtered task object.
   */
  private getFilteredTasks(status: StatusEnum): Tasks[] {
    return this._tasks.filter((task: Tasks) => task.status === status);
  }
}
