using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using DMicroservices.DataAccess.DynamicQuery;
using GraphQL.Types;
using Newtonsoft.Json;
using ProjectService.Data.Context;
using ProjectService.Data.Models;
using RestSharp;
using UserService.Data.Models;

namespace Microservices.CoreBff.GraphTypes
{
    /// <summary>
    /// Project graphql type
    /// </summary>
    public class ProjectGraphType : ObjectGraphType<ProjectModel>
    {
        public ProjectGraphType()
        {
            Field(x => x.Id).Description("Project Id");
            Field(x => x.Title, true).Description("Project Title");





            Field<ListGraphType<UserGraphType>>(
                "roles",
                resolve: context =>
                {
                    var client = new RestClient($"http://localhost:8022/Roles/GetByProjectId/{context.Source.Id}");
                    var request = new RestRequest(Method.GET);
                    IRestResponse response = client.Execute(request);
                    List<ProjectRoleModel> roles = JsonConvert.DeserializeObject<List<ProjectRoleModel>>(response.Content);


                    dynamic eo = new ExpandoObject();

                    eo.Filter = new List<FilterItemDto>();
                    eo.Filter.Add(new FilterItemDto()
                    {
                        PropertyName = "UserId",
                        Operation = "IN",
                        PropertyValue = string.Join(',', roles.Select(x => x.UserId).Distinct().ToArray())
                    });


                    var client2 = new RestClient("http://localhost:8021/DynamicQuery");
                    var request2 = new RestRequest(Method.POST);
                    request2.RequestFormat = DataFormat.Json;
                    request2.AddJsonBody(eo);

                    
                    IRestResponse response2 = client2.Execute(request2);

                    return JsonConvert.DeserializeObject<List<UserModel>>(response2.Content);
                }
            );


        }
    }
}
