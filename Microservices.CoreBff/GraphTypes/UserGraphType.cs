using GraphQL.Types;
using UserService.Data.Models;

namespace Microservices.CoreBff.GraphTypes
{
    /// <summary>
    /// User graphql type
    /// </summary>
    public class UserGraphType : ObjectGraphType<UserModel>
    {
        public UserGraphType()
        {
            Field(x => x.Id).Description("User Id");
            Field(x => x.UserName).Description("User name");
        }
    }
}
