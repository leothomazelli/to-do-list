import { formatDate } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StatusEnum } from 'src/app/enum/StatusEnum';
import { ServiceResponse } from 'src/app/models/ServiceResponse';
import { Tasks } from 'src/app/models/Tasks';
import { User } from 'src/app/models/User';
import { TasksService } from 'src/app/services/tasks/tasks.service';
import { UserService } from 'src/app/services/user/user.service';

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
  users: User[] = [];

  /**
   *
   */
  constructor(
    private userService: UserService,
    private tasksService: TasksService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initializeUsers();
    this.createTaskForm();
  }

  /**
   *
   */
  initializeUsers(): void {
    this.userService.getAll().subscribe((response: ServiceResponse<User[]>) => {
      this.users = response.data;
    });
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
