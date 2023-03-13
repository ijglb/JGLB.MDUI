using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JGLB.MDUI
{
    /// <summary>
    /// Tab组件
    /// </summary>
    public partial class Tab : MDUIComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        private Appbar? Appbar { get; set; }
        /// <summary>
        /// 使选项卡可以横向滚动，常用于移动端选项较多的场景。
        /// </summary>
        [Parameter]
        public bool Scrollable { get; set; }
        /// <summary>
        /// 使选项卡在平板/PC 上居中对齐。
        /// </summary>
        [Parameter]
        public bool Centered { get; set; }
        /// <summary>
        /// 使选项卡始终占据 100% 的宽度，且每个选项卡宽度相等。
        /// </summary>
        [Parameter]
        public bool FullWidth { get; set; }
        /// <summary>
        /// 切换选项卡的触发方式。 click: 点击切换（默认） hover: 鼠标悬浮切换 
        /// </summary>
        [Parameter]
        public string Trigger { get; set; } = "click";
        /// <summary>
        /// 是否启用循环切换，若为 true，则最后一个选项激活时调用 next 方法将回到第一个选项，第一个选项激活时调用 prev 方法将回到最后一个选项。
        /// </summary>
        [Parameter]
        public bool Loop { get; set; }
        /// <summary>
        /// 切换选项时，事件将被触发。
        /// </summary>
        [Parameter]
        public EventCallback<TabChangeEventArgs> OnChange { get; set; }
        /// <summary>
        /// 含有有图标的tabItem
        /// </summary>
        [Parameter]
        public bool HasIcon { get; set; }

        private IJSObjectReference? _JsInstance;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Appbar != null) Appbar.Tab = this;

            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper.Add("mdui-tab")
                .If("mdui-tab-scrollable", () => Scrollable)
                .If("mdui-tab-centered", () => Centered)
                .If("mdui-tab-full-width", () => FullWidth)
                ;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                /*try
                {
                    _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Tab", Ref, Options);
                }
                catch (JSException jsex)
                {
                    Logger.LogError(jsex, "mduiblazor.Tab");
                }*/
                //需要修改mdui.js Tab init时不调用setActive
                _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Tab", Ref, new { trigger = Trigger, loop = Loop });

            }
        }

        internal void SetHasIcon(bool value)
        {
            HasIcon = value;
        }

        #region 公开方法
        /// <summary>
        /// 切换到上一个选项
        /// </summary>
        /// <returns></returns>
        public async Task Prev()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("prev");
            }
        }
        /// <summary>
        /// 切换到下一个选项
        /// </summary>
        public async Task Next()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("next");
            }
        }
        /// <summary>
        /// 显示指定的选项。
        /// </summary>
        /// <param name="index">索引</param>
        public async Task Show(int index)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("show", index);
            }
        }
        /// <summary>
        /// 显示指定的选项。
        /// </summary>
        /// <param name="id">ID</param>
        public async Task Show(string id)
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("show", $"#{id}");
            }
        }

        /// <summary>
        /// 当父元素的宽度发生变化时，需要调用该方法重新设置指示器位置。当在选项卡中动态添加了新的选项时，也需要调用该方法使新的选项生效。
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


        private async Task OnMduiTabChange(TabChangeEventArgs args)
        {
            if (OnChange.HasDelegate) 
            {
                args.Instance = this;
                await OnChange.InvokeAsync(args);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _JsInstance?.DisposeAsync();
            base.Dispose(disposing);
        }

    }
}
