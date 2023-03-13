using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 常规对话框
    /// </summary>
    public class CommonDialog : IDisposable
    {
        private readonly IJSRuntime _Js;
        private DotNetObjectReference<CommonDialog>? _ObjRef;
        private CommonDialogOptions? _Options;
        private IJSObjectReference? _JsInstance;
        private bool _IsShow;
        public bool IsShow => _IsShow;

        public CommonDialog(IJSRuntime js)
        {
            _Js = js;
        }

        public async Task<CommonDialog> Open(CommonDialogOptions options)
        {
            if (!_IsShow)
            {
                _Options = options;
                _ObjRef = DotNetObjectReference.Create(this);
                _JsInstance = await _Js.InvokeAsync<IJSObjectReference>("mduiblazor.CommonDialog", _Options, _ObjRef);
                _IsShow = true;
            }
            return this;
        }

        /// <summary>
        /// 关闭
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
        public void OnOpen() => _Options?.onOpen?.Invoke(this);
        [JSInvokable]
        public void OnOpened() => _Options?.onOpened?.Invoke(this);
        [JSInvokable]
        public void OnClose() => _Options?.onClose?.Invoke(this);
        [JSInvokable]
        public void OnClosed() 
        {
            if (_Options != null)
            {
                _Options.onClosed?.Invoke(this);
                if (_Options.destroyOnClosed)
                {
                    Dispose();
                }
            }
        }
        [JSInvokable]
        public void OnClick(string internalTag) => _Options?.buttons.Find(x => x.internalTag == internalTag)?.onClick?.Invoke(internalTag);

        public void Dispose()
        {
            _IsShow = false;
            _Options = null;
            _ObjRef?.Dispose();
            _JsInstance?.DisposeAsync();
        }
    }

    public class CommonDialogOptions
    {
        /// <summary>
        /// 对话框的标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 对话框的内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 按钮集合，每个按钮都是一个带按钮参数的对象
        /// </summary>
        public List<DialogButton> buttons { get; set; } = new List<DialogButton>();
        /// <summary>
        /// 按钮是否垂直排列
        /// </summary>
        public bool stackedButtons { get; set; }
        /// <summary>
        /// 添加到 .mdui-dialog 上的 CSS 类
        /// </summary>
        public string cssClass { get; set; }
        /// <summary>
        /// 是否监听 hashchange 事件，为 true 时可以通过 Android 的返回键或浏览器后退按钮关闭对话框
        /// </summary>
        public bool history { get; set; } = true;
        /// <summary>
        /// 打开对话框后是否显示遮罩层
        /// </summary>
        public bool overlay { get; set; } = true;
        /// <summary>
        /// 是否模态化对话框。为 false 时点击对话框外面的区域时关闭对话框，否则不关闭
        /// </summary>
        public bool modal { get; set; } = false;
        /// <summary>
        /// 是否模态化对话框。为 false 时点击对话框外面的区域时关闭对话框，否则不关闭
        /// </summary>
        public bool closeOnEsc { get; set; } = true;
        /// <summary>
        /// 关闭对话框后是否自动销毁对话框
        /// </summary>
        public bool destroyOnClosed { get; set; } = true;

        /// <summary>
        /// 打开动画开始时的回调
        /// </summary>
        public Action<CommonDialog>? onOpen { get; set; }
        /// <summary>
        /// 打开动画结束时的回调
        /// </summary>
        public Action<CommonDialog>? onOpened { get; set; }
        /// <summary>
        /// 关闭动画开始时的回调
        /// </summary>
        public Action<CommonDialog>? onClose { get; set; }
        /// <summary>
        /// 关闭动画结束时的回调
        /// </summary>
        public Action<CommonDialog>? onClosed { get; set; }

    }

    public class DialogButton
    {
        /// <summary>
        /// 内部标识
        /// </summary>
        public string internalTag { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 按钮文本
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 按钮文本是否加粗
        /// </summary>
        public bool bold { get; set; }
        /// <summary>
        /// 点击按钮后是否关闭对话框
        /// </summary>
        public bool close { get; set; } = true;

        /// <summary>
        /// 点击按钮的回调函数 string:internalTag
        /// </summary>
        public Action<string>? onClick { get; set; }
    }
}
