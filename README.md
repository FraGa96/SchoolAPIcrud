
# SchoolApi

A simple 3 layered project to handle a CRUD with EntityFramework and .Net Core 6


## Data Access Layer

Required Nuget Packages:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.SqlServer.Design
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration

## Application Layer

Project Dependencies
- Data Access Layer

## Presentation Layer
Required Nuget Packages:
- Microsoft.EntityFrameworkCore.Design

Project Dependencies
- Data Access Layer
- Application Layer


## Acceptance Criteria
For Grades:
- The user is capable to create a Grade
- The user is capable to get all Grades
- The user is capable to update a Grade

For Applicant:
- The user is capable to create an Applicant
- The user is capable to get a specific Applicant
- The user is capable to update an Applicant

For Applicantion Status:
- The user is capable to create an Applicantion Status
- The user is capable to get all Applicantion Status
- The user is capable to update an Applicantion Status

For Application:
- The user is capable to create an Application
- The user is capable to get a specific Application
- The user is capable to update an Application
- The user is capable to remove an Application
- The user is capable to get all the applications for a specific applicant

Create a react app to handle this CRUD functionalities, should be responsive

### Extra
- Create a new entity Teacher
    - A Grade can have 1 Teacher, a Teacher can teach only 1 grade at a time (Relation 1 to 1)
    - A Teacher have a name, surname, birthdate, phone, email
- Do the required changes on the context (including the relationship)
- Create the Teacher service (Add dependency injection on Program.cs)
- Create the Teacher controller

