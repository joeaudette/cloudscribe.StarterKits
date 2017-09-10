# cloudscribe.StarterKits

The Starter Kits in this repository were the first approach we came up with to help people get started using cloudscribe by showing the various ways it can be configured depending on which features you want and which data storage platform you prefer.

While these Starter Kits are still maintained and are useful as references when you want to integrate cloudscribe libraries into existing applications, we now have much better ways to start new projects including a project template for the dotnet new command and a project template extension for Visual Studio 2017. See the [Introduction](https://www.cloudscribe.com/docs/introduction) to learn about our new project templates. Using our new project templates you can basically generate projects in the various configurations that correspond to the starter kits just by using parameters supported by the project templates.

Feel free to ask questions in our gitter chat web page:

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)


All of these samples are intended as something you could copy and use to start your own ASP.NET Core project in Visual Studio 2017. The WebApp in each solution is yours to customize and add your own custom functionality. There is no "cloudscribe" source code in the samples they only have NuGet dependencies on cloudscribe libraries and they have been configured with example Startup.cs code to get things working.

To get the big picture of what cloudscribe provides for you see the [Introduction](https://www.cloudscribe.com/docs/introduction) and [Documentation](https://www.cloudscribe.com/docs) at [cloudscribe.com](https://www.cloudscribe.com/)

This repository is for ASP.NET Core 2.0 starter kits, if you need starter kits for ASP.NET Core 1.x see https://github.com/joeaudette/cloudscribe.StarterKits.netcore1

## [SimpleContent with SimpleAuth and NoDb - Single Tenant](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/SimpleContent-SimpleAuth-nodb)

## [SimpleContent with SimpleAuth and NoDb - Multi-Tenant](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/SimpleContent-SimpleAuth-nodb-multitenant)

## [SimpleContent with cloudscribe Core and NoDb](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/SimpleContent-cloudscribecore-nodb)

## [SimpleContent with cloudscribe Core and Entity Framework Core - MSSQL](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/SimpleContent-cloudscribecore-ef)

## [SimpleContent with cloudscribe Core and Entity Framework Core - MySql](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/SimpleContent-cloudscribecore-ef-mysql)

## [SimpleContent with cloudscribe Core and Entity Framework Core - PostgreSql](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/SimpleContent-cloudscribecore-ef-pgsql)

## [cloudscribe Core and NoDb](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-core-nodb)

## [cloudscribe Core and Entity Framework Core - MSSQL](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-core-ef)

## [cloudscribe Core and Entity Framework Core - MySql](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-core-ef-mysql)

## [cloudscribe Core and Entity Framework Core - PostgreSql](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-core-ef-pgsql)

## [cloudscribe Core, IdentityServer4, and NoDb](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-idserver-nodb)

## [cloudscribe Core. IdentityServer4, and Entity Framework Core - MSSQL](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-idserver-ef)

## [cloudscribe Core. IdentityServer4, and Entity Framework Core - MySql](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-idserver-ef-mysql)

## [cloudscribe Core. IdentityServer4, and Entity Framework Core - PostgreSql](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-idserver-ef-pgsql)

### Build Status

We are currently working on adding netcoreapp2.0 versions of the StarterKits, but we don't yet have the automated builds working for that so the build status may say it is failing but in fact the solutions all build fine. We will get the automated builds working as soon as we can pending support for .NET Core 2 on AppVeyor and Travis

| Windows  | Linux/Mac |
| ------------- | ------------- |
| [![Build status](https://ci.appveyor.com/api/projects/status/jvafvkw4xueq3te4?svg=true)](https://ci.appveyor.com/project/joeaudette/cloudscribe-starterkits)  | [![Build Status](https://travis-ci.org/joeaudette/cloudscribe.StarterKits.svg?branch=master)](https://travis-ci.org/joeaudette/cloudscribe.StarterKits)  |

## Questions or Feedback?

If you have questions or feedback or just want to be social, say hello in our gitter chat room. I try to monitor that room on a regular basis while I'm working, but if I'm not around you can leave  message.

If you find any bugs please post an issue!

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
