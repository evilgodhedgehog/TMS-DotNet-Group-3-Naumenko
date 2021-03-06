using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMS_DotNet_Group_3_Naumenko.Logic.Interfaces;
using Flurl;
using Flurl.Http;
using TMS_DotNet_Group_3_Naumenko.Data.Models;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Models
{
    public class DomainAPI : IApi
    {
        public string Web { get; set; }
        public List<string> PathSegments { get; set; }
        public List<string> QueryParams { get; set; }

        public DomainAPI(string web, List<string> pathSegments, List<string> queryParams)
        {
            Web = web;
            PathSegments = pathSegments;
            QueryParams = queryParams;
        }

        public async Task<DomainCommonModel> GetData()
        {
            var result = await Web
               .AppendPathSegments(PathSegments)
               .SetQueryParams(QueryParams)
               .GetJsonAsync<DomainCommonModel>();

            return result;
        }

        void IApi.ProcessResult<T>(T result)
        {
            throw new NotImplementedException();
        }

        public ApiModel Initialize()
        {
            throw new NotImplementedException();
        }
    }
}