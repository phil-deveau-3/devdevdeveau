using System;

namespace TimeBox.ViewModels
{
    public class AddFiveMinutesCommand : AddTimeCommand
    {
        public AddFiveMinutesCommand() : base(TimeSpan.FromMinutes(5))
        {
        }
    }
}