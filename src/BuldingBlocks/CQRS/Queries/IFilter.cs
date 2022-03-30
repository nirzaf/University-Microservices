using System.Collections.Generic;

namespace BuildingBlocks.CQRS.Queries;

public interface IFilter<TResult, in TQuery> where TQuery : IQuery
{
    IEnumerable<TResult> Filter(IEnumerable<TResult> values, TQuery query);
}