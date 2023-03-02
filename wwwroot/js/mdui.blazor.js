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

window.mduiblazor =
{
    Tab: function (selector, options) {
        if (options == null)
            return new mdui.Tab(selector);
        else
            return new mdui.Tab(selector, options);
    },
};