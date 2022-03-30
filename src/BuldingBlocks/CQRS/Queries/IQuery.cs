namespace BuildingBlocks.CQRS.Queries;

//Marker
public interface IQuery
{
}

public interface IQuery<T> : IQuery
{
}