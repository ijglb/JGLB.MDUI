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
Blazor.registerCustomEventType('MduiPanelOpen', {
    browserEventName: 'open.mdui.panel',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiPanelOpened', {
    browserEventName: 'opened.mdui.panel',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiPanelClose', {
    browserEventName: 'close.mdui.panel',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiPanelClosed', {
    browserEventName: 'closed.mdui.panel',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiBottomNavChange', {
    browserEventName: 'change.mdui.bottomNav',
    createEventArgs: event => {
        return {
            index: event._detail.index
        };
    }
});
Blazor.registerCustomEventType('MduiDialogOpen', {
    browserEventName: 'open.mdui.dialog',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiDialogOpened', {
    browserEventName: 'opened.mdui.dialog',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiDialogClose', {
    browserEventName: 'close.mdui.dialog',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiDialogClosed', {
    browserEventName: 'closed.mdui.dialog',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiDialogCancel', {
    browserEventName: 'cancel.mdui.dialog',
    createEventArgs: event => {
        return {

        };
    }
});
Blazor.registerCustomEventType('MduiDialogConfirm', {
    browserEventName: 'confirm.mdui.dialog',
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
    Panel: function (selector, options) {
        if (options == null)
            return new mdui.Panel(selector);
        else
            return new mdui.Panel(selector, options);
    },
    Dialog: function (selector, options) {
            return new mdui.Dialog(selector, options);
    },
    Snackbar: function (options, dotNetHelper) {
        options.onClick = () => { dotNetHelper.invokeMethodAsync('OnClick'); };
        options.onButtonClick = () => { dotNetHelper.invokeMethodAsync('OnButtonClick'); };
        options.onOpen = () => { dotNetHelper.invokeMethodAsync('OnOpen'); };
        options.onOpened = () => { dotNetHelper.invokeMethodAsync('OnOpened'); };
        options.onClose = () => { dotNetHelper.invokeMethodAsync('OnClose'); };
        options.onClosed = () => { dotNetHelper.invokeMethodAsync('OnClosed'); };
        return mdui.snackbar(options);
    },
    CommonDialog: function (options, dotNetHelper) {
        options.onOpen = () => { dotNetHelper.invokeMethodAsync('OnOpen'); };
        options.onOpened = () => { dotNetHelper.invokeMethodAsync('OnOpened'); };
        options.onClose = () => { dotNetHelper.invokeMethodAsync('OnClose'); };
        options.onClosed = () => { dotNetHelper.invokeMethodAsync('OnClosed'); };
        for (var i = 0; i < options.buttons.length; i++) {
            var button = options.buttons[i];
            button.onClick = () => { dotNetHelper.invokeMethodAsync('OnClick', button.internalTag); }
        }
        return mdui.dialog(options);
    },
    PromptDialog: function (options, dotNetHelper) {
        options.onConfirm = (value, dialog) => { dotNetHelper.invokeMethodAsync('OnConfirm', value); };
        options.onCancel = (value, dialog) => { dotNetHelper.invokeMethodAsync('OnCancel', value); };
        return mdui.prompt(options.label, options.title, options.onConfirm, options.onCancel, options);
    },
    SetCheckboxIndeterminate: function (element,value)
    {
        element.indeterminate = value;
    },
    TrTriggerChangeEvent: function (element) {
        const $checkbox = mdui.$(element).find('.mdui-table-cell-checkbox').find('input[type="checkbox"]');
        if ($checkbox.length > 0) {
            $checkbox.trigger('change');
        }
    }
};