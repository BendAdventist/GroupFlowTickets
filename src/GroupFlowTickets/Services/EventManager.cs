using GroupFlowTickets.Data;
using GroupFlowTickets.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupFlowTickets.Services;

public class EventManager
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    
    // This is an example of dependency injection. The same thing can be accomplished in .razor files with
    // the @inject directive. The dependency (aka "Service") is set up in Program.cs once, and then any
    // code that needs it can inject it like so. This way, you don't need to manually create the object.
    // More information: https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection
    public EventManager(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    
    public event EventEventHandler? EventCreated;
    public event EventEventHandler? EventUpdated;
    public event EventEventHandler? EventDeleted;


    public void Create(Event eventToCreate)
    {
        using var database = _dbContextFactory.CreateDbContext();
        database.Events.Add(eventToCreate);
        database.SaveChanges();

        EventCreated?.Invoke(new EventEventArgs(eventToCreate));
    }

    public void Update(Event eventToUpdate)
    {
        using var database = _dbContextFactory.CreateDbContext();
        database.Events.Attach(eventToUpdate);
        database.Update(eventToUpdate);
        database.SaveChanges();
        
        EventUpdated?.Invoke(new EventEventArgs(eventToUpdate));
    } 
    
    public void Delete(Event eventToDelete)
    {
        using var database = _dbContextFactory.CreateDbContext();
        database.Events.Attach(eventToDelete);
        database.Remove(eventToDelete);
        database.SaveChanges();
        
        EventDeleted?.Invoke(new EventEventArgs(eventToDelete));
    }
}

public delegate void EventEventHandler(EventEventArgs e);

public class EventEventArgs : EventArgs
{
    public EventEventArgs(Event @event)
    {
        Event = @event;
    }
    
    public Event Event { get; }
}