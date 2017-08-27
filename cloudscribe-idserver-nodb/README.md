# Using cloudscribe Core with IdentityServer4 and NoDb 

cloudscribe Core and IdentityServer4 integration provides a compelling solution that makes it easy to provision new OP (OpenId Connect Provider) Servers each with their own Users, Roles, Claims, Clients, and Scopes. It includes a UI for managing all the needed data including role and claim assignments for users.

There are 2 mutually exclusive multi-tenancy configuration options. Tenants can be based on host names, or tenants can be based on the first folder segment of the url. This sample uses the folder segment approach. Folder tenants eare easier to provision than host name tenants because there are no additional DNS records needed and no additional SSL certificate is needed, you create new tenants from the UI and they work immediately.

The root level tenant (ie the first tenant which doens't need a folder segment) is flagged as IsServerAdminSite in the db. Administrators in that tenant can create new tenants and manage other tenants. Administrators in the folder tenants can only manage the data for that tenant.

I'm not advocating use of NoDb storage for running an OP Server, but I used it for this sample because it allows me to easily commit pre-populated data for 2 tenants to show off the value of this solution. There are API's and Javascript clients already setup for each of the 2 OP Server tenants. So you can run the projects as describe below and test the functionality and see the code for integrating the APIs and clients.

For production use, I made another [sample using Entity Framework storage](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-idserver-ef) and it would be more recommended to use that sample to stand up an OP Server for your own project.

### TIP:

This sample uses NoDb storage and some of the file paths can exceed the file path limitations on Windows. Therefore it is best to clone or download this project into a very short folder path to keep the file paths as short as possible. ie I am using c:\c as my root folder for this repository and I don't run into any path too long errors, but if you put it in a deeper folder it is possible you will encounter such errors with this sample.

## Running the samples in this solution

1. Control/Shift/Right Click the solution folder and choose "Open Command Window Here"
2. Run the command: dotnet restore --no-cache
3. Exit
4. For each project folder in the solution, Control/Shift/Right click the project folder and choose "Open Command Window Here"
5. In each command window run the command: dotnet run

Now you can open a browser at http://localhost:50405 for the first OP Tenant and http://localhost:50405/two for the 2nd tenant

In each of those tenants there is a pre-configured admin user with the credentials admin@admin.com and password:$Secret12345

Once you login an Administration menu item will appear, take a look around to see the management UI, especially take a look under Administration > Security Settings for the sections for Api Resources, Api Clients, and Identity Resources which provide the UI for configuring Identity Server.

Notice that from the first tenent you can browse to Site List and click on the second tenant manage button and then you can manage the data for that tenenat as well.
You can also login directly to the second tenant to manage its data and you will see that it cannnot manage any other tenant data.

Before testing the clients you should probably log out of the OP Server or you could use a different browser, the point is to see that you can login from the client so you don't want to be already logged in when you try it, or use different web browsers for each one.

The Tenant1SpaPolymer client is at http://localhost:5010

The Tenant2SpPolyment client is at http://localhost:5011



##### Screenshots

![ploymer html client screen shot](https://github.com/joeaudette/cloudscribe/raw/master/screenshots/polymer-html-client.png)

![ploymer html client login screen shot](https://github.com/joeaudette/cloudscribe/raw/master/screenshots/polymer-html-client-login.png)

![ploymer html client logged in screen shot](https://github.com/joeaudette/cloudscribe/raw/master/screenshots/polymer-html-client-logged-in.png)

![ploymer html client api call screen shot](https://github.com/joeaudette/cloudscribe/raw/master/screenshots/polymer-html-client-api.png)


## Meta

This sample uses [cloudscribe Core](https://github.com/joeaudette/cloudscribe) for user authentication and [NoDb](https://github.com/joeaudette/NoDb) file system storage for content and data. 

[cloudscribe Core](https://github.com/joeaudette/cloudscribe) is a multi-tenant web application foundation. It provides multi-tenant identity management for sites, users, and roles.

[NoDb](https://github.com/joeaudette/NoDb) is a "No Database" file system storage, it is also a "NoSql" storage system.

This sample is using a fork of [IdentityServer4](https://github.com/joeaudette/IdentityServer4) with minimal changes that were needed to support folder tenants of the OP Server. I am hoping to get changes into the main IdentityServer4 to support this scenario, this fork is hopefully a temporary solution.

### Publishing

Note that the .csproj settings are configured to exclude the nodb_storage folder from publishing. That folder is where the data is stored, so we generally don't want to overwrite production data when we redeploy. However for the first deployment you should add this folder manually. However, I don't really recommend using NoDb storage for an identity server endpoint, you would be better off using a database for that kind of usage. This starter kit is mainly to provide a working example with sample data, and NoDb made it easy to do that since the data is just files on disk.

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)




