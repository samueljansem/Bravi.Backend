using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;

namespace Bravi.Backend.Endpoints;

public static class ContatoEndpoints
{
    public static WebApplication MapContatoEndpoints(this WebApplication app)
    {
        app.MapGet("/api/persons/{personId:Guid}/contacts", async (IContatoService service, Guid personId) =>
        {
            try
            {
                var persons = await service.GetAllAsync(personId);

                return Results.Ok(persons);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Contact");

        app.MapGet("/api/persons/{personId:Guid}/contacts/{id:Guid}", async (IContatoService service, Guid id) =>
        {
            try
            {
                var contact = await service.GetAsync(id);

                return Results.Ok(contact);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Contact");

        app.MapPost("/api/persons/{personId:Guid}/contacts", async (IContatoService service, Guid personId, Contato contato) =>
        {
            try
            {
                contato.Id = Guid.NewGuid();
                contato.PessoaId = personId;

                await service.AddAsync(contato);

                return Results.Created($"/api/contacts/{contato.Id}", contato);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Contact");

        app.MapPut("/api/persons/{personId:Guid}/contacts/{id:Guid}", async (IContatoService service, Guid personId, Guid id, Contato contato) =>
        {
            try
            {
                contato.PessoaId = personId;

                await service.UpdateAsync(contato);

                return Results.Ok(contato);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Contact");

        app.MapDelete("/api/persons/{personId:Guid}/contacts/{id:Guid}", async (IContatoService service, Guid personId, Guid id) =>
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