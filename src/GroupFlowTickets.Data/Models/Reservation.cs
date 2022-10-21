namespace GroupFlowTickets.Data.Models;

public class Reservation
{
    public Guid ReservationId { get; set; }
    
    
    /// <summary>
    /// The number of tickets that are reserved.
    /// </summary>
    public uint NumberOfTickets { get; set; }
    
    
    /// <summary>
    /// The group that this reservation was made for.
    /// </summary>
    public Guid GroupId { get; set; }

    /// <inheritdoc cref="GroupId"/>
    public Group Group { get; set; } = null!;
    
    
    /// <summary>
    /// The user who made this reservation.
    /// </summary>
    /// <remarks>
    /// Typically a guest, though a staff member may have made it over the phone.
    /// </remarks>
    public Guid ReservedByUserId { get; set; }
    
    /// <inheritdoc cref="ReservedByUserId"/>
    public ApplicationUser ReservedByUser { get; set; } = null!;
    

    /// <summary>
    /// The tickets that have been created as a result of the reservation holder checking in.
    /// </summary>
    public List<Ticket> ClaimedTickets { get; set; } = new();
}