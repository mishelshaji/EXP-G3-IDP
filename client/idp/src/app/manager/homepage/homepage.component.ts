import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css'],
})
export class HomepageComponent implements OnInit {
  counters = [
    { name: 'Total Empolyees', count: 1000, limit: 1500 },
    { name: 'Total Created IDP', count: 0, limit: 126 },
    { name: 'Total Pending IDP', count: 0, limit: 600 },
    { name: 'Total Completed IDP', count: 0, limit: 660 },
  ];

  intervalIds: any[] = [];

  ngOnInit() {
    this.startCounters();
  }

  startCounters() {
    for (let i = 0; i < this.counters.length; i++) {
      this.intervalIds[i] = setInterval(() => {
        if (this.counters[i].count === this.counters[i].limit) {
          clearInterval(this.intervalIds[i]);
        } else {
          this.counters[i].count++;
        }
      }, 0.01);
    }
  }

  messages = [
    {
      sender: 'John Doe',
      subject: 'Important Message',
      text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
    },
    {
      sender: 'Jane Doe',
      subject: 'Urgent Message',
      text: 'Praesent vestibulum dictum dui, eu gravida justo placerat a.',
    },
    {
      sender: 'Bob Smith',
      subject: 'Follow-Up',
      text: 'Vivamus eget velit vel libero mollis consectetur.',
    },
  ];

  users = [
    {
      name: 'John Doe',
      profile: 'https://picsum.photos/100',
      department: 'Sales',
      objective: 'Increase sales by 10%',
      idp: 'IMP-ID-200828-2022',
      remark: 'pending',
    },
    {
      name: 'Jane Doe',
      profile: 'https://picsum.photos/100',
      department: 'Marketing',
      objective: 'Develop a new marketing strategy',
      idp: 'IMP-ID-200808-2022',
      remark: 'pending',
    },
    {
      name: 'Jim Smith',
      profile: 'https://picsum.photos/100',
      department: 'IT',
      objective: 'Improve system performance by 20%',
      idp: 'IMP-ID-200908-2022',
      remark: 'pending',
    },
    {
      name: 'John Doe',
      profile: 'https://picsum.photos/100',
      department: 'Sales',
      objective: 'Increase sales by 10%',
      idp: 'IMP-ID-200828-2022',
      remark: 'completed  ',
    },
    {
      name: 'Jane Doe',
      profile: 'https://picsum.photos/100',
      department: 'Marketing',
      objective: 'Develop a new marketing strategy',
      idp: 'IMP-ID-200808-2022',
      remark: 'pending',
    },
    {
      name: 'Jim Smith',
      profile: 'https://picsum.photos/100',
      department: 'IT',
      objective: 'Improve system performance by 20%',
      idp: 'IMP-ID-200908-2022',
      remark: 'pending',
    },
    {
      name: 'John Doe',
      profile: 'https://picsum.photos/100',
      department: 'Sales',
      objective: 'Increase sales by 10%',
      idp: 'IMP-ID-200828-2022',
      remark: 'completed',
    },
    {
      name: 'Jane Doe',
      profile: 'https://picsum.photos/100',
      department: 'Marketing',
      objective: 'Develop a new marketing strategy',
      idp: 'IMP-ID-200808-2022',
      remark: 'pending',
    },
    {
      name: 'Jim Smith',
      profile: 'https://picsum.photos/100',
      department: 'IT',
      objective: 'Improve system performance by 20%',
      idp: 'IMP-ID-200908-2022',
      remark: 'not completed',
    },
    {
      name: 'John Doe',
      profile: 'https://picsum.photos/100',
      department: 'Sales',
      objective: 'Increase sales by 10%',
      idp: 'IMP-ID-200828-2022',
      remark: 'pending',
    },
    {
      name: 'Jane Doe',
      profile: 'https://picsum.photos/100',
      department: 'Marketing',
      objective: 'Develop a new marketing strategy',
      idp: 'IMP-ID-200808-2022',
      remark: 'pending',
    },
    {
      name: 'Jim Smith',
      profile: 'https://picsum.photos/100',
      department: 'IT',
      objective: 'Improve system performance by 20%',
      idp: 'IMP-ID-200908-2022',
      remark: 'not completed',
    },
  ];

  constructor() {}

  lastMessage(message: any) {
    return this.messages.indexOf(message) === this.messages.length - 1;
  }

  
  selectedStatus = 'all';
}
