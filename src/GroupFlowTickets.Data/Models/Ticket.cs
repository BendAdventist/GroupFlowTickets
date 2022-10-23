namespace GroupFlowTickets.Data.Models;

public class Ticket
{
    public Guid TicketId { get; init; } = Guid.NewGuid();

    
    /// <summary>
    /// The group that this ticket belongs to.
    /// </summary>
    public Guid GroupId { get; set; }
    
    /// <inheritdoc cref="GroupId"/>
    public Group Group { get; set; } = null!;

    
    /// <summary>
    /// The user that created this ticket.
    /// </summary>
    public Guid CreatedByUserId { get; set; }
    
    /// <inheritdoc cref="CreatedByUserId"/>
    public ApplicationUser CreatedByUser { get; set; } = null!;
    
    
    /// <summary>
    /// If applicable, the reservation under which this ticket was created.
    /// </summary>
    public Guid? ReservationId { get; set; } = null;
    public Reservation? Reservation { get; set; } = null;
}