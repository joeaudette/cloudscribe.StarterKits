# Using SimpleContent with Simple Auth and NoDb

This sample uses [cloudscribe SimpleAuth](https://github.com/joeaudette/cloudscribe.Web.SimpleAuth) which is best suited for projects where only one or a few people need to be able to login. Users are pre-configured in the simpleauth-settings.json file, and project settings are configured in the simplecontent-settings.json file. The sample uses NuGet packages for cloudscribe SimpleContent and cloudscribe SimpleAuth. A good way to setup your own site is to use this sample. You can publish it from Visual Studio as it is or you can customize it by adding your own code and/or projects.

This sample uses [NoDb](https://github.com/joeaudette/NoDb) file system storage for content and data. NoDb is a "No Database" file system storage, it is also a "NoSql" storage system.

You can login to the sample with admin as the username and admin as the password

Be sure to update the credentials in the simpleauth-settings.json file before deployment.

If you have questions or just want to be social, say hello in our gitter chat room. I try to monitor that room on a regular basis while I'm working, but if I'm not around you can leave  message.

### Publishing

Note that the .csproj settings are configured to exclude the nodb_storage folder from publishing. That folder is where the data is stored, so we generally don't want to overwrite production data when we redeploy. However for the first deployment you should add this folder manually.

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)






