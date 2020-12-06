# Controllers

## Add error returns

The current code only return "OK" (HTTP 2xx) status without any considering of errors.

I tried to add some error code if DB does not work or other bugs exist.

Currently the result is empty with HTTP 4xx status for errors.

## Validation

There should be more validation to check the uploaded data.

Since I am not changing any of the API endpoint, I just tried to add some typical validation.

## Add response model

I have added a simple sample response model **TransactionResponseModel**

It is common that structure of response body is different from original model, e.g. Transaction response contains only date and amount, while there are accountId and Id (transaction ID) in database and actual model class.

By using response model we can organise the result format.

# Services

## Add Service layer

Controller layer should not directly touch Database.

Controller layer will deal with data from frontend, and call service layer for concrete service.

Service layer will analyse the data, complete the business logic and operate Database (maybe through ORM).

# Persistence

## Move connection string to Web.config

Connection string should be moved into config file, which is not hard coded in the source files.

## Add EntityFramework

Add EntityFramework as ORM.

Add DbContext, and inject it into service by DI.

All database modifications are refactored that no direct SQL query exists in the source files.

Model files are cleared that no DB operation exists.

### if we do not want to use ORM

Some legacy codes still hard code sql query in the source file, which is not suggested for my personal understanding. 

If we do not wish to use ORM, probably we could "hide" those queries into stored procedures. It will improve the efficiency and security. (For this refactoring project I just leave the database without any manual modifying)

## Add AccountID field to transaction model class

Since this field exist in database, I have added the field into model.

And since this project is not developed in code first mode, I have not added any constrains or notation to the model.

# Comments

The original code does not contain much comments.

I tried to add comments in a single service **AccountService**, just showing how to.

Sorry due to time limit I have not add comment to all the files.

# misc

 - Original code in Controllers use a lot of unnecessary using connection
 - Model class file names are plural, which are different from the class names. It is just due to name style. I left it as original.

## Add Exception classes

This is optional but it helps us to maintain a large project.

## About names

Since it is only a test project, I have not changed the namespace name.

The new items are named like "RefactorDbContext".

# Further works

## Add Logging

Logger should be added to the project.

Loggings help the administrators to analyse any runtime problems.

## Dependency Injection

All the services and DbContext are ready for DI, with interface ready.

## Add test

There should be unit test or more.

## Add full response models and DTOs

The current code do not use DTO or response models.

By using response models we can easily organise response structure globally, e.g.:

If we add a base response model like

**Base Response Model**
```
{
  "isSuccess": true/false,
  "Message": string
}
```
Then all the response models just inherit from the base response model, and they could be like:
**Any Response**
```
{ 
  "isSuccess": true/false,
  "Message": string,
  <Other fields>
}
```
Since the response structure need to negotiate and carefully design, I just leave it as a future task.

## Move to .net core and EF core

Sorry it is a bit too ambitious.

However Microsoft combines .net framework and .net core into .net v5, which is based on .net core and do not depend on Windows API (and IIS).

Although old EF core supports .net framework, the latest EF core v5 cannot run on .net Framework any more. We should move to EF core v5 as future plan.

Since it is a re-construct task, I have to leave it as a future task.

# Known issue

When I tried to not adding '?' (nullable) to the fields in **Transaction** model class, EF will pop error and then return 500 code without any output.

So the nullable notation is just for making the project working.

The reason may be that EF is working neither code first nor DB first (generating models).
