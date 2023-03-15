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
    /// 菜单 为了使菜单能正确地定位，菜单和触发菜单的元素必须位于同一父元素下的同一级
    /// </summary>
    public class Menu : AbstractSimpleComponent
    {
        protected override string _Tag => "ul";

        protected override string _CSS => "mdui-menu";
        /// <summary>
        /// 级联菜单
        /// </summary>
        [Parameter]
        public bool Cascade { get; set; }
        /// <summary>
        /// 触发菜单的元素的ID
        /// </summary>
        [Parameter]
        public string OpenElementId { get; set; }
        /// <summary>
        /// 菜单相对于触发它的元素的位置
        /// top：菜单在触发它的元素的上方
        /// bottom：菜单在触发它的元素的下方
        /// center：菜单在窗口中垂直居中
        /// auto：自动判断位置。优先级为：bottom > top > center
        /// </summary>
        [Parameter]
        public string Position { get; set; } = "auto";
        /// <summary>
        /// 菜单与触发它的元素的对其方式
        /// left：菜单与触发它的元素左对齐
        /// right：菜单与触发它的元素右对齐
        /// center：菜单在窗口中水平居中
        /// auto：自动判断位置：优先级为：left > right > center
        /// </summary>
        [Parameter]
        public string Align { get; set; } = "auto";
        /// <summary>
        /// 菜单与窗口边框至少保持多少间距，单位为 px
        /// </summary>
        [Parameter]
        public int Gutter { get; set; } = 16;
        /// <summary>
        /// 菜单的定位方式
        /// true：菜单使用 fixed 定位。在页面滚动时，菜单将保持在窗口固定位置，不随滚动条滚动
        /// false：菜单使用 absolute 定位。在页面滚动时，菜单将随着页面一起滚动
        /// </summary>
        [Parameter]
        public bool Fixed { get; set; }
        /// <summary>
        /// 菜单是否覆盖在触发它的元素的上面
        /// true：使菜单覆盖在触发它的元素的上面
        /// false：使菜单不覆盖触发它的元素
        /// auto：简单菜单覆盖触发它的元素。级联菜单不覆盖触发它的元素
        /// </summary>
        [Parameter]
        public object Covered { get; set; } = "auto";
        /// <summary>
        /// 子菜单的触发方式
        /// click：点击时触发子菜单
        /// hover：鼠标悬浮时触发子菜单
        /// </summary>
        [Parameter]
        public string SubMenuTrigger { get; set; } = "hover";
        /// <summary>
        /// 子菜单的触发延迟时间（单位：毫秒），只有在 SubMenuTrigger=hover 时，这个参数才有效
        /// </summary>
        [Parameter]
        public int SubMenuDelay { get; set; } = 200;
        /// <summary>
        /// 菜单开始和结束打开/关闭动画时 出发
        /// </summary>
        [Parameter]
        public EventCallback<StateChangeEventArgs<Menu>> OnStateChange { get; set; }
        /// <summary>
        /// 指示该菜单为嵌套子菜单
        /// </summary>
        [Parameter]
        public bool Child { get; set; }

        private IJSObjectReference? _JsInstance;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-menu-cascade", () => Cascade)
                ;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && !Child)
            {
                try
                {
                    _JsInstance = await Js.InvokeAsync<IJSObjectReference>("mduiblazor.Menu", $"#{OpenElementId}", Ref, new
                    {
                        position = Position,
                        align = Align,
                        gutter = Gutter,
                        _fixed = Fixed,
                        covered = Covered,
                        subMenuTrigger = SubMenuTrigger,
                        subMenuDelay = SubMenuDelay
                    });
                }
                catch (Exception)
                {
                }
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
                builder.AddAttribute(5, "onMduiMenuOpen", EventCallback.Factory.Create(this, onMduiMenuOpen));
                builder.AddAttribute(6, "onMduiMenuOpened", EventCallback.Factory.Create(this, onMduiMenuOpened));
                builder.AddAttribute(7, "onMduiMenuClose", EventCallback.Factory.Create(this, onMduiMenuClose));
                builder.AddAttribute(8, "onMduiMenuClosed", EventCallback.Factory.Create(this, onMduiMenuClosed));
                builder.AddElementReferenceCapture(9, x => Ref = x);
                builder.AddContent(10, ChildContent);
                builder.CloseElement();
            }
        }

        #region 公开方法
        /// <summary>
        /// 打开菜单
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
        /// 关闭菜单
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
        /// 切换菜单的打开状态
        /// </summary>
        /// <returns></returns>
        public async Task Toggle()
        {
            if (_JsInstance != null)
            {
                await _JsInstance.InvokeVoidAsync("toggle");
            }
        }
        #endregion

        #region 内部事件回调
        private async Task onMduiMenuOpen(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<Menu> { Instance = this, State = OpenCloseState.opening });
            }
        }
        private async Task onMduiMenuOpened(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<Menu> { Instance = this, State = OpenCloseState.opened });
            }
        }
        private async Task onMduiMenuClose(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<Menu> { Instance = this, State = OpenCloseState.closing });
            }
        }
        private async Task onMduiMenuClosed(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<Menu> { Instance = this, State = OpenCloseState.closed });
            }
        }
        #endregion
    }
}
