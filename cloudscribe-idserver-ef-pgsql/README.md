## Use of this StarterKit is Deprecated
It is now possible to create a project with the same configuration as this StarterKit using our new project template for Visual Studio or the .NET CLI, as explained in the [Introduction](https://www.cloudscribe.com/docs/introduction)
With the new project template there are even more configurable options. This StarterKit is still maintained as a reference but it is much better to start new projects with the project template.

# Using cloudscribe Core with IdentityServer4 and Entity Framework Core - PostgreSql

cloudscribe Core and IdentityServer4 integration provides a compelling solution that makes it easy to provision new OP (OpenId Connect Provider) Servers each with their own Users, Roles, Claims, Clients, and Scopes. It includes a UI for managing all the needed data including role and claim assignments for users.

This sample provides a ready to run multi-tenant OP (OpenId Connect Provider) Server. On the first run it will initialize the database and create an admin user with the credentials admin@admin.com and the password "admin".

Once you login an Administration Menu will appear providing links to all the management features for tenants, user, roles, calims, clients, and scopes.

Note that you do not have to use the multi-tenancy features, it works just as well in a single tenant scenario.


## Meta

This sample uses [cloudscribe Core](https://github.com/joeaudette/cloudscribe) for user authentication and Entity Framework Core with PostgreSql for data storage.

[cloudscribe Core](https://github.com/joeaudette/cloudscribe) is a multi-tenant web application foundation. It provides multi-tenant identity management for sites, users, and roles.

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

