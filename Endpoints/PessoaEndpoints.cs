using Bravi.Backend.Domain.Entities;
using Bravi.Backend.Domain.Interfaces;

namespace Bravi.Backend.Endpoints;

public static class PessoaEndpoints
{
    public static WebApplication MapPessoaEndpoints(this WebApplication app)
    {
        app.MapGet("/api/persons", async (IPessoaService service) =>
        {
            try
            {
                var persons = await service.GetAllAsync();

                return Results.Ok(persons);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Person");

        app.MapGet("/api/persons/{id:Guid}", async (IPessoaService service, Guid id) =>
        {
            try
            {
                var person = await service.GetAsync(id);

                return Results.Ok(person);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Person");

        app.MapPost("/api/persons", async (IPessoaService service, Pessoa pessoa) =>
        {
            try
            {
                pessoa.Id = Guid.NewGuid();

                await service.AddAsync(pessoa);

                return Results.Created($"/api/persons/{pessoa.Id}", pessoa);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Person");

        app.MapPut("/api/persons/{id:Guid}", async (IPessoaService service, Pessoa pessoa) =>
        {
            try
            {
                await service.UpdateAsync(pessoa);

                return Results.Ok(pessoa);
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }
        })
        .WithTags("Person");

        app.MapDelete("/api/persons/{id:Guid}", async (IPessoaService service, Guid id) =>
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
        .WithTags("Person");

        return app;
    }
}