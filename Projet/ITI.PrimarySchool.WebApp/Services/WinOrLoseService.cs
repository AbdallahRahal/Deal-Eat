using System;

namespace ITI.PrimarySchool.WebApp.Services
{
    public class WinOrLoseService : IWinOrLoseService
    {
        public bool WinOrLose()
        {
            return Environment.TickCount % 2 == 0;
        }
    }
}