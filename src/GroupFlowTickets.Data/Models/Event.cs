namespace GroupFlowTickets.Data.Models;

public class Event
{
    public Guid EventId { get; init; } = Guid.NewGuid();

    
    /// <summary>
    /// The name of the event.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// The date and time when the first group should start.
    /// </summary>
    public DateTime? StartDateTime { get; set; }

    /// <summary>
    /// The minimum number of seconds that should elapse between groups being released.
    /// </summary>
    public uint MinIntervalInSeconds { get; set; } = 4 * 60;
    

    /// <summary>
    /// All of the groups belonging to this event.
    /// </summary>
    public List<Group> Groups { get; } = new();
}