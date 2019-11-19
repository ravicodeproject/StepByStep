import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees() {
    this.http.get('https://localhost:5001/api/employees').subscribe(
      response => {
        this.employees = response;
      },
      error => {
        console.log(error);
      }
    );
  }
}
