namespace BuildingBlocks.Exception;

public interface IExceptionToResponseMapper
{
    public ExceptionResponse Map(System.Exception exception);
}