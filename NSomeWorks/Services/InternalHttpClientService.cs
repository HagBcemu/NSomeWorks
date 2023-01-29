using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NSomeWorks.Dtos;
using NSomeWorks.Helpers;
using NSomeWorks.Services.Abstractions;
using Newtonsoft.Json;

namespace NSomeWorks.Services;
public class InternalHttpClientClientService : IInternalHttpClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public InternalHttpClientClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task SendAsync(string url, HttpMethod method, object content = null)
    {
        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;
        if (content != null)
        {
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, Constants.JsonContentType);
        }

        HttpResponseMessage result;

        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            result = await httpClient.SendAsync(httpMessage);
        }
        catch (Exception ex)
        {
            throw new BusinessException(ex.Message);
        }

        throw new BusinessException(null!, result.StatusCode.ToString());
    }

    public async Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object content = null)
    {
        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;
        if (content != null)
        {
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, Constants.JsonContentType);
        }

        HttpResponseMessage result;

        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            result = await httpClient.SendAsync(httpMessage);
        }
        catch (Exception ex)
        {
            throw new BusinessException(ex.Message);
        }

        var resultContent = await result.Content.ReadAsStringAsync();

        if (result.IsSuccessStatusCode)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);

            if (response is ErrorTextDto error && !string.IsNullOrEmpty(error.ErrorBody))
            {
                throw new BusinessException(error.ErrorBody, ErrorCodes.Validation);
            }

            return response!;
        }

        throw new BusinessException(resultContent, result.StatusCode.ToString());
    }
}
