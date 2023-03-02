using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI.Events
{
    [EventHandler("onMduiTabChange", typeof(TabChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiTabShow", typeof(TabShowEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    public static class EventHandlers
    {
    }
}
