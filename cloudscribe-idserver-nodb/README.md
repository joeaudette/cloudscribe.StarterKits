# Using cloudscribe Core with IdentityServer4 and NoDb 

cloudscribe Core and IdentityServer4 integration provides a compelling solution that makes it easy to provision new OP (OpenId Connect Provider) Servers each with their own Users, Roles, Claims, Clients, and Scopes. It includes a UI for managing all the needed data including role and claim assignments for users.

There are 2 mutually exclusive multi-tenancy configuration options. Tenants can be based on host names, or tenants can be based on the first folder segment of the url. This sample uses the folder segment approach. Folder tenants eare easier to provision than host name tenants because there are no additional DNS records needed and no additional SSL certificate is needed, you create new tenants from the UI and they work immediately.

The root level tenant (ie the first tenant which doens't need a folder segment) is flagged as IsServerAdminSite in the db. Administrators in that tenant can create new tenants and manage other tenants. Administrators in the folder tenants can only manage the data for that tenant.

I'm not advocating use of NoDb storage for running an OP Server, but I used it for this sample because it allows me to easily commit pre-populated data for 2 tenants to show off the value of this solution. There are API's and Javascript clients already setup for each of the 2 OP Server tenants. So you can run the projects as describe below and test the functionality and see the code for integrating the APIs and clients.

For production use, I made another [sample using Entity Framework storage](https://github.com/joeaudette/cloudscribe.StarterKits/tree/master/cloudscribe-idserver-ef) and it would be more recommended to use that sample to stand up an OP Server for your own project.

## Running the samples in this solution

1. Control/Shift/Right Click the solution folder and choose "Open Command Window Here"
2. Run the command: dotnet restore --no-cache
3. Exit
4. For each project folder in the solution, Control/Shift/Right click the project folder and choose "Open Command Window Here"
5. In each command window run the command: dotnet run

Now you can open a browser at http://localhost:5000 for the first OP Tenant and http://localhost:5000/two for the 2nd tenant
In each of those tenants there is a pre-configured admin user with the credentials admin@admin.com and password:admin
Once you login an Administration menu item will appear, take a look around to see the management UI, especially take a look under Administration > Security Settings > Clients, and under Administration > Security Settings > Scopes

Notice that from the first tenent you can browse to Site List and clikc on the second tenant manage button and then you can manage the data for that tenenat as well.
You can also login directly to the second tenant to manage its data and you will see that it cannnot manage any other tenant data.

Before testing the Js Clients you should probably log out of the OP Server or you could use a different browser, the point is to see that you can login from the Js Client so you don't want to be already logged in when you try it.

The Tenant 1 Js Client is at http://localhost:5005

The Tenant 1 Html/PolymerJs Client is at http://localhost:5010  (This is a fancier more realsitic client example using polymer web components)

The Tenant 2 Js Client is at http://localhost:5007

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

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)




