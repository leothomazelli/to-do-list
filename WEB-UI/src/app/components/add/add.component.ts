import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Tasks } from 'src/app/models/Tasks';
import { TasksService } from 'src/app/services/tasks/tasks.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss'],
})
export class AddComponent {
  btnAction = 'Add';
  title = 'Add Task';

  constructor(private tasksService: TasksService, private router: Router) {}

  /**
   *
   * @param task
   */
  addTask(task: Tasks) {
    this.tasksService.addTask(task).subscribe((response) => {
      this.router.navigate(['/']);
    });
  }
}
