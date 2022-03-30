using Newtonsoft.Json;

namespace BuildingBlocks.CQRS.Events;

public class RejectedEvent : IRejectedEvent
{
    [JsonConstructor]
    public RejectedEvent(string reason, string code)
    {
        Reason = reason;
        Code = code;
    }

    public string Code { get; }

    public string EventName { get; }
    public string Reason { get; }

    public static IRejectedEvent For(string name)
    {
        return new RejectedEvent("There was an error when executing: " +
                                 $"{name}", $"{name}_error");
    }
}