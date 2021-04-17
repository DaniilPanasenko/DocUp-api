using System;
namespace DocUp.Bll
{
    public class ReadingsTimeCheck
    {
        public DateTimeOffset LastChecking { get; private set; }

        public ReadingsTimeCheck()
        {
            LastChecking = DateTimeOffset.MinValue;
        }

        public void DoCheck()
        {
            LastChecking = DateTimeOffset.Now;
        }
    }
}
