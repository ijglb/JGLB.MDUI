using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 对话框组件
    /// </summary>
    public class Dialog : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-dialog";
        /// <summary>
        /// 打开对话框时是否显示遮罩
        /// </summary>
        [Parameter]
        public bool Overlay { get; set; } = true;
        /// <summary>
        /// 打开对话框时是否添加 url hash，若为 true，则打开对话框后可用过浏览器的后退按钮或 Android 的返回键关闭对话框
        /// </summary>
        [Parameter]
        public bool History { get; set; } = true;
        /// <summary>
        /// 是否模态化对话框。为 false 时点击对话框外面的区域时关闭对话框，否则不关闭
        /// </summary>
        [Parameter]
        public bool Modal { get; set; }
        /// <summary>
        /// 按下 Esc 键时是否关闭对话框
        /// </summary>
        [Parameter]
        public bool CloseOnEsc { get; set; } = true;
        /// <summary>
        /// 按下取消按钮时是否关闭对话框
        /// </summary>
        [Parameter]
        public bool CloseOnCancel { get; set; } = true;
        /// <summary>
        /// 按下确认按钮时是否关闭对话框
        /// </summary>
        [Parameter]
        public bool CloseOnConfirm { get; set; } = true;
        /// <summary>
        /// 关闭对话框后是否自动销毁对话框
        /// </summary>
        [Parameter]
        public bool DestroyOnClosed { get; set; } = false;
        /// <summary>
        /// 对话框状态变更事件
        /// </summary>
        [Parameter]
        public EventCallback<StateChangeEventArgs<Dialog>> OnStateChange { get; set; }
        /// <summary>
        /// 按下取消按钮时，事件将被触发
        /// </summary>
        [Parameter]
        public EventCallback<MDUIEventArgs<Dialog>> OnCancel { get; set; }
        /// <summary>
        /// 按下确认按钮时，事件将被触发
        /// </summary>
        [Parameter]
        public EventCallback<MDUIEventArgs<Dialog>> OnConfirm { get; set; }

        private IJSObjectReference? _JsInstance;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Dialog", Ref, new
                {
                    overlay = Overlay,
                    history = History,
                    modal = Modal,
                    closeOnEsc = CloseOnEsc,
                    closeOnCancel = CloseOnCancel,
                    closeOnConfirm = CloseOnConfirm,
                    destroyOnClosed = DestroyOnClosed
                });
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (builder != null)
            {
                builder.OpenElement(0, _Tag);
                builder.AddMultipleAttributes(1, AdditionalAttributes);
                builder.AddAttribute(2, "id", Id);
                builder.AddAttribute(3, "class", ClassMapper.Class);
                builder.AddAttribute(4, "style", Style);
                builder.AddAttribute(5, "onMduiDialogOpen", EventCallback.Factory.Create(this, onMduiDialogOpen));
                builder.AddAttribute(6, "onMduiDialogOpened", EventCallback.Factory.Create(this, onMduiDialogOpened));
                builder.AddAttribute(7, "onMduiDialogClose", EventCallback.Factory.Create(this, onMduiDialogClose));
                builder.AddAttribute(8, "onMduiDialogClosed", EventCallback.Factory.Create(this, onMduiDialogClosed));
                builder.AddAttribute(9, "onMduiDialogCancel", EventCallback.Factory.Create(this, onMduiDialogCancel));
                builder.AddAttribute(10, "onMduiDialogConfirm", EventCallback.Factory.Create(this, onMduiDialogConfirm));
                builder.AddElementReferenceCapture(11, x => Ref = x);
                builder.AddContent(12, ChildContent);
                builder.CloseElement();
            }
        }

        #region 公开方法
        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <returns></returns>
        public async Task Open()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("open");
            }
        }
        /// <summary>
        /// 关闭对话框
        /// </summary>
        /// <returns></returns>
        public async Task Close()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("close");
            }
        }
        /// <summary>
        /// 切换对话框的打开状态
        /// </summary>
        /// <returns></returns>
        public async Task Toggle()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("toggle");
            }
        }
        /// <summary>
        /// 获取对话框状态
        /// </summary>
        /// <returns></returns>
        public async Task<OpenCloseState> GetState()
        {
            var state = OpenCloseState.unknown;
            if (_JsInstance != null)
            {
                string str = await _JsInstance.InvokeAsync<string>("getState");
                Enum.TryParse(str, out state);
            }
            return state;
        }
        /// <summary>
        /// 销毁对话框
        /// </summary>
        /// <returns></returns>
        public async Task Destroy()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("destroy");
            }
            Dispose();
        }
        /// <summary>
        /// 重新调整对话框位置和滚动条高度。在打开对话框后，如果修改了对话框内容，需要调用该方法
        /// </summary>
        /// <returns></returns>
        public async Task HandleUpdate()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("handleUpdate");
            }
        }
        #endregion

        #region 内部事件回调
        private async Task onMduiDialogOpen(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<Dialog> { Instance = this, State = OpenCloseState.opening });
            }
        }
        private async Task onMduiDialogOpened(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<Dialog> { Instance = this, State = OpenCloseState.opened });
            }
        }
        private async Task onMduiDialogClose(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<Dialog> { Instance = this, State = OpenCloseState.closing });
            }
        }
        private async Task onMduiDialogClosed(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<Dialog> { Instance = this, State = OpenCloseState.closed });
            }
            if (DestroyOnClosed) 
            {
                Dispose();
            }
        }
        private async Task onMduiDialogCancel(EventArgs args)
        {
            if (OnCancel.HasDelegate)
            {
                await OnCancel.InvokeAsync(new MDUIEventArgs<Dialog> { Instance = this});
            }
        }
        private async Task onMduiDialogConfirm(EventArgs args)
        {
            if (OnConfirm.HasDelegate)
            {
                await OnConfirm.InvokeAsync(new MDUIEventArgs<Dialog> { Instance = this});
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            _JsInstance?.DisposeAsync();
            base.Dispose(disposing);
        }
    }
}
