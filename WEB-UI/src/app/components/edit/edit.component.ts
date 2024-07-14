import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceResponse } from 'src/app/models/ServiceResponse';
import { Tasks } from 'src/app/models/Tasks';
import { TasksService } from 'src/app/services/tasks/tasks.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss'],
})
export class EditComponent implements OnInit {
  btnAction: string = 'Save';
  title: string = 'Edit Task';
  taskData: Tasks | null = null;

  /**
   *
   */
  constructor(
    private tasksService: TasksService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initializeTaskData();
  }

  /**
   *
   */
  initializeTaskData() {
    this.tasksService
      .getTaskById(Number(this.activatedRoute.snapshot.paramMap.get('id')))
      .subscribe((response: ServiceResponse<Tasks>) => {
        this.taskData = response.data;
      });
  }

  /**
   *
   * @param task
   */
  editTask(task: Tasks) {
    this.tasksService.editTask(task).subscribe((response) => {
      this.router.navigate(['/']);
    });
  }
}
