using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Jls.Tools.Testing.MoapiClient;
using Jls.Tools.Testing.MoapiClient.Configuration;
using Jls.Tools.Testing.MoapiClient.Models;
using RestSharp;
using System.Diagnostics;

namespace Jls.Tools.Testing.MoapiUI
{
    public class ApiMapSource : IMapSource
    {
        private readonly RestClient _client;
        private readonly IMoapiSettings _settings;
        private SessionContext _sessionCtx;
        
        public ApiMapSource(Uri sourceUrl, IMoapiSettings settings = null)
        {
            _client = new RestClient(sourceUrl);
            _settings = settings;            
        }

        public void Initialize()
        {
            // Establis the security context
            EstablishSessionContext();

            Console.WriteLine(_sessionCtx.SessionKey);
        }

        public SearchResponse Search(ISearchRequest searchRequest)
        {
            var request = new RestRequest("gis/search");
            request.Method = Method.GET;

            // Add params
            
            request.AddParameter("area", searchRequest.Area.ToString(true), ParameterType.QueryString);
            request.AddParameter("price", searchRequest.Price);
            request.AddParameter("status", string.Join(",", searchRequest.StatusTypes));
            request.AddParameter("prop_types", string.Join(",", searchRequest.PropertyTypes));                        
            request.AddParameter("cdom", searchRequest.CDOM);
            request.AddParameter("year", searchRequest.Year);
            request.AddParameter("beds", searchRequest.Beds);
            request.AddParameter("baths", searchRequest.Baths);
            request.AddParameter("garages", searchRequest.Garages);
            request.AddParameter("acres", searchRequest.Acres);
            request.AddParameter("sqft", searchRequest.SqFt);
            request.AddParameter("max_results", searchRequest.MaxResults);

            
            request.AddParameter("options", searchRequest.Options ?? string.Join(",", searchRequest.SearchOptionTypes));


            var response = PeformSessionRequest<SearchResponse>(request);

            return response.Data;
        }

        /// <summary>
        /// Will make a REST request and if needed, auto establish a new session.
        /// </summary>
        /// <returns></returns>
        private IRestResponse<T> PeformSessionRequest<T>(IRestRequest request) where T : new()
        {
            try
            {
                if (_sessionCtx == null || _sessionCtx.SessionKey == Guid.Empty)
                {
                    // Establish a new session
                    if (!EstablishSessionContext())
                    {
                        // Throw an error
                        throw new MoapiClientException("Failed to establish the session context.");
                    }
                }

                // Let's add our security header to the request
                request.AddHeader("X-SESSION", _sessionCtx.SessionKey.ToString());

                // DEBUG: API Call request URI
                //Debug.WriteLine(_client.BuildUri(request).ToString());
                //END DEBUG CODE

                var response = _client.Execute<T>(request);
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    // Invalid or expired session context.  Let's re-establish a new session
                    // context and try it one more time.
                    if (!EstablishSessionContext())
                    {
                        throw new MoapiClientException("Failed to re-establish the session context.");
                    }

                    // Try it again
                    request.AddHeader("X-SESSION", _sessionCtx.SessionKey.ToString());
                    response = _client.Execute<T>(request);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

            return null;
        }

        private bool EstablishSessionContext()
        {
            var request = new RestRequest("client/getsessioncontext");
            request.Method = Method.GET;
            request.AddParameter("appkey", _settings.AppKey);
            request.AddParameter("apikey", _settings.ApiKey);
            request.AddParameter("rev", "6");
            request.AddParameter("osver", "7.0.1");

            var response = _client.Execute<SessionContext>(request);
            _sessionCtx = response.Data;

            return (_sessionCtx.SessionKey != Guid.Empty);            
        }
        
    }
}
