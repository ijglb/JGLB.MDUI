using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// Snackbar 弹出框
    /// </summary>
    public class Snackbar : IDisposable
    {
        private readonly IJSRuntime _Js;
        private DotNetObjectReference<Snackbar>? _ObjRef;
        private SnackbarOptions? _Options;
        private IJSObjectReference? _JsInstance;
        private bool _IsShow;
        public bool IsShow => _IsShow;

        public Snackbar(IJSRuntime js) 
        {
            _Js = js;
        }

        /// <summary>
        /// 显示弹出框
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<Snackbar> Show(SnackbarOptions options)
        {
            if (!_IsShow)
            {
                _Options = options;
                _ObjRef = DotNetObjectReference.Create(this);
                _JsInstance = await _Js.InvokeAsync<IJSObjectReference>("mduiblazor.Snackbar", _Options, _ObjRef);
                _IsShow = true;
            }
            return this;
        }

        /// <summary>
        /// 关闭 Snackbar，关闭后 Snackbar 会被销毁
        /// </summary>
        /// <returns></returns>
        public async Task Close() 
        {
            if (_JsInstance != null) 
            {
                await _JsInstance.InvokeVoidAsync("close");
            }
        }

        [JSInvokable]
        public void OnClick() => _Options?.onClick?.Invoke();
        [JSInvokable]
        public void OnButtonClick()=> _Options?.onButtonClick?.Invoke();
        [JSInvokable]
        public void OnOpen() => _Options?.onOpen?.Invoke();
        [JSInvokable]
        public void OnOpened() => _Options?.onOpened?.Invoke();
        [JSInvokable]
        public void OnClose() => _Options?.onClose?.Invoke();
        [JSInvokable]
        public void OnClosed() 
        {
            _Options?.onClosed?.Invoke();
            Dispose();
        }

        public void Dispose()
        {
            _IsShow = false;
            _Options = null;
            _ObjRef?.Dispose();
            _JsInstance?.DisposeAsync();
        }
    }
}
