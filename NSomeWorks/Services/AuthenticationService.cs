﻿using System.Net.Http;
using System.Threading.Tasks;
using NSomeWorks.Config;
using NSomeWorks.Dtos;
using NSomeWorks.Dtos.Responses;
using NSomeWorks.Model;
using NSomeWorks.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace NSomeWorks.Services;

public class AuthenticationService : BaseService, IAuthenticationService
{
    private readonly IInternalHttpClientService _internalHttpClientService;
    private readonly ApiOption _apiOption;

    public AuthenticationService(
        IInternalHttpClientService internalHttpClientService,
        IOptions<ApiOption> options)
    {
        _apiOption = options.Value;
        _internalHttpClientService = internalHttpClientService;
    }

    public async Task<LoginResult> Login(string login, string password)
    {
       return await ExecuteSafeAsync(async () =>
        {
            var request = new AuthDto { Email = login, Password = password };

            var response = await _internalHttpClientService.SendAsync<LoginResponse>($"{_apiOption.Host}/login", HttpMethod.Post, request);
            return new LoginResult
            {
                Token = response!.Token!
            };
        });
    }

    public async Task<RegisterResult> Register(string login, string password)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var request = new AuthDto { Email = login, Password = password };
            var response = await _internalHttpClientService.SendAsync<RegisterResponse>($"{_apiOption.Host}/register", HttpMethod.Post, request);
            return new RegisterResult
            {
                Token = response!.Token!
            };
        });
    }
}