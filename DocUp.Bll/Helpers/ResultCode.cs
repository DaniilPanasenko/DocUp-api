using System;
namespace DocUp.Bll.Helpers
{
    public enum ResultCode
    {
        Success = 200,
        NotFound = 404,
        BadRequest = 400,
        Forbidden = 403,

        InvalidLogin = 11,
        InvalidPassword = 12,

        LoginAlreadyExist = 21,
        EmailAlreadyExist = 22,
        UserBlocked = 23,

        DeviceSeriaAlreadyExst = 31,
        DeviceAlreadyHaveUser = 32,

        UserAlreadyHasIlness = 41

    }
}
