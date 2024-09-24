# Restore Udemy Course repository

![Deploy status](https://github.com/trycatchlearn/Restore/actions/workflows/docker-push.yml/badge.svg)

This is the updated repository for the .Net 7.0, React 18 and React Router 6 version of the course refreshed as at February 2023

View a demo of this app [here](https://restore.fly.dev).

You can see how this app was made by checking out the Udemy course for this here (with discount)

[Udemy course](https://www.udemy.com/course/learn-to-build-an-e-commerce-store-with-dotnet-react-redux/?couponCode=GITHUBRESTORE)

If you are looking for the repository for the version of this app created on .Net 6.0 and Angular v12 then this is available here:

https://github.com/TryCatchLearn/Restore-v6

# Start

<!-- Abraham's Note Starts here -->

dotnet
dotnet --version
dotnet --h

# To create a new project

dotnet new sln | - This will create a new solution file
dotnet new webapi -o API | - This will create a new webapi project
dotnet sln add API | - This will add the solution file to the API project

# To run

Do "dotnet run" inside API folder or "dotnet watch --no-hot-reload" to have it keep track of changes

# Package installation with nuget

microsoft.entityframeworkcore.sqlite
microsoft.entityframeworkcore.design

# To install tool for data migration

dotnet tool install --global dotnet-ef --version 8.0.0

# To see already installed tools for data migrations

dotnet tool list -g

# To update tool for data migration

dotnet tool update --global dotnet-ef

# To run data migration

dotnet ef migrations add InitialCreate -o Data/Migrations

# To Create the database

dotnet ef database update

https://json2ts.dev/
https://learn.microsoft.com/en-us/ef/core/modeling/relationships
https://mui.com/material-ui/react-switch/
https://reactrouter.com/en/main/start/tutorial
https://legacy.reactjs.org/docs/create-a-new-react-app.html
https://react.dev/learn/typescript
https://code.visualstudio.com/docs/editor/github-copilot
https://www.npmjs.com/package/react-toastify
https://jwt.ms/

https://www.youtube.com/results?search_query=creating+a+npm+package
https://stripe.com/docs/stripe-cli
https://stripe.com/docs/testing#cards
https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows#secret-manager

Git Commands
git rm --cached API/appsettings.json
