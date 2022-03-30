using System.Collections.Generic;

namespace BuildingBlocks.CQRS.Queries;

public interface IPagedFilter<TResult, in TQuery> where TQuery : IQuery
{
    PagedResult<TResult> Filter(IEnumerable<TResult> values, TQuery query);
}