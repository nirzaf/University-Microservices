using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BuildingBlocks.CQRS.Queries;

public class PagedResult<T> : PagedResultBase
{
    protected PagedResult()
    {
        Items = Enumerable.Empty<T>();
    }

    [JsonConstructor]
    protected PagedResult(IEnumerable<T> items,
        int currentPage, int resultsPerPage,
        int totalPages, long totalResults) :
        base(currentPage, resultsPerPage, totalPages, totalResults)
    {
        Items = items;
    }

    public IEnumerable<T> Items { get; }

    public bool IsEmpty => Items is null || !Items.Any();
    public bool IsNotEmpty => !IsEmpty;

    public static PagedResult<T> Empty => new();

    public static PagedResult<T> Create(IEnumerable<T> items,
        int currentPage, int resultsPerPage,
        int totalPages, long totalResults)
    {
        return new PagedResult<T>(items, currentPage, resultsPerPage, totalPages, totalResults);
    }

    public static PagedResult<T> From(PagedResultBase result, IEnumerable<T> items)
    {
        return new PagedResult<T>(items, result.CurrentPage, result.ResultsPerPage,
            result.TotalPages, result.TotalResults);
    }

    public PagedResult<U> Map<U>(Func<T, U> map)
    {
        return PagedResult<U>.From(this, Items.Select(map));
    }
}