namespace MagCoders.Orders.Shared.Abstractions.Errors;

/// <summary>
/// Orders api error Response.
/// </summary>
/// <param name="Type">Type.</param>
/// <param name="Title">Title of an Error.</param>
/// <param name="Status">Status Code.</param>
/// <param name="TraceId">Trace Id.</param>
/// <param name="Errors">List of Errors.</param>
public record ApiError(string Type, string Title, int Status, string TraceId, List<Error> Errors);