using Microsoft.AspNetCore.Components;
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
    /// 抽屉式导航 默认抽屉栏在左侧
    /// </summary>
    public partial class Drawer : MDUIComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        /// <summary>
        /// 使抽屉栏在右侧
        /// </summary>
        [Parameter]
        public bool Right { get; set; }
        /// <summary>
        /// 使抽屉栏占据 100% 高度。
        /// </summary>
        [Parameter]
        public bool FullHeight { get; set; }
        /// <summary>
        /// 抽屉栏默认状态（在手机和平板上，抽屉栏默认隐藏。在桌面设备上，抽屉栏默认显示。）
        /// opened：默认显示 closed：默认隐藏
        /// </summary>
        [Parameter]
        public DrawerState DefaultState { get; set; } = DrawerState.unknown;
        [Parameter]
        public DrawerOptions? Options { get; set; }
        /// <summary>
        /// 状态变更时触发 打开/关闭
        /// </summary>
        [Parameter]
        public EventCallback<DrawerStateChangeEventArgs> OnStateChange { get; set; }

        private IJSObjectReference? _JsInstance;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper.Add("mdui-drawer")
                .If("mdui-drawer-right", () => Right)
                .If("mdui-drawer-full-height", () => FullHeight)
                .If("mdui-drawer-open", () => DefaultState == DrawerState.opened || DefaultState == DrawerState.opening)
                .If("mdui-drawer-close", () => DefaultState == DrawerState.closed || DefaultState == DrawerState.closing)
                ;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (Options != null && Options.overlay)
            {
                DefaultState = DrawerState.closed;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Drawer", Ref, Options);
            }
        }

        #region 事件
        private async Task onMduiDrawerOpen(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new DrawerStateChangeEventArgs { Instance = this, State = DrawerState.opening });
            }
        }
        private async Task onMduiDrawerOpened(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new DrawerStateChangeEventArgs { Instance = this, State = DrawerState.opened });
            }
        }
        private async Task onMduiDrawerClose(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new DrawerStateChangeEventArgs { Instance = this, State = DrawerState.closing });
            }
        }
        private async Task onMduiDrawerClosed(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new DrawerStateChangeEventArgs { Instance = this, State = DrawerState.closed });
            }
        }
        #endregion

        /// <summary>
        /// 显示抽屉栏
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
        /// 隐藏抽屉栏
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
        /// 切换抽屉栏的显示状态
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
        /// 返回当前抽屉栏的状态
        /// </summary>
        /// <returns></returns>
        public async Task<DrawerState> GetState()
        {
            var state = DrawerState.unknown;
            if (_JsInstance != null)
            {
                string stateStr = await _JsInstance.InvokeAsync<string>("getState");
                Enum.TryParse(stateStr, out state);
            }
            return state;
        }

    }

    public class DrawerOptions 
    {
        public string target { get; set; }
        /// <summary>
        /// 打开抽屉栏时是否显示遮罩层。该参数只对中等屏幕及以上的设备有效，在超小屏和小屏设备上始终会显示遮罩层。
        /// </summary>
        public bool overlay { get; set; }
        /// <summary>
        /// 是否启用滑动手势。
        /// </summary>
        public bool swipe { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(target) ? $"{{overlay:'{overlay}',swipe:{swipe}}}" : $"{{target:'{target}',overlay:'{overlay}',swipe:{swipe}}}";
        }
    }
}
