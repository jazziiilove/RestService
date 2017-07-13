# RestService
A .NET 2.0 REST service.

There is the unit test project (TestRest) for you to test.

I was revising the article and the code, https://www.codeproject.com/Articles/112470/Developing-a-REST-Web-Service-using-C-A-walkthroug

And porting this solution in IIS to 4.0 is impossible so far. I used IIS 10 btw.

So, you need to compile the application in .NET 2.0 and the application pool for the application is .NET 2.0 with 32-bit setting enabled 
together with classic managed pipeline mode (These settings are in application pool).

You need to create a folder in IIS (C:\inetpub\wwwroot\RestService) and put the 3 dlls in the bin folder (which you will create in RestService folder)
The dlls are also committed here (RestService\RestService\bin\Debug)

You need to also put a web.config file for handlers (you put it right under RestService folder). I am also adding this to solution folder.
