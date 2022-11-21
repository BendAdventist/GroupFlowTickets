using GroupFlowTickets.Data.Models;

namespace GroupFlowTickets.UnsavedModels;

public class UnsavedEvent
{
    private Event _originalEvent;
    
    public UnsavedEvent(Event @event)
    {
        _originalEvent = @event;

        Name = _originalEvent.Name;
        StartDate = _originalEvent.StartDateTime?.Date;
        StartTime = _originalEvent.StartDateTime?.TimeOfDay;
        MinIntervalInSeconds = _originalEvent.MinIntervalInSeconds;
    }
    
    public string Name { get; set; }
    
    public DateTime? StartDate { get; set; }
    public TimeSpan? StartTime { get; set; }
    public DateTime? StartDateTime => StartDate + StartTime;
    
    public uint MinIntervalInSeconds { get; set; }
    
    public bool IsChanged => !(
        Name == _originalEvent.Name &&
        StartDateTime == _originalEvent.StartDateTime &&
        MinIntervalInSeconds == _originalEvent.MinIntervalInSeconds
    );

    public Event GetUpdatedEvent()
    {
        return new()
        {
            EventId = _originalEvent.EventId,
            Name = Name,
            StartDateTime = StartDateTime,
            MinIntervalInSeconds = MinIntervalInSeconds
        };
    }
}