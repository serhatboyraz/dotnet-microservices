using System;
using GraphQL.Types;
using Microservices.CoreBff.GraphQueries;

namespace Microservices.CoreBff.GraphSchemas
{
    /// <summary>
    /// Project graphql schema
    /// </summary>
    public class ProjectSchema : Schema
    {
        public ProjectSchema(Func<Type, GraphType> resolveType) : base(resolveType)
        {
            Query = (ProjectQuery)resolveType(typeof(ProjectQuery));
        }
    }
}
