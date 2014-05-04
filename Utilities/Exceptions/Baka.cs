using System;

namespace Utilities.Exceptions
{
    //Baka ("馬鹿") is fool in Japanese
    [Serializable]
    public class Baka : Exception
    {
        public Baka(string message) : base(message)
        {
            
        }
    }
}
