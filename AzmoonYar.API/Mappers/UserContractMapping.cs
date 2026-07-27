using AzmoonYar.API.Contracts.User;
using AzmoonYar.Application.DTOs;
using AzmoonYar.Application.DTOs.User;

namespace AzmoonYar.API.Mappers;

public static class UserContractMapping
{
    public static UserResponse ToResponse(this UserDto dto)
    {
        return new UserResponse(dto.Id
            , dto.FirstName
            , dto.LastName
            , dto.UserName
            , dto.PhoneNumber
            , dto.CreatedAt);
    }
    public static CreateUserDto ToDto(this CreateUserRequest dto)
    {
        return new CreateUserDto(dto.FirstName
            , dto.LastName
            , dto.UserName
            , dto.Password
            , dto.PhoneNumber);
    }
}