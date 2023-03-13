using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 弹出菜单 按钮始终固定在窗口右下角。在鼠标悬浮或点击时向上弹出快速拨号菜单。
    /// </summary>
    public class FabWrapper : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-fab-wrapper";
        /// <summary>
        /// 触发方式。hover：鼠标悬浮触发。click：点击触发。
        /// </summary>
        [Parameter]
        public string Trigger { get; set; } = "hover";
        /// <summary>
        /// 快速拨号菜单 状态变更
        /// </summary>
        [Parameter]
        public EventCallback<StateChangeEventArgs<FabWrapper>> OnStateChange { get; set; }

        /// <summary>
        /// 隐藏按钮
        /// </summary>
        public bool IsHide { get; set; }

        private IJSObjectReference? _JsInstance;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-fab-hide", () => IsHide)
                ;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Fab", Ref, new { trigger = Trigger });
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
                builder.AddElementReferenceCapture(5, x => Ref = x);
                builder.AddAttribute(6, "onMduiFabOpen", EventCallback.Factory.Create(this, onMduiFabOpen));
                builder.AddAttribute(7, "onMduiFabOpened", EventCallback.Factory.Create(this, onMduiFabOpened));
                builder.AddAttribute(8, "onMduiFabClose", EventCallback.Factory.Create(this, onMduiFabClose));
                builder.AddAttribute(9, "onMduiFabClosed", EventCallback.Factory.Create(this, onMduiFabClosed));
                builder.AddContent(10, ChildContent);
                builder.CloseElement();
            }
        }

        #region 公开方法
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public async Task Show()
        {
            if (IsHide)
            {
                IsHide = false;
                await InvokeAsync(StateHasChanged);
            }
        }
        /// <summary>
        /// 隐藏
        /// </summary>
        /// <returns></returns>
        public async Task Hide()
        {
            if (!IsHide)
            {
                IsHide = true;
                await InvokeAsync(StateHasChanged);
            }
        }
        /// <summary>
        /// 打开快速拨号菜单
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
        /// 关闭快速拨号菜单
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
        /// 切换快速拨号菜单的打开状态
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
        /// 返回当前快速拨号菜单的打开状态
        /// </summary>
        /// <returns></returns>
        public async Task<OpenCloseState> GetState()
        {
            OpenCloseState state = OpenCloseState.unknown;
            if (_JsInstance != null)
            {
                string stateStr = await _JsInstance.InvokeAsync<string>("getState");
                Enum.TryParse(stateStr, out state);
            }
            return state;
        }
        #endregion

        #region 内部事件回调
        private async Task onMduiFabOpen(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<FabWrapper> { Instance = this, State = OpenCloseState.opening });
            }
        }
        private async Task onMduiFabOpened(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<FabWrapper> { Instance = this, State = OpenCloseState.opened });
            }
        }
        private async Task onMduiFabClose(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<FabWrapper> { Instance = this, State = OpenCloseState.closing });
            }
        }
        private async Task onMduiFabClosed(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<FabWrapper> { Instance = this, State = OpenCloseState.closed });
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
