using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BuildingBlocks.Types;

public abstract class BaseAggregateRoot<TA, TKey> : BaseEntity<TKey>, IAggregateRoot<TKey>
    where TA : class, IAggregateRoot<TKey>
{
    private readonly Queue<IDomainEvent> _events = new();
    //  public long Version { get; set; }

    protected BaseAggregateRoot()
    {
    }

    protected BaseAggregateRoot(TKey id) : base(id)
    {
    }

    public IEnumerable<IDomainEvent> Events => _events.ToImmutableArray();

    public void ClearEvents()
    {
        _events.Clear();
    }

    protected void AddEvent(IDomainEvent @event)
    {
        _events.Enqueue(@event);

        //   this.Apply(@event);

        // this.Version++;
    }

    // protected abstract void Apply(IDomainEvent<TKey> @event);

    #region Factory

    // private static readonly ConstructorInfo CTor;

    // static BaseAggregateRoot()
    // {
    //     var aggregateType = typeof(TA);
    //     CTor = aggregateType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
    //         null, new Type[0], new ParameterModifier[0]);
    //     if (null == CTor)
    //         throw new AggregateException($"Unable to find required private parameterless constructor for Aggregate of type '{aggregateType.Name}'");
    // }
    //
    public static TA Create(IEnumerable<IDomainEvent<TKey>> events)
    {
        if (null == events || !events.Any())
            throw new ArgumentNullException(nameof(events));
        // var result = (TA)CTor.Invoke(new object[0]);
        //
        // var baseAggregate =  result as BaseAggregateRoot<TA, TKey>;
        // if (baseAggregate != null) 
        //     foreach (var @event in events)
        //         baseAggregate.AddEvent(@event);
        //
        // result.ClearEvents();
        //
        // return result;
        return null;
    }

    #endregion Factory
}