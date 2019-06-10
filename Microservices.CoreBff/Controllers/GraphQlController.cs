using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microservices.CoreBff.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.CoreBff.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter documentExecuter;
        private readonly ISchema schema;
        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            this.documentExecuter = documentExecuter;
            this.schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var executionOptions = new ExecutionOptions { Schema = schema, Query = query.Query };
            try
            {
                var result = await documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);
                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}