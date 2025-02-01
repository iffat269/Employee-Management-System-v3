using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

public class BaseManager<T> where T : class
{
    private readonly EMSDbContext _context;

    public BaseManager(EMSDbContext context)
    {
        _context = context;
    }

    // Add an entity
    //protected int AddUpdateEntity(T entity)
    //{
    //    _context.Set<T>().Add(entity);
    //    _context.SaveChanges();
    //    var entityId = (int)typeof(T).GetProperty("Id").GetValue(entity); // Assuming the entity has an "Id" property
    //    return entityId;
    //}
    protected int AddUpdateEntity<T>(T entity, bool keepDettached = true) where T : class
    {
        try
        {
            if (_context.Entry<T>(entity).IsKeySet)
                _context.Update<T>(entity);
            else
                _context.Add<T>(entity);

            _context.SaveChanges();

            if (keepDettached)
            {
                _context.Entry<T>(entity).State = EntityState.Detached;
            }
            int entityId = (int)typeof(T).GetProperty("Id")?.GetValue(entity);
            return entityId;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            throw;
        }
    }

    // Delete an entity by id
    protected bool Delete(int id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    // Get all entities
    protected List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    // Update an entity
    protected bool Update(T entity)
    {
        var existingEntity = _context.Set<T>().Find(typeof(T).GetProperty("Id").GetValue(entity));
        if (existingEntity == null)
        {
            return false; // Entity not found
        }

        _context.Set<T>().Update(entity);
        _context.SaveChanges();
        return true;
    }

    protected T Find<T>(int id) where T : class
    {
        // Attempt to find the entity using the primary key (id)
        return _context.Set<T>().Find(id);
    }
    //protected IList<T> GetListData<T>(string interpolatedStoredProc) where T : class
    //{
    //    try
    //    {
    //        return _context.Set<T>().FromSqlRaw(interpolatedStoredProc).AsNoTracking().ToList();
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.ToString());

    //        throw;
    //    }
    //}
    //protected IList<T> GetListData<T>(string interpolatedStoredProc) where T : class
    //{
    //    try
    //    {
    //        // Execute the raw SQL query for the stored procedure
    //        return _context.Set<T>()
    //                       .FromSqlRaw(interpolatedStoredProc)  // Use FromSqlRaw without DbSet
    //                       .AsNoTracking()  // No change tracking (read-only)
    //                       .ToList();
    //    }
    //    catch (Exception ex)
    //    {
    //        // Log the error
    //        Debug.WriteLine(ex.ToString());
    //        throw;
    //    }
    //}
    protected IList<T> GetListData<T>(string interpolatedStoredProc) where T : class
    {
        try
        {
            // Execute the raw SQL query for the stored procedure
            return _context.Set<T>()
                           .FromSqlRaw(interpolatedStoredProc)  // Use FromSqlRaw without DbSet
                           .AsNoTracking()  // No change tracking (read-only)
                           .ToList();
        }
        catch (Exception ex)
        {
            // Log the error
            Debug.WriteLine(ex.ToString());
            throw;
        }
    }

    //public async Task<TDto> GetEntityByIdAsync<TDto>(int id, string storedProcedureName)
    //{
    //    // Dynamically build the SQL query with the stored procedure name and id
    //    var sqlQuery = $"EXEC {storedProcedureName} @Id = {id}";

    //    // Get the type of the DTO dynamically
    //    var dtoType = typeof(TDto);

    //    // Use reflection to create an instance of the DTO type
    //    var result = await _context.Set(dtoType) // Uses the DbSet for the appropriate entity
    //        .FromSqlRaw(sqlQuery)
    //        .ToListAsync();

    //    // Map the result to the requested DTO using reflection
    //    if (result != null && result.Count > 0)
    //    {
    //        var entity = result.First();
    //        var dtoInstance = Activator.CreateInstance<TDto>();

    //        // Map properties dynamically
    //        foreach (var property in dtoType.GetProperties())
    //        {
    //            var entityProperty = entity.GetType().GetProperty(property.Name);
    //            if (entityProperty != null && entityProperty.CanRead)
    //            {
    //                property.SetValue(dtoInstance, entityProperty.GetValue(entity));
    //            }
    //        }

    //        return dtoInstance;
    //    }

    //    return default(TDto);
    //}
}
