using ExampleMicroservices.DataAccess.UnitOfWork;
using GraphQL.Types;
using Microservices.CoreBff.GraphTypes;
using Newtonsoft.Json;
using ProjectService.Data.Context;
using ProjectService.Data.Enum;
using ProjectService.Data.Models;
using RestSharp;

namespace Microservices.CoreBff.GraphQueries
{
    /// <summary>
    /// Project graph query
    /// </summary>
    public class ProjectQuery : ObjectGraphType
    {
        public ProjectQuery()
        {
            Field<ProjectGraphType>(
                "project",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id", Description = "Project Id" }
                ),
                resolve: context =>
                {
                    long id = context.GetArgument<long>("id");
                    var client = new RestClient($"http://localhost:8022/{id}");
                    var request = new RestRequest(Method.GET);
                    IRestResponse response = client.Execute(request);
                    return JsonConvert.DeserializeObject<ProjectModel>(response.Content);
                });

            Field<ListGraphType<ProjectGraphType>>(
                "projects",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "status", Description = "Project Status" }
                ),
                resolve: context =>
                {
                    ProjectStatusEnum status = context.GetArgument<ProjectStatusEnum>("status");
                    return null;
                });
        }
    }
}
