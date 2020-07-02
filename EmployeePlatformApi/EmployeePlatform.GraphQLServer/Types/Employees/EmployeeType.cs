using EmployeePlatform.Business;
using EmployeePlatform.Entities;
using EmployeePlatform.GraphQLServer.Helpers;
using GraphQL.Types;

namespace EmployeePlatform.GraphQLServer.Types
{
    public class EmployeeType : ObjectGraphType<EmployeeDTO>
    {
        public EmployeeType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.IdentificationNumber);
            Field(x => x.CreatedAt);
            Field(x => x.CreatedBy);
            Field(x => x.ModifiedAt);
            Field(x => x.ModifiedBy);
            FieldAsync<SubareaType>("subarea",
             resolve: async context =>
             {
                 return await new SubareaBL(contextServiceLocator.SubareaRepository).GetById(context.Source.SubareaId);
             });
            FieldAsync<IdentificationTypesType>("identificationType",
             resolve: async context =>
             {
                 return await new IdentificationTypeBL(contextServiceLocator.identificationTypeRepository).GetById(context.Source.IdentificationTypeId);
             });
        }
    }
}
