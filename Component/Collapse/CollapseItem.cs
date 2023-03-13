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
    /// 折叠内容块
    /// </summary>
    public class CollapseItem : AbstractSimpleComponent
    {
        /// <summary>
        /// 含类 .mdui-collapse-item-arrow 的元素会在内容块展开时翻转 180 度
        /// </summary>
        public const string Arrow = "mdui-collapse-item-arrow";
        protected override string _Tag => Tag;

        protected override string _CSS => "mdui-collapse-item";
        /// <summary>
        /// html标签
        /// </summary>
        [Parameter]
        public string Tag { get; set; } = "div";
        /// <summary>
        /// 使内容块处于默认展开状态
        /// </summary>
        [Parameter]
        public bool Open { get; set; }
        /// <summary>
        /// 内容块状态变更时触发 打开/关闭
        /// </summary>
        [Parameter]
        public EventCallback<StateChangeEventArgs<CollapseItem>> OnStateChange { get; set; }

        //[CascadingParameter]
        //private Collapse? Parent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //Parent?.AddItem(this);
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("mdui-collapse-item-open", () => Open)
                ;
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
                builder.AddAttribute(6, "onMduiCollapseOpen", EventCallback.Factory.Create(this, onMduiCollapseOpen));
                builder.AddAttribute(7, "onMduiCollapseOpened", EventCallback.Factory.Create(this, onMduiCollapseOpened));
                builder.AddAttribute(8, "onMduiCollapseClose", EventCallback.Factory.Create(this, onMduiCollapseClose));
                builder.AddAttribute(9, "onMduiCollapseClosed", EventCallback.Factory.Create(this, onMduiCollapseClosed));
                builder.AddContent(10, ChildContent);
                builder.CloseElement();
            }
        }

        #region 事件
        private async Task onMduiCollapseOpen(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<CollapseItem> { Instance = this, State = OpenCloseState.opening });
            }
        }
        private async Task onMduiCollapseOpened(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<CollapseItem> { Instance = this, State = OpenCloseState.opened });
            }
        }
        private async Task onMduiCollapseClose(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<CollapseItem> { Instance = this, State = OpenCloseState.closing });
            }
        }
        private async Task onMduiCollapseClosed(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<CollapseItem> { Instance = this, State = OpenCloseState.closed });
            }
        }
        #endregion
    }
}
