﻿using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AQA_DIPLOMA.Configuration;
using NLog;
using RestSharp;
using RestSharp.Authenticators;

namespace AQA_DIPLOMA.Clients;

public class RestClientExtended
{
    private readonly RestClient _client;
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    public static RestResponse LastResponse { get; private set; } = null!;

    public RestClientExtended()
    {
        var options = new RestClientOptions(Configurator.AppSettings.ApiUrl ?? throw new InvalidOperationException());
        _client = new RestClient(options);
        _client.Authenticator = new HttpBasicAuthenticator(Configurator.Admin.Email, Configurator.Admin.Token);
    }

    public async Task<T> ExecuteAsync<T>(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync<T>(request);
        LastResponse = response;
        LogResponse(response);
        
        return response.Data ?? throw  new SerializationException(
            "Response deserialization error!", response.ErrorException);
    }

    public async Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        LogRequest(request);
        var response = await _client.ExecuteAsync(request);
        LogResponse(response);
        
        return response;
    }

    private void LogRequest(RestRequest request)
    {
        _logger.Debug($"{request.Method} request to : {request.Resource}");
        var body = request.Parameters.FirstOrDefault(parameter => parameter.Type == ParameterType.RequestBody)?.Value;
        if (body != null)
        {
            _logger.Debug($"body : {body}");
        }
    }

    private void LogResponse(RestResponse response)
    {
        if (response.ErrorException != null)
        {
            _logger.Error(
                $"Error retrieving response. Check inner details for more info. \n{response.ErrorException.Message}");
        }

        _logger.Debug($"Request finished with status code : {response.StatusCode}");
        
        if (!string.IsNullOrEmpty(response.Content))
        {
            _logger.Debug(response.Content);
        }
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}