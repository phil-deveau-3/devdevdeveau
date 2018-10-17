using System;

namespace TimeBox.ViewModels
{
    public class AddTenMinutesCommand : AddTimeCommand
    {
        public AddTenMinutesCommand() : base(TimeSpan.FromMinutes(10))
        {
            
        }
    }
}