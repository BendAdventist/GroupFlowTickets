using GroupFlowTickets.Data.Models;

namespace GroupFlowTickets.EventHandling;

public static class EventEvents
{
    public static event EventEventHandler? EventCreated;
    public static event EventEventHandler? EventUpdated;
    public static event EventEventHandler? EventDeleted;

    public static void RaiseEventCreated(object sender, EventEventArgs e)
    {
        EventCreated?.Invoke(sender, e);
    }

    public static void RaiseEventCreated(object sender, Event createdEvent)
    {
        EventCreated?.Invoke(sender, new EventEventArgs(createdEvent));
    }
    
    public static void RaiseEventUpdated(object sender, EventEventArgs e)
    {
        EventUpdated?.Invoke(sender, e);
    }
    
    public static void RaiseEventUpdated(object sender, Event updatedEvent)
    {
        EventUpdated?.Invoke(sender, new EventEventArgs(updatedEvent));
    }
    
    public static void RaiseEventDeleted(object sender, EventEventArgs e)
    {
        EventDeleted?.Invoke(sender, e);
    }
    
    public static void RaiseEventDeleted(object sender, Event deletedEvent)
    {
        EventDeleted?.Invoke(sender, new EventEventArgs(deletedEvent));
    }
}

public delegate void EventEventHandler(object sender, EventEventArgs e);

public class EventEventArgs : EventArgs
{
    public EventEventArgs(Event @event)
    {
        Event = @event;
    }
    
    public Event Event { get; }
}