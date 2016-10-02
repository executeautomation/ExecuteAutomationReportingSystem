# ExecuteAutomationReportingSystem (Initial Release)
This repository contains ExecuteAutomation Reporting System along with ExecuteAutomation Web Service.

##Description
ExecuteAutomation Reporting System (EARS) is a one point reporting system for automation testing tools and custom written frameworks like
    1. Selenium
    2. Visual Studio Coded UI
    3. Robotium
    4. Appium

ExecuteAutomation Web Service (EAWS) is built with WCF which can be consumed by above said tools with just 1 lines of code.

##How to Run the application
1. First run the database script from the DatabaseScript folder which contains two files
    1. DBAndTableScript.sql
    2. StoredProcedures.sql

2. Clone repository and run the project 
3. Change the web.config files connectionstring (to point your own custom sql server instance with username and password)
```xml
  <connectionStrings>
    <add name="EARS_DBConnectionString" connectionString="Data Source=localhost;Initial Catalog=EARS_DB;Integrated Security=True"
      providerName="System.Data.SqlClient" />
  </connectionStrings>
```

##Where can I learn building this tool ?
You can learn building ExecuteAutomationReportingSystem and ExecuteAutomation TestHarness System from udemy course 
https://www.udemy.com/creating-automation-reports-with-ears

Here is the complete introduction video

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/SLCbGPGfLb0/0.jpg)](https://www.youtube.com/watch?v=SLCbGPGfLb0)

##Screenshots
###Home Page
![alt text](https://github.com/executeautomation/ExecuteAutomationReportingSystem/blob/master/Images/Image1.png "Home Page")

###DetailedReport
![alt text](https://github.com/executeautomation/ExecuteAutomationReportingSystem/blob/master/Images/DetailedReport.png, "Detailed Report")





