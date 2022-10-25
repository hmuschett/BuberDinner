using buberDinner.Application.Authentication.Commands.Register;
using buberDinner.Application.Authentication.Common;
using buberDinner.Application.Authentication.Queries.Login;
using buberDinner.Contracts.Authentication;
using Mapster;

namespace buberDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}