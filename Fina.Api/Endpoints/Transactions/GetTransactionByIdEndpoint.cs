using Fina.Api.Common.Api;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;

namespace Fina.Api.Endpoints.Transactions;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
        .WithName("Transaction: Get By Id")
        .WithSummary("Recupera uma transação")
        .WithDescription("Recupera uma transação")
        .WithOrder(4)
        .Produces<Response<Transaction?>>();
private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id)
    {
        var request = new GetTransactionByIdRequest
        {
            UserId = ApiConfiguration.UserId,
            Id = id
        };

        var result = await handler.GetByIdAsync(request);

        if (result.IsSuccess)
            return TypedResults.Ok(result);

        return TypedResults.BadRequest(result);
    }
}
