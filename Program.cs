// Add WEB dependencies
//
using Microsoft.AspNetCore.Mvc;
using TPToDoList;

//----------------------------
// Create Web Application
//----------------------------
// Create builder
var builber =  WebApplication.CreateBuilder();

// Add dependance injection
builber.Services.AddSingleton<ToDoService>();

// Build app
var App = builber.Build();

//----------------------------
// Add API Rest before Run
//----------------------------
// Get all to do list
App.MapGet("/todos", ([FromServices] ToDoService service) => Results.Ok(service.GetAll()));

// Get by id
App.MapGet("/todos/{id}", ([FromRoute] int id, [FromServices] ToDoService service) =>
{
    // check if object exist
    var toDoItem = service.GetById(id);
    if (toDoItem == null)
        return Results.NotFound();

    // return without error
    return Results.Ok(toDoItem);
});

// Get actives
App.MapGet("/todos/actives", ([FromServices] ToDoService service) => Results.Ok(service.GetAllActives()));

// Post 
App.MapPost("/todos", ([FromBody] string title, [FromServices] ToDoService service) => Results.Ok(service.Add(title)));


// Put 
App.MapPut("/todos/{id}", ([FromRoute] int id, [FromBody] ToDo toDo, [FromServices] ToDoService service) =>
{
    // Check if exist
    var toDoItem = service.GetById(id);
    if (toDoItem == null)
        return Results.NotFound();

    // Update object
    var toDoUpdated = service.Update(id, toDo.Title, toDo.EndDate);
    return Results.Ok(toDoUpdated);
});

// Delete
App.MapDelete("/todos/{id}", ([FromRoute] int id, [FromServices] ToDoService service) =>
{
    // Check if exist
    var toDoItem = service.GetById(id);
    if (toDoItem == null)
         return Results.NotFound();

    // Remove object
    service.Delete(id);
    return Results.NoContent();
});

//----------------------------
// Create Web Application
//----------------------------
// Run Aplliction
// All API must be added before the call of the run
App.Run();


