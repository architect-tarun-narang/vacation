export class ConstantsMaster{
  public static resourceScopes: [ "api://3421c6ef-0d2e-44bd-8ce6-2f45b9e836dc/access_as_user" ]
  public static apiEndPoints = {
    lookup: {
      employeeLeavesDetailsById: 'api/vacation/employeeleaves/getEmployeeLeavesAllDetailsById',
      employeeInformationById: 'api/vacation/employeeLeaves/getLoggedInUser',
      employeeLeavesDetails: 'api/vacation/employeeleaves/getEmployeeLeavesAllDetails',
      employeeWFHDays: 'api/vacation/employeeWFH/getWFHDays',
      addEmployeeWFHDays:'api/vacation/employeeWFHUpdate',
      deleteEmployeeWFHDays:'api/vacation/EmployeeWFHDelete',
      addEmployeeLeaves: 'api/vacation/employeeleavesadd',
      deleteEmployeeLeaves: 'api/vacation/employeeleavesdelete',
      employeeTrainingsDetails: 'api/vacation/employeeTrainings/getEmployeeTrainings',
      addEmployeeTraining: 'api/vacation/employeeTrainingsAdd',
      deleteEmployeeTraining: 'api/vacation/employeeTrainingsDelete',
      trainingTypes: 'api/vacation/employeeTrainings/GetTrainingTypes',
    },
    userPreferences: 'api/userPreferences',
    userNotification: 'api/notification',
  };
  public static dashboardConstants = {
    LEAVE: 'Leave',
    TRAVEL: 'Travel',
    WFHADHOC: 'WFHAdhoc',
    TRAINING_ID: 3,
    WHFDAYS: 'wfhDays'
  }
  public static LEAVE_VACATION_TYPE_ID = 1;
  public static TRAVEL_VACATION_TYPE_ID = 2;
  public static TRAINING_VACATION_TYPE_ID = 3;
  public static WFHADHOC_VACATION_TYPE_ID = 4;
  public static WFHPERMANENT_VACATION_TYPE_ID = 5;
  
}