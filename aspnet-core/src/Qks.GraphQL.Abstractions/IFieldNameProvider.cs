using System;

namespace Qks.GraphQL.Abstractions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class GraphQLFieldNameAttribute : Attribute
    {
        public GraphQLFieldNameAttribute(string field, string mapped)
        {
            Field = field;
            Mapped = mapped;
        }

        public string Field { get; }
        public string Mapped { get; }
    }
}
