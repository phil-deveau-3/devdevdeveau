using System;

namespace TimeBox.ViewModels
{
    public class AddOneMinuteCommand : AddTimeCommand
    {
        public AddOneMinuteCommand() : base(TimeSpan.FromMinutes(1))
        {
            
        }
    }
}