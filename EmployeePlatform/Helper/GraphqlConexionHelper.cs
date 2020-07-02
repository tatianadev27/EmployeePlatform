using GraphQl.NetStandard.Client;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeePlatform.Helper
{
    public class GraphqlConexionStringHelper
    {
        private readonly IIdentityHelper _identityHelper;

        public GraphqlConexionStringHelper(IIdentityHelper identityHelper)
        {
            _identityHelper = identityHelper;
        }
        public async Task<string> GraphqlConexionString(string query, object variable, bool requiredToken)
        {
            try
            {
                var GraphQLApiUrl = Environment.GetEnvironmentVariable("GRAPHQL_URI");

                var requestHeaders = new NameValueCollection();
                if (!requiredToken)
                {
                    var JWToken = _identityHelper.GetCurrentToken();
                    requestHeaders.Add("Authorization", $"Bearer {JWToken}");
                }

                IGraphQLClient graphQLClient = new GraphQLClient(new HttpClient(), GraphQLApiUrl, requestHeaders);
                var responseBodySTring = await graphQLClient.QueryAsync(query, variable);
                return responseBodySTring;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<string> GraphqlConexionString(string query, bool requiredToken)
        {
            try
            {
                var GraphQLApiUrl = Environment.GetEnvironmentVariable("GRAPHQL_URI");

                var requestHeaders = new NameValueCollection();
                if (!requiredToken)
                {
                    var JWToken = _identityHelper.GetCurrentToken();
                    requestHeaders.Add("Authorization", $"Bearer {JWToken}");
                }

                IGraphQLClient graphQLClient = new GraphQLClient(new HttpClient(), GraphQLApiUrl, requestHeaders);
                var responseBodySTring = await graphQLClient.QueryAsync(query);
                return responseBodySTring;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public class GraphqlConexionEntityHelper<IEntity>
        where IEntity : class
    {
        private readonly IIdentityHelper _identityHelper;

        public GraphqlConexionEntityHelper(IIdentityHelper identityHelper)
        {
            _identityHelper = identityHelper;
        }
        public async Task<IEntity> GraphqlConexionEntity(string query, object variable, bool requiredToken)
        {
            try
            {
                var GraphQLApiUrl = Environment.GetEnvironmentVariable("GRAPHQL_URI");

                // These are added on each request so you can safely use an HttpClient instance that is 
                // shared across your application
                var requestHeaders = new NameValueCollection();
                if (!requiredToken)
                {
                    var JWToken = _identityHelper.GetCurrentToken();
                    requestHeaders.Add("Authorization", $"Bearer {JWToken}");
                }

                IGraphQLClient graphQLClient = new GraphQLClient(new HttpClient(), GraphQLApiUrl, requestHeaders);
                IEntity repository = await graphQLClient.QueryAsync<IEntity>(query, variable);

                return repository;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<IEntity> GraphqlConexionEntity(string query, bool requiredToken)
        {
            try
            {
                var GraphQLApiUrl = Environment.GetEnvironmentVariable("GRAPHQL_URI");

                // These are added on each request so you can safely use an HttpClient instance that is 
                // shared across your application
                var requestHeaders = new NameValueCollection();
                if (!requiredToken)
                {
                    var JWToken = _identityHelper.GetCurrentToken();
                    requestHeaders.Add("Authorization", $"Bearer {JWToken}");
                }

                IGraphQLClient graphQLClient = new GraphQLClient(new HttpClient(), GraphQLApiUrl, requestHeaders);
                IEntity repository = await graphQLClient.QueryAsync<IEntity>(query);

                return repository;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
