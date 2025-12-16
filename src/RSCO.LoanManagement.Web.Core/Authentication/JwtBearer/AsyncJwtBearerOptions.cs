using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RSCO.LoanManagement.Web.Authentication.JwtBearer
{
    public class AsyncJwtBearerOptions : JwtBearerOptions
    {
        public readonly List<IAsyncSecurityTokenValidator> AsyncSecurityTokenValidators;
        
        private readonly LoanManagementAsyncJwtSecurityTokenHandler _defaultAsyncHandler = new LoanManagementAsyncJwtSecurityTokenHandler();

        public AsyncJwtBearerOptions()
        {
            AsyncSecurityTokenValidators = new List<IAsyncSecurityTokenValidator>() {_defaultAsyncHandler};
        }
    }

}
