using EmployeePlatform.Business;
using EmployeePlatform.Entities;
using EmployeePlatform.GraphQLServer.Helpers;
using GraphQL.Types;

namespace EmployeePlatform.GraphQLServer.Types
{
    public class AreaType : ObjectGraphType<AreaDTO>
    {
        public AreaType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.CreatedAt);
            Field(x => x.CreatedBy);
            Field(x => x.ModifiedAt);
            Field(x => x.ModifiedBy);
            FieldAsync<ListGraphType<SubareaType>>("subareas",
             resolve: async context =>
             {
                 return await new SubareaBL(contextServiceLocator.SubareaRepository).GetAllForArea(context.Source.Id);
             });
        }
    }
}
