using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;

namespace Bravi.Backend.Endpoints;

public static class ContactMethodEndpoints
{
    public static WebApplication MapContactMethodEndpoints(this WebApplication app)
    {
        app.MapGet("/api/contacts/{contactId:Guid}/methods", async (IContactMethodRepository service, Guid contactId) =>
        {
            try
            {
                var persons = await service.ListAsync(contactId);

                return Results.Ok(persons);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("ContactMethod");

        app.MapPost("/api/contacts/{contactId:Guid}/methods", async (IContactMethodRepository service, Guid contactId, ContactMethod contactMethod) =>
        {
            try
            {
                contactMethod.Id = Guid.NewGuid();
                contactMethod.ContactId = contactId;

                await service.AddAsync(contactMethod);

                return Results.Created($"/api/contacts/{contactMethod.Id}", contactMethod);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("ContactMethod");

        app.MapPut("/api/contacts/{contactId:Guid}/methods/{id:Guid}", async (IContactMethodRepository service, Guid contactId, Guid id, ContactMethod contactMethod) =>
        {
            try
            {
                contactMethod.ContactId = contactId;

                await service.UpdateAsync(contactMethod);

                return Results.Ok(contactMethod);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("ContactMethod");

        app.MapDelete("/api/contacts/{contactId:Guid}/methods/{id:Guid}", async (IContactMethodRepository service, Guid contactId, Guid id) =>
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
        .WithTags("ContactMethod");

        return app;
    }
}