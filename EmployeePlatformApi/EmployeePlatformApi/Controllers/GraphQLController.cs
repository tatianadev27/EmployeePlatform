using EmployeePlatform.GraphQLServer;
using EmployeePlatformApi.Extensions;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePlatformApi.Controllers
{

    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query, [FromServices] IEnumerable<IValidationRule> validationRules)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs,
                ValidationRules = validationRules,
                UserContext = new GraphQLUserContext
                {
                    User = User
                },
                ExposeExceptions = true,
                EnableMetrics = true,
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
