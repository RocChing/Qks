using System.Collections.Generic;

namespace Qks.GraphQL.Abstractions
{
    public interface INamedQueryProvider
    {
        IDictionary<string, string> Resolve();
    }
}