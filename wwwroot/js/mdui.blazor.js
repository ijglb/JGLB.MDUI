Blazor.registerCustomEventType('MduiTabChange', {
    browserEventName: 'change.mdui.tab',
    createEventArgs: event => {
        return {
            index: event._detail.index,
            id: event._detail.id
        };
    }
});
Blazor.registerCustomEventType('MduiTabShow', {
    browserEventName: 'show.mdui.tab',
    createEventArgs: event => {
        return {
            
        };
    }
});
Blazor.registerCustomEventType('MduiDrawerOpen', {
    browserEventName: 'open.mdui.drawer',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiDrawerOpened', {
    browserEventName: 'opened.mdui.drawer',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiDrawerClose', {
    browserEventName: 'close.mdui.drawer',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiDrawerClosed', {
    browserEventName: 'closed.mdui.drawer',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiCollapseOpen', {
    browserEventName: 'open.mdui.collapse',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiCollapseOpened', {
    browserEventName: 'opened.mdui.collapse',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiCollapseClose', {
    browserEventName: 'close.mdui.collapse',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiCollapseClosed', {
    browserEventName: 'closed.mdui.collapse',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiFabOpen', {
    browserEventName: 'open.mdui.fab',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiFabOpened', {
    browserEventName: 'opened.mdui.fab',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiFabClose', {
    browserEventName: 'close.mdui.fab',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiFabClosed', {
    browserEventName: 'closed.mdui.fab',
    createEventArgs: event => {
        return {

        };
    }
});

window.mduiblazor =
{
    Tab: function (selector, options) {
        if (options == null)
            return new mdui.Tab(selector);
        else
            return new mdui.Tab(selector, options);
    },
    Drawer: function (selector, options) {
        if (options == null)
            return new mdui.Drawer(selector);
        else {
            delete options.target;
            return new mdui.Drawer(selector, options);
        }
    },
    Collapse: function (selector, options) {
        if (options == null)
            return new mdui.Collapse(selector);
        else
            return new mdui.Collapse(selector, options);
    },
    Fab: function (selector, options) {
        if (options == null)
            return new mdui.Fab(selector);
        else
            return new mdui.Fab(selector, options);
    },
    Select: function (selector, options) {
        if (options == null)
            return new mdui.Select(selector);
        else
            return new mdui.Select(selector, options);
    },
    SetCheckboxIndeterminate: function (element,value)
    {
        element.indeterminate = value;
    }
};