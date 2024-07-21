# SHORTEN URL
I wanted to understand how long urls are condensed into short resusable urls, and I wanted to build this in the cloud.
After some research I decided to create a full project out of it.

-FUNCTIONAL REQUIREMENTS

Be able to generate a shorten url when given an input that is a valid URL

The URL generated should be a valid url that maps back to the original destination

When given an existing url in the system return the existing shorten url

the shorten urls are unique


-TECHNICAL REQUIREMENTS

Utilize Azure as a Cloud Platform

Create microservices via functions

Use Keyvault for App Settings

Understand how to use App Insights and be able to write custom logs to the Service

Create Enterprise level software by using Repository/UnitofWork Pattern

Leverage Dependency Injection to create unit test, and decouple dependencies from classes

Create Unit Tests and have 90% code coverage for all microservices

Set Budget Alerts when 50% of the budget is reached

-TECHNOLOGIES USED

-C#
-.NET
-Windows
-Azure
-Azure Functions
-Azure SQL DB-Azure Key Vault
-App Insighs
-Azure Monitor
-PostMan
-Powershell
-Azure Load Balancer
-Azure Cache for Redis
-Azure Data Studio
-Visual Studio
-Github

-DESIGN

![shortenurldesign drawio](https://github.com/user-attachments/assets/0697ad07-4633-42fa-b550-82533af4d667)


-LESSONS LEARNED

Repository pattern should use class of T Type

This benefits when you only need to change the database at the unit of work level

Use isolated dot net to remove the need of web jobs libraries. Functions should also replace functions name in attributes

Dependency injection is done at the program.cs level for .exe

Use Ilogger<T> to log to app insights

-TO DO'S

Refactor to use async, and use all methods in create service.

Leverage -Azure Cache for Redis for redirect and read routes

Put a Load Balancer in front of API interfaces

Use provider authentication and create unique user profiles

Finish Clean Up Service to remove keys that have not been active for at least six months
