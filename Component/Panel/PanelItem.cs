using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 可扩展面板的面板项
    /// </summary>
    public class PanelItem : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-panel-item";
        /// <summary>
        /// 使面板项默认打开
        /// </summary>
        [Parameter]
        public bool Open { get; set; }

        [Parameter]
        public EventCallback<StateChangeEventArgs<PanelItem>> OnStateChange { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-panel-item-open", () => Open)
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
                builder.AddAttribute(6, "onMduiPanelOpen", EventCallback.Factory.Create(this, onMduiPanelOpen));
                builder.AddAttribute(7, "onMduiPanelOpened", EventCallback.Factory.Create(this, onMduiPanelOpened));
                builder.AddAttribute(8, "onMduiPanelClose", EventCallback.Factory.Create(this, onMduiPanelClose));
                builder.AddAttribute(9, "onMduiPanelClosed", EventCallback.Factory.Create(this, onMduiPanelClosed));
                builder.AddContent(10, ChildContent);
                builder.CloseElement();
            }
        }

        #region 内部事件回调
        private async Task onMduiPanelOpen(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<PanelItem> { Instance = this, State = OpenCloseState.opening });
            }
        }
        private async Task onMduiPanelOpened(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<PanelItem> { Instance = this, State = OpenCloseState.opened });
            }
        }
        private async Task onMduiPanelClose(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<PanelItem> { Instance = this, State = OpenCloseState.closing });
            }
        }
        private async Task onMduiPanelClosed(EventArgs args)
        {
            if (OnStateChange.HasDelegate)
            {
                await OnStateChange.InvokeAsync(new StateChangeEventArgs<PanelItem> { Instance = this, State = OpenCloseState.closed });
            }
        }
        #endregion

    }
}
