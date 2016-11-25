using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightVision
{
    internal static class FilteringExtensions
    {
        internal static int GetValidColorComponent(this double component)
        {
            if (component > 255)
            {
                return 255;
            }
            return component < 0 ? 0 : Convert.ToInt32(Math.Round(component, MidpointRounding.AwayFromZero));
        }
    }
}
