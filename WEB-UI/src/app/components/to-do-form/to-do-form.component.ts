import { formatDate } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StatusEnum } from 'src/app/enum/StatusEnum';
import { Tasks } from 'src/app/models/Tasks';
import { TasksService } from 'src/app/services/tasks/tasks.service';

@Component({
  selector: 'app-to-do-form',
  templateUrl: './to-do-form.component.html',
  styleUrls: ['./to-do-form.component.scss'],
})
export class ToDoFormComponent {
  @Output() onSubmit = new EventEmitter<Tasks>();
  @Input() btnAction!: string;
  @Input() title!: string;
  @Input() taskData: Tasks | null = null;
  taskForm!: FormGroup;

  /**
   *
   */
  constructor(private tasksService: TasksService, private router: Router) {}

  ngOnInit(): void {
    this.createTaskForm();
  }

  /**
   *
   */
  createTaskForm() {
    this.taskForm = new FormGroup({
      id: new FormControl(this.taskData ? this.taskData.id : 0),
      title: new FormControl(this.taskData ? this.taskData.title : '', [
        Validators.required,
      ]),
      summary: new FormControl(this.taskData ? this.taskData.summary : '', [
        Validators.required,
      ]),
      status: new FormControl(
        this.taskData ? this.taskData.status : StatusEnum.ToDo,
        [Validators.required]
      ),
      createdAt: new FormControl(
        this.taskData
          ? formatDate(this.taskData.createdAt, 'yyyy-MM-dd', 'en-US')
          : formatDate(Date.now(), 'yyyy-MM-dd', 'en-US'),
        [Validators.required]
      ),
      dueDate: new FormControl(
        this.taskData
          ? formatDate(this.taskData.dueDate, 'yyyy-MM-dd', 'en-US')
          : formatDate(Date.now(), 'yyyy-MM-dd', 'en-US'),
        [Validators.required]
      ),
      userId: new FormControl(this.taskData ? this.taskData.userId : 0),
    });
  }

  submit(task: Tasks) {
    this.onSubmit.emit(this.taskForm.value);
  }

  delete() {
    if (this.taskData == null) {
      return;
    }

    this.tasksService.deleteTask(this.taskData.id).subscribe((response) => {
      this.router.navigate(['/']);
    });
  }
}
