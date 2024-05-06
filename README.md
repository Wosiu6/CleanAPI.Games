# Clean Architecture

This is my attempt at learning Clean Architecture in .NET.
Credits to https://github.com/ardalis/CleanArchitecture for the base.

## API use cases
This API allows you to perform a CRUD operation on Users and Games, User can have many Games and Games have many achievements. I plan to integrate and automatically pull data from Steam to populate these in the future.

## To Do:
- Write unit tests
- Migrations
- Mapping Entities to DTO (or implementing auto mapper) - currently, I use extension methods.
