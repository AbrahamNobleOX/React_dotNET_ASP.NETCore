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

# To start a new project

dotnet new sln | - This will create a new solution file
dotnet new webapi -o API | - This will create a new webapi project
dotnet sln add API | - This will add the solution file to the API project

# To run

Do "dotnet run" inside API folder

# Package installation with nuget

microsoft.entityframeworkcore.sqlite
microsoft.entityframeworkcore.design
