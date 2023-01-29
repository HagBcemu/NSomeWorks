using System.Collections.Generic;

namespace NSomeWorks.Model;

public class CollectionData<T> : Validation
{
    public IReadOnlyCollection<T> Data { get; init; }
}