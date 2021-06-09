# Project Shelter
The purpose of the project was to create a website to operate the shelter.
The website allows you to view animals staying in the shelter along with the possibility
generating the animal's adoption form. The site provides the opportunity
financial support for the shelter. The user has the option of reporting the lost or
neglected pet. The person looking for a pet has the ability to contact
owner by chat.
<h1>Libraries used:</h1>
<h3>SendGrid v9.23.2</h3>
<h3>IronPdf version v2021.3.1</h3>
<h3>Microsoft.AspNetWebHelpers v3.2.7</h3>
<h3>Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore v5.0.6</h3>
<h3>Microsoft.AspNetCore.Identity.EntityFrameworkCore v5.0.6</h3>
<h3>Microsoft.AspNetCore.Identity.UI v5.0.6</h3>
<h3>Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation v5.0.6</h3>
<h3>Microsoft.EntityFrameworkCore.Design v5.0.6</h3>
<h3>Microsoft.EntityFrameworkCore.Sqlite v5.0.6</h3>
<h3>Microsoft.EntityFrameworkCore.SqlServer v5.0.6</h3>
<h3>Microsoft.EntityFrameworkCore.Tools v5.0.6</h3>
<h3>Microsoft.VisualStudio.Web.CodeGeneration.Design v5.0.2</h3>
<h1>In order to run the app:</h1>
<h3>1. Import project in Visual Studio 2019</h3>
<h3>2. In Packet Manager Console paste following lines one after another:</h3>  

        Update-Database -Context ApplicationDbContext
And after it next command:

        Update-Database -Context AnimalsContext
<h3>3. Run the project from Visual Studio 2019 </h3>
<h3>4. Configure SendGrid user secrets for email working in Developer PowerShell using following commands:</h3>  

        dotnet user-secrets set SendGridUser Zaadaptuj.pl
And after it next command:

        dotnet user-secrets set SendGridKey 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
<h3>5. Run and enjoy the app!</h3>  

        
