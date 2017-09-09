using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Flags]
    public enum PresentationOptions : int
    {
        NewOnMarket = 0x00000001,
        ShowAddress = 0x00000010,
        ShowOnMap   = 0x00000020,        
        HasPhoto    = 0x00000100
    }
}
