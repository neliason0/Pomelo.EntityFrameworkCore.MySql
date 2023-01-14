#!/usr/bin/env bash
PROJECT="../EFCore.MySql.IntegrationTests.csproj"

dotnet tool restore;

rm -f ../Migrations/*.cs

dotnet ef database drop -f --project $PROJECT
dotnet ef migrations add Initial --project $PROJECT

dotnet ef database update --project $PROJECT