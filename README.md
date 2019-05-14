# ngNetFramework
Angular 7 served by .NET 4.7.2

Boilerplate project for using Angular 7 with .NET Framework 4.7 Web API, and Webpack, without the use/need of the Angular CLI.

Offers the ability to use both Angular and MVC/WebAPI routing, and leverage .NET libraries for authentication, logging, etc.

To get started:
1) Command Line: navigate to /Client directory
2) Command Line: npm install
3) Command Line: npm run build:dev
4) Visual Studio: right click on solution and "Restore NuGet Packages"
4) Visual Studio: Debug/Run


# Logging
The application has built-in global exception handling for runtime exceptions originating from the client (Angular/JavaScript) or server (.NET MVC/WebAPI).  It is configured to use a log4net.config file in the root of the ngMayo.Logging directory - you will need to provide this yourself, but you can reference the README.txt file in the ngMayo.Logging project for a general outline.

If you want to keep this in your own repo, make sure you remove the entry in .gitignore about the log4net.config file.
