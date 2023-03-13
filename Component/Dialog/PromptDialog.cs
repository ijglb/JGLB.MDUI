using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 提示用户输入的对话框
    /// </summary>
    public class PromptDialog : IDisposable
    {
        private readonly IJSRuntime _Js;
        private DotNetObjectReference<PromptDialog>? _ObjRef;
        private PromptDialogOptions? _Options;
        private IJSObjectReference? _JsInstance;
        private bool _IsShow;
        public bool IsShow => _IsShow;

        public PromptDialog(IJSRuntime js)
        {
            _Js = js;
        }

        public async Task<PromptDialog> Open(PromptDialogOptions options)
        {
            if (!_IsShow)
            {
                _Options = options;
                _ObjRef = DotNetObjectReference.Create(this);
                _JsInstance = await _Js.InvokeAsync<IJSObjectReference>("mduiblazor.PromptDialog", _Options, _ObjRef);
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
        public void OnConfirm(string value) => _Options?.onConfirm?.Invoke(value);
        [JSInvokable]
        public void OnCancel(string value) => _Options?.onCancel?.Invoke(value);

        public void Dispose()
        {
            _IsShow = false;
            _Options = null;
            _ObjRef?.Dispose();
            _JsInstance?.DisposeAsync();
        }
    }

    /// <summary>
    /// 提示用户输入的对话框 参数
    /// </summary>
    public class PromptDialogOptions
    {
        /// <summary>
        /// 文本框浮动标签的文本
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 确认按钮的文本
        /// </summary>
        public string confirmText { get; set; } = "ok";
        /// <summary>
        /// 取消按钮的文本
        /// </summary>
        public string cancelText { get; set; } = "cancel";
        /// <summary>
        /// 是否监听 hashchange 事件，为 true 时可以通过 Android 的返回键或浏览器后退按钮关闭对话框
        /// </summary>
        public bool history { get; set; } = true;
        /// <summary>
        /// 是否模态化对话框。为 false 时点击对话框外面的区域时关闭对话框，否则不关闭
        /// </summary>
        public bool modal { get; set; }
        /// <summary>
        /// 	按下 Esc 键时是否关闭对话框
        /// </summary>
        public bool closeOnEsc { get; set; } = true;
        /// <summary>
        /// 是否在按下取消按钮时是否关闭对话框
        /// </summary>
        public bool closeOnCancel { get; set; } = true;
        /// <summary>
        /// 是否在按下取消按钮时是否关闭对话框
        /// </summary>
        public bool closeOnConfirm { get; set; } = true;
        /// <summary>
        /// 按下 Enter 键时触发 onConfirm 回调函数。
        /// </summary>
        public bool confirmOnEnter { get; set; }
        /// <summary>
        /// 文本框的类型 text: 单行文本框 textarea: 多行文本框
        /// </summary>
        public string type { get; set; } = "text";
        /// <summary>
        /// 最大输入字符数量
        /// </summary>
        public int maxlength { get; set; }
        /// <summary>
        /// 文本框的默认值
        /// </summary>
        public string defaultValue { get; set; } = "";
        /// <summary>
        /// 点击确认按钮的回调 参数为文本框的值
        /// </summary>
        public Action<string>? onConfirm { get; set; }
        /// <summary>
        /// 点击取消按钮的回调 参数为文本框的值
        /// </summary>
        public Action<string>? onCancel { get; set; }
    }
}
