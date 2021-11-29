using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMS_DotNet_Group_3_Naumenko.Logic.Models;

namespace TMS_DotNet_Group_3_Naumenko.Logic.Services
{
    public static class ApiService<T>
    {
        public static Url PrepareRequestAsync(ApiModel model)
        {
            try
            {
                return model.Web
                    .AppendPathSegments(model.PathSegments.ToArray())
                    .SetQueryParams(model.QueryParams.ToArray());
            }
            catch (FlurlHttpException)
            {
                throw new Exception("Incorrect API request! Please, check input date.");
            }
        }

        public static async Task<T> GetResultAsync(Url url)
        {
            try
            {
                return await url.GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                throw new Exception("Incorrect API request! Please, check input date.");
            }
        }

        public static async Task<List<T>> GetResultsAsync(Url url)
        {
            try
            {
                return await url.GetJsonAsync<List<T>>();
            }
            catch (FlurlHttpException)
            {
                throw new Exception("Incorrect API request! Please, check input date.");
            }
        }
    }
}
