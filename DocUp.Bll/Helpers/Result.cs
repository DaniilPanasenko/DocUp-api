using System;
namespace DocUp.Bll.Helpers
{
    public readonly struct Result<T>
    {
        public T Value { get; }

        public ResultCode Code { get; }

        public Result(T value)
        {
            Code = ResultCode.Success;
            Value = value;
        }

        public Result(ResultCode code)
        {
            Code = code;
            Value = default;
        }
    }
}
