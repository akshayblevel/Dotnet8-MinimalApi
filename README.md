```CSharp
app.MapGet("/vehicles", async (VehicleDb db) =>
    await db.Vehicles.ToListAsync());
```
```CSharp
app.MapGet("/vehicles/{id}", async (int id, VehicleDb db) =>
    await db.Vehicles.FindAsync(id));
```
```CSharp
app.MapPost("/vehicles", async (Vehicle vehicle, VehicleDb db) =>
{
    db.Vehicles.Add(vehicle);
    await db.SaveChangesAsync();
    return Results.Created($"/vehicles/{vehicle.Id}", vehicle);
});
```
```CSharp
app.MapPut("/vehicles/{id}", async (int id, Vehicle vehicle, VehicleDb db) =>
{
    var veh = await db.Vehicles.FindAsync(id);
    if (veh == null) return Results.NotFound();
    
    veh.Name = vehicle.Name;
    veh.IsComplete = vehicle.IsComplete;

    await db.SaveChangesAsync();
    return Results.NoContent();
});
```
```CSharp
app.MapDelete("/vehicles/{id}", async (int id, VehicleDb db) =>
{
    if(await db.Vehicles.FindAsync(id) is Vehicle vehicle)
    {
        db.Vehicles.Remove(vehicle);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});
```
