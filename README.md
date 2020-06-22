# Project-Technician👨‍💻

### In Progress - Any time, I finish 🛠⚙️ if it compiles it can get an error

_____________________________________________________________________
Update

Si se monta desde windows hay que configurar la bbdd mientras que por mac tira la migracion automatica.
Pagina azure: https://project-technician.azurewebsites.net/

Heroku or Azure public app

to future: https://social.technet.microsoft.com/wiki/contents/articles/37349.asp-net-core-in-memory-caching.aspx

Medio de uso VPN HAMACHI conexion referencial local, ip, vpn

[HAMACHI](https://vpn.net/)

Grupo ID: shernaji
Pass: 123456

1ER PASO

          USE [master]
          GO
          /****** Object:  Login [IIS APPPOOL\DefaultAppPool]    Script Date: 21/06/2020 12:09:40 a. m. ******/
          CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español]
          GO
          ALTER SERVER ROLE [sysadmin] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
          GO
          ALTER SERVER ROLE [securityadmin] ADD MEMBER [IIS APPPOOL\DefaultAppPool]
          GO


2DO PASO

          USE [mydb]
          GO
          /****** Object:  User [IIS APPPOOL\DefaultAppPool]    Script Date: 20/06/2020 10:25:45 p. m. ******/
          CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
          GO


json:    ConnectionStrings": {
          "DefaultConnection": "Server=.\\SQLEXPRESS;Database=mydb;Trusted_Connection=True;Connection Timeout=30;"
          },

![alt text](https://raw.githubusercontent.com/stevenhdz/Project-Technician/master/code.png)


**Design**

[Model ASP.NET CORE](https://docs.microsoft.com/es-es/aspnet/core/mvc/views/layout?view=aspnetcore-3.1)

- [x] Header
- [x] Content
- [x] Left Navigation
- [x] Footer


![alt text](https://docs.microsoft.com/es-es/aspnet/core/mvc/views/layout/_static/page-layout.png?view=aspnetcore-3.1)


**.gitignore**

- [x] mydb.db
- [x] Migrations


**Framework Web:**

- [ ] Blazor
- [x] Asp.net Core
- [ ] Asp.net

**Framework, tools and libraries**

- [x] .Net core
- [ ] .Net 

**Licence:** 

- [x] GPL V3

![alt text](https://janelia-flyem.github.io/images/open_licenses.png)


          
**Languages:**
   
- [x] JAVASCRIPT
- [x] C#
- [x] CSS/HTML
   
**Techniques:**

- [x] MVC
- [x] MVVM
- [ ] MVT


**Graphics**

[Google Charts Api](https://www.tresce.com/blog/google-charts-la-api-de-graficos-para-el-dasarrollo-web/)

**SCAFFOLDING**
- [x] Controllers
- [x] Views
- [x] Models
- [x] ViewsModels

- mvc+vm scheme:          


                                                                   ORM
                                                    ___________________________________
                                                    |                                 |
                            |-----------------------|------|                          |
                            |                       |      |                          |
                           🔽                       |     🔼                          |
                          Views ⬅️--- Controllers --|--➡️ ViewModels ------➡️ Models--|---➡️ Database
                            |             |         |      |               |          | 
                            |             |         |      |               |          |
                            🔽           🔽         |     🔽              🔽         |
                         Response    Client Side    |   VistasDB           DB         |       
                                                    |                                 | 
                                                    |_________________________________|
                                                    
**Micro ORM or ORM:**

- [ ] Dapper
- [x] LinQ
- [x] Entity Framework core
- [ ] Entity Framework

**Methods ORM**

- [x] Code first
- [ ] Database first
- [ ] Model first


![alt text](https://lh3.googleusercontent.com/proxy/jah7OA0URfdjicruH7YHF5WvYRwxjJneVjtSL16W0oEaQYlwLSwSsE_NLQMsO0ntRBXPtRmGNczWUt_ey6aQGoNezrh78QzvQQ5RZ2Bj7-bymofy)
              
                         
              
**Data annotations:**

Validation: [Regexr](https://regexr.com/3bcea)

RegularExpression ("^([3]{1})([0-5]{1})[0-9]{8}", ErrorMessage ="Numero invalido")]


              
**DataBase:**
      
- [x] SQlite
- [x] SQL server

**Document**
[SQLite](https://www.sqlite.org/datatype3.html)


  
**Platforms:**

- [x] Azure
   
**Development environments and tools:**

- [x] Visual studio code
- [x] Visual studio
- [x] DB browser for SQlite
- [x] SQlite Studio
- [x] SQL Server Management Studio

**Operating systems:**

- [x] Windows
- [x] Mac OS
- [ ] Linux

**Collaboration tools:**

- [x] Github
- [x] Notion [Managment Project](https://www.notion.so/5cdcc9c16a1646b3bd43396e60c49630?v=6a53e14132434b89a32181f065defbda)
- [x] Azure 
- [x] Discord [Streaming project](https://discord.gg/X5xnZ9g)
- [x] IIS


**Email**

[Mailto](https://www.rapidtables.com/web/html/mailto.html)

[Encoding references](https://www.w3schools.com/tags/ref_urlencode.ASP)

**Branches**

[Document Bootstrap](https://getbootstrap.com/docs/4.4/getting-started/contents/)
  
**Libraries integrate - no integrate the project online:**
  
          dataannotations: EF CORE
          
          side - client:
          boostrap twitter

              "library": "twitter-bootstrap@4.5.0",
              "destination": "wwwroot/twitter-bootstrap/"

          nugets:
          
                    
          Update: in the commit version 3.1.* for up

              <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="3.1.5" />
              <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="3.1.5" />
              <PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="3.1.5" />
              <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.5" />
              <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="3.1.5" />
              <PackageReference Include="Microsoft.Extensions.Logging.Debug" Version="3.1.5" />
              <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="3.1.3" />
              <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="3.1.5" />
              
          Install nugets vscode:
              
                               dotnet add package Microsoft.EntityFrameworkCore.SqlServer

          jquery:
              
              jQuery JavaScript Library v3.3.1
 
 **Extras:**
 
          css:
          
              <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
              <link rel="stylesheet" href="~/css/site.css" />
          
          MDBoostrap:
          
              <!-- Google Fonts -->
              <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap">
              <!-- Bootstrap core CSS -->
              <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/css/bootstrap.min.css" rel="stylesheet">
              <!-- Material Design Bootstrap -->
              <link href="https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.19.0/css/mdb.min.css" rel="stylesheet">
              <link href="//netdna.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
              
          Font-awesome:
          
              <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
              
 **Execute:**
 
 
 
 **VSCODE:**
         
         RUN:
         
         
         dotnet ef migrations add [migration name]
         dotnet ef database update
         cd Project_technician
         dotnet run
         
         
         
**VISUAL STUDIO:**
         
         RUN:
         
         add-migration [migration name]
         update-database
         boton run
         
              
              
              

**POSSIBLE ERROR SOLUTION**

                DOTNET TOOL INSTALL --GLOBAL DOTNET-EF
                DOTNET HELP
                DELETE FOLDER MIGRATIONS
                DELETE AND DROP DATABASE Mydb.db
                DELETE OBJ & EXECUTE DOTNET RESTORE
                REMOVE-MIGRATION INITIAL1
                DROP-DATABASE

              
**Errors Report**

                FIX
                Rename folders Project_Tecnician
                🔽
                Project_Technician.sln
                🔽
                "Project_Technician", "Project_Technician\Project_Technician.csproj"

               
# ☠️ Create by SLTECHNOLOGY ☠️

   D


