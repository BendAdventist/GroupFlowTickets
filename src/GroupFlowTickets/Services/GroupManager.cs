using GroupFlowTickets.Data;
using GroupFlowTickets.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupFlowTickets.Services;

public class GroupManager
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    
    
    public GroupManager(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    
    public event GroupEventHandler? GroupCreated;
    public event GroupEventHandler? GroupUpdated;
    public event GroupEventHandler? GroupDeleted;


    public void Create(Group groupToCreate)
    {
        using var database = _dbContextFactory.CreateDbContext();
        database.Groups.Add(groupToCreate);
        database.SaveChanges();

        GroupCreated?.Invoke(new GroupEventArgs(groupToCreate));
    }

    public async ValueTask<Group?> GetGroup(Guid eventId)
    {
        await using var database = await _dbContextFactory.CreateDbContextAsync();
        return await database.Groups.FindAsync(eventId);
    }

    public void Update(Group groupToUpdate)
    {
        using var database = _dbContextFactory.CreateDbContext();
        database.Groups.Attach(groupToUpdate);
        database.Update(groupToUpdate);
        database.SaveChanges();
        
        GroupUpdated?.Invoke(new GroupEventArgs(groupToUpdate));
    } 
    
    public void Delete(Group groupToDelete)
    {
        using var database = _dbContextFactory.CreateDbContext();
        database.Groups.Attach(groupToDelete);
        database.Remove(groupToDelete);
        database.SaveChanges();
        
        GroupDeleted?.Invoke(new GroupEventArgs(groupToDelete));
    }


    private IQueryable<Group> QueryGroups(ApplicationDbContext database)
    {
        return database.Groups.OrderBy(g => g.Sequence);
    }
}

public delegate void GroupEventHandler(GroupEventArgs e);

public class GroupEventArgs : EventArgs
{
    public GroupEventArgs(Group group)
    {
        Group = group;
    }
    
    public Group Group { get; }
}