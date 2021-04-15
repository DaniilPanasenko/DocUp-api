using System;
namespace DocUp.Api.Auth
{
    public interface IApplicationUser
    {
        int Id { get; }

        string Role { get; }
    }
}
