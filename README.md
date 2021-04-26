# Angular_Asp.NetCore_WebAPI
A sample Angular 8 / ASP.NET Core 3.1 (cross-platform ) project template with summary and detail view binding data from api get and post api implementation. As well as other common functionalities for angular single page application.

This application consists of:
1) Angular spa frontend project developed using Angular 8 and TypeScript
2) RESTful API Backend project using ASP.NET Core 3.1 MVC Web API
3) JSON file as data source

Prerequisites
You will need the following tools:

1) Visual Studio Code or Visual Studio 2019 Preview
2) .NET Core SDK 3.1
3) Node.js (version 10 or later) with npm (version 6.9.0 or later)

Installation
Open Project template from the Visual Studio 2019 and do Build -> Clean Solution then Build -> Rebuild Solution - it will update all nuget packages. Launch with F5 or Ctrl+F5

Installation Notes
You should have the latest version of Node.js, which is supported by Angular CLI 8.0+
When running the project please wait for all dependencies to be restored; "dotnet restore" for asp.net api project & "npm install" for angular project. When using VisualStudio this is automatic, check the output window or status bar to know that the package/dependencies restore process is complete before launching your program for the first time.
If you get any errors, consider running manually the steps to build the project and note where the errors occur. Open command prompt and do the below steps:
run 'dotnet restore' from the two project folders - Restore nuget packages
run 'npm install' from the project with package.json - Restore npm packages
Try running the application again - Test to make sure it all works
When running the client(angular) project on a different address/domain from the backend, configure the baseUrl of the client to match that of the server. You do this from data.service.ts in the Anguler_Task project. Example: baseUrl: "http://yourbackendserver.com/api/data" OR baseUrl: "http://localhost:5050/api/data"
