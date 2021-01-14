import { OnInit, Component } from '@angular/core';
import { CoreService } from '../core/core.service';
import { IEmployee } from '../shared/interfaces/employee.interface';
import { ConstantsMaster } from '../shared/constants/constantsMaster';
import { IEmployeeViewDetails } from '../shared/interfaces/employeeViewDetails.interface';
import { IEmployeeDataDetails } from '../shared/interfaces/employeeDataDetails.interface';
import { EmployeeHelper } from '../shared/functions/employees.helper';
import { Subscription } from 'rxjs';


@Component({
    selector: 'app-employees-dashboard',
    templateUrl: './employees.dashboard.component.html',
    styleUrls: ['./employees.dashboard.component.scss'],
    providers: [CoreService]
})

export class EmployeesDashboardComponent implements OnInit{
    title:string = 'Employees DashBoard !!!';
    employeeAllDetails: IEmployee;
    errorMessage: any;
    employeeCode: string;
    employeeTrainingCount: number;
    employeeVacationCount: number;
    employeeLeaveCount: number;
    employeeTravelCount: number;
    employeeWFHAdhocCount: number;
    allTraining : Array<any>; 
    allLeave : Array<any>;
    allTravel : Array<any>;
    allWFHAdhoc : Array<any>;
    allWFHDays : Array<any>;
    employeeHelper: EmployeeHelper;
    employeeDataDetails: IEmployeeDataDetails
    firstDay: string;
    lastDay: string;
    minDate = new Date();
    maxDate = new Date(new Date().setDate(60));
    messages: string[];
    subscription: Subscription;
    dateFrom: string = null;
    dateTo: string = null;

    constructor(private coreService: CoreService){    
      this.allTraining = new Array(); 
      this.allLeave = new Array();
      this.allTravel = new Array();
      this.allWFHAdhoc = new Array();
      this.allWFHDays = new Array();
  
    }

    ngOnInit(): void {      
      var emp = new EmployeeHelper();
      emp.getMonthDate();
      this.firstDay = emp.firstDay;
      this.lastDay = emp.lastDay;
        this.coreService.getAllEmployees(this.firstDay,this.lastDay).subscribe({
          next: employees => {
            this.employeeAllDetails = employees;
            this.getEmployeeSpecificDetails(this.employeeAllDetails);
          },
          error: err => this.errorMessage = err
        });       
      }
     
        getEmployeeSpecificDetails(employeeDetails: IEmployee):void
        {
          if(this.employeeAllDetails)
          {
            let vacationMap = new Map<string,number>();
            let countLeave = 0;
            let countTravel = 0;
            let countWFHAdhoc = 0;
            this.employeeTrainingCount = employeeDetails.employeeAllDetailsTraining.length;
                  if(employeeDetails.employeeAllDetailsTraining.length > 0)
                  {
                    let counter = 0;
                    if(this.allTraining.length == 0)  
                    {
                      for(let training of employeeDetails.employeeAllDetailsTraining)
                        {
                          let trainingView =  new IEmployeeViewDetails();
                          trainingView.counter = counter + 1;
                          trainingView.empCode = training.employeeId;
                          trainingView.vacationType = "Training"; 
                          trainingView.employeeName = training.firstName +" "+training.lastName;
                          trainingView.trainingName = training.name;
                          trainingView.strDateFrom = training.strDateFrom;
                          trainingView.strDateTo = training.strDateTo;
                          trainingView.durationDays = this.calculateDaysDiff(training.strDateTo, training.strDateFrom);                    
                          trainingView.trainingHours = training.trainingHours;
                          trainingView.trainingRemarks = training.description;
                          this.allTraining.push(trainingView);
                        }
                      }
                  }
                  if(employeeDetails.employeeAllDetailsWFH.length > 0)
                  {
                    for(let wfhFix of employeeDetails.employeeAllDetailsWFH)
                    {
                      let wfhPermanentView = new IEmployeeViewDetails();
                      wfhPermanentView.empCode = wfhFix.employeeId; 
                      wfhPermanentView.vacationType = "WFHFixedDay"; 
                      wfhPermanentView.employeeName = wfhFix.firstName +" "+wfhFix.lastName;
                      wfhPermanentView.wfhFixedDay = wfhFix.days; 
                      this.allWFHDays.push(wfhPermanentView);
                    }
                }   
                if(employeeDetails.employeeAllDetailsVacation.length > 0)
                {
                    for(let vacation of employeeDetails.employeeAllDetailsVacation)
                    {
                      let vacationType = vacation.type;
                      if( vacationType == ConstantsMaster.dashboardConstants.LEAVE)
                      {
                        countLeave = countLeave +1;
                        vacationMap.set(ConstantsMaster.dashboardConstants.LEAVE,countLeave);
                        let leaveView =  new IEmployeeViewDetails();
                        leaveView.empCode = vacation.employeeId; 
                        leaveView.vacationType = vacationType; 
                        leaveView.employeeName = vacation.firstName +" "+vacation.lastName;
                        leaveView.strDateFrom = vacation.strDateFrom;
                        leaveView.strDateTo = vacation.strDateTo;
                        leaveView.durationDays = this.calculateDaysDiff(vacation.strDateTo, vacation.strDateFrom);                    
                        leaveView.vacationRemarks = vacation.remarks;
                        this.allLeave.push(leaveView);
                      }else if( vacationType == ConstantsMaster.dashboardConstants.TRAVEL)
                      {
                        countTravel = countTravel +1;
                        vacationMap.set(ConstantsMaster.dashboardConstants.TRAVEL,countTravel);
                        let travelView =  new IEmployeeViewDetails();
                        travelView.empCode = vacation.employeeId; 
                        travelView.vacationType = vacationType; 
                        travelView.employeeName = vacation.firstName +" "+vacation.lastName;
                        travelView.strDateFrom = vacation.strDateFrom;
                        travelView.strDateTo = vacation.strDateTo;
                        travelView.durationDays = this.calculateDaysDiff(vacation.strDateTo, vacation.strDateFrom);                    
                        travelView.vacationRemarks = vacation.remarks;
                        this.allTravel.push(travelView);

                      }else if( vacationType == ConstantsMaster.dashboardConstants.WFHADHOC)
                      {
                        countWFHAdhoc = countWFHAdhoc +1;
                        vacationMap.set(ConstantsMaster.dashboardConstants.WFHADHOC,countWFHAdhoc);

                        let wfhAdhocView =  new IEmployeeViewDetails();
                        wfhAdhocView.empCode = vacation.employeeId; 
                        wfhAdhocView.vacationType = vacationType; 
                        wfhAdhocView.employeeName = vacation.firstName +" "+vacation.lastName;
                        wfhAdhocView.strDateFrom = vacation.strDateFrom;
                        wfhAdhocView.strDateTo = vacation.strDateTo;
                        wfhAdhocView.durationDays = this.calculateDaysDiff(vacation.strDateTo, vacation.strDateFrom);                    
                        wfhAdhocView.vacationRemarks = vacation.remarks;
                        this.allWFHAdhoc.push(wfhAdhocView);
                      }                    
                    }
                }
              if(vacationMap.has(ConstantsMaster.dashboardConstants.LEAVE))
              {
                this.employeeLeaveCount = vacationMap.get(ConstantsMaster.dashboardConstants.LEAVE)
              }
              if(vacationMap.has(ConstantsMaster.dashboardConstants.TRAVEL))
              {
                this.employeeTravelCount = vacationMap.get(ConstantsMaster.dashboardConstants.TRAVEL)
              }
              if(vacationMap.has(ConstantsMaster.dashboardConstants.WFHADHOC))
              {
                this.employeeWFHAdhocCount = vacationMap.get(ConstantsMaster.dashboardConstants.WFHADHOC)
              }
          }
        }
      calculateDaysDiff(dateTo, dateFrom)
      {
        let _dateTo = new Date(dateTo);  
        let _dateFrom = new Date(dateFrom);
        let daysDiff =  Math.floor((Date.UTC(_dateTo.getFullYear(), _dateTo.getMonth(), _dateTo.getDate())
         - Date.UTC(_dateFrom.getFullYear(), _dateFrom.getMonth(), _dateFrom.getDate()) ) /(1000 * 60 * 60 * 24));       
         return daysDiff+1;
      }    
}