using Microsoft.EntityFrameworkCore;

namespace GroupFlowTickets.Data.Models;

public class Group
{
    public Guid GroupId { get; init; } = Guid.NewGuid();

    
    /// <summary>
    /// The number of tickets allotted for reservations.
    /// </summary>
    public uint MaxReservations { get; set; } = 10;
    
    /// <summary>
    /// The number of tickets allotted for walk-ins.
    /// </summary>
    public uint MaxWalkIns { get; set; } = 5;
    
    /// <summary>
    /// The number of tickets allotted for overflow.
    /// </summary>
    public uint Overflow { get; set; } = 5;

    
    /// <summary>
    /// The minimum time at which this group can be released. Useful for creating a scheduled break.
    /// </summary>
    public DateTime? MinReleaseTime { get; set; } = null;
    
    /// <summary>
    /// Determines whether the group has been released.
    /// </summary>
    public bool HasBeenReleased { get; set; }


    /// <summary>
    /// Where this group comes in the event.
    /// </summary>
    public int Sequence { get; set; }
 
    
    /// <summary>
    /// The event that this group belongs to.
    /// </summary>
    public Guid EventId { get; set; }
    
    /// <inheritdoc cref="EventId"/>
    public Event Event { get; set; } = null!;
    
    
    /// <summary>
    /// The tickets that have been created for this group.
    /// </summary>
    public List<Ticket> Tickets { get; } = new();
}