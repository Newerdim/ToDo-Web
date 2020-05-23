import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})
export class TaskListComponent implements OnInit {
  taskLists: any[];
  display: any[];
  private sub: any;
  private header: string;

  constructor(private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.router.events.subscribe(val => {
      this.taskLists[0].header = this.header;
      this.setHeader();
    });

    this.setHeader();

    this.display = ['time', 'date'];

    this.taskLists = [{
      header: this.header,
      tasks: [
        {
          title: 'task1',
          date: new Date(),
          completed: true
        },
        {
          title: 'task2',
          date: new Date()
        },
        {
          title: 'task3',
          important: true
        },
        {
          title: 'task4',
          date: new Date()
        }
      ]
    }];
  }

  setHeader() {
    this.sub = this.route.params.subscribe(params => {
      this.header = params.name;
    });
  }

}
