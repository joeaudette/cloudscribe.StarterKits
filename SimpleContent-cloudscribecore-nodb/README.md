# Using SimpleContent with cloudscribe Core and NoDb 

[SimpleContent](https://github.com/joeaudette/cloudscribe.SimpleContent) is a simple, yet flexible content and blog engine for ASP.NET Core.

This sample uses [cloudscribe Core](https://github.com/joeaudette/cloudscribe) for user authentication and [NoDb](https://github.com/joeaudette/NoDb) file system storage for content and data. 

[cloudscribe Core](https://github.com/joeaudette/cloudscribe) is a multi-tenant web application foundation. It provides multi-tenant identity management for sites, users, and roles.

[NoDb](https://github.com/joeaudette/NoDb) is a "No Database" file system storage, it is also a "NoSql" storage system.

This sample is pre-populated with sample data. There are 2 pre-configured sites, the root level site and another folder site at /two

When you run it you can login to either site with admin@admin.com as the username and admin as the password.

Be sure to update the credentials before deployment.

### Publishing

Note that the .csproj settings are configured to exclude the nodb_storage folder from publishing. That folder is where the data is stored, so we generally don't want to overwrite production data when we redeploy. However for the first deployment you should add this folder manually.

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)




