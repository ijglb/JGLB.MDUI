using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI.Events
{
    [EventHandler("onMduiTabChange", typeof(TabChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiTabShow", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDrawerOpen", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDrawerOpened", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDrawerClose", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDrawerClosed", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiCollapseOpen", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiCollapseOpened", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiCollapseClose", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiCollapseClosed", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiFabOpen", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiFabOpened", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiFabClose", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiFabClosed", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiPanelOpen", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiPanelOpened", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiPanelClose", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiPanelClosed", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiBottomNavChange", typeof(BottomNavChangeEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDialogOpen", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDialogOpened", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDialogClose", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDialogClosed", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDialogCancel", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    [EventHandler("onMduiDialogConfirm", typeof(EventArgs), enableStopPropagation: true, enablePreventDefault: true)]
    public static class EventHandlers
    {
    }
}
