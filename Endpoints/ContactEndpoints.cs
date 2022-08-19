using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;

namespace Bravi.Backend.Endpoints;

public static class ContactEndpoints
{
    public static WebApplication MapContactEndpoints(this WebApplication app)
    {
        app.MapGet("/api/contacts", async (IContactRepository service) =>
        {
            try
            {
                var persons = await service.ListAsync();

                return Results.Ok(persons);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Contact");

        app.MapGet("/api/contacts/{id:Guid}", async (IContactRepository service, Guid id) =>
        {
            try
            {
                var person = await service.FindAsync(id);

                return Results.Ok(person);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Contact");

        app.MapPost("/api/contacts", async (IContactRepository service, Contact contact) =>
        {
            try
            {
                contact.Id = Guid.NewGuid();

                await service.AddAsync(contact);

                return Results.Created($"/api/contacts/{contact.Id}", contact);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Contact");

        app.MapPut("/api/contacts/{id:Guid}", async (IContactRepository service, Contact contact) =>
        {
            try
            {
                await service.UpdateAsync(contact);

                return Results.Ok(contact);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Contact");

        app.MapDelete("/api/contacts/{id:Guid}", async (IContactRepository service, Guid id) =>
        {
            try
            {
                await service.DeleteAsync(id);

                return Results.Ok();
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Contact");

        return app;
    }
}