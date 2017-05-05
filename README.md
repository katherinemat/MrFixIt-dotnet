# Mr Fix-It
#### A repair technician job service.

#### By _**Katherine Matthews**_, 5.5.2017

## Description

_Single page website to log user's meals with calories and meal details, including how the food makes the user feel and how long the food takes to prep. Users can sort food entries by those meals with more or less than 500 calories. Also includes the ability to edit meals after they've been added._

## Setup/Installation Requirements

* Clone repo off of github to local machine and open in Visual Studio
* inside the terminal, while inside the project directory\src\MrFixIt, run the following commands
_(requires SSMS on computer)_
      $ dotnet ef migrations add CHANGE_THIS_NAME
      $ dotnet ef database update
* In Visual Studio, click on button to run IIS Server. Application will load in browser

## Specifications

COMPLETED:
* Users can register and log on
* Users may sign up to be "workers" on the site.
* New jobs may be added to the jobs list.
* A job can be assigned to a worker.
* A worker may take on mulitple jobs from the Worker Dashboard.

IN PROGRESS
* Make *claiming* a job an **AJAX** action.

NEXT UP
* A worker may designate one **active** job at a time. **AJAX**
* Workers may mark jobs complete, and select a new active job. **AJAX**

## Known Bugs

User has to reload page in-between clicking on button to mark a job started and completed. This is because jQuery event listener that marks a job completed is attached to a dynamically-created element from another jQuery command. Another problem I'd like to fix is that a user can add multiple jobs to the activated column. Only one job will be activated at a time in the back-end, but the views don't update dynamically to reflect that. I also found styling difficult. In order to check my first several CSS changes, I had to clear Chrome's history and restart the server. 

## Technologies Used

* _ASP.NET_
* _C#_
* _AJAX_
* _jQuery_
* _HTML_
* _CSS_

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Katherine Matthews_**
