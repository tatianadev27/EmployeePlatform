using GraphQL.Types;
using EmployeePlatform.GraphQLServer.Helpers;
using EmployeePlatform.Business;
using EmployeePlatform.Entities;

namespace EmployeePlatform.GraphQLServer.Types
{
    public class SubareaType : ObjectGraphType<SubareaDTO>
    {
        public SubareaType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.CreatedAt);
            Field(x => x.CreatedBy);
            Field(x => x.ModifiedAt);
            Field(x => x.ModifiedBy);
            FieldAsync<AreaType>("area",
             resolve: async context =>
             {
                 return await new AreaBL(contextServiceLocator.AreaRepository).GetById(context.Source.AreaId);
             });
        }
    }
}
