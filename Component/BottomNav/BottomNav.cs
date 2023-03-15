using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义底部导航栏组件
    /// </summary>
    public class BottomNav : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-bottom-nav";
        /// <summary>
        /// 使导航栏只在激活状态显示文本
        /// </summary>
        [Parameter]
        public bool TextAuto { get; set; }
        /// <summary>
        /// 使导航栏固定到页面底部
        /// </summary>
        [Parameter]
        public bool Fixed { get; set; }
        /// <summary>
        /// 在页面向下滚动时隐藏底部导航栏，向上滚动时显示底部导航栏
        /// </summary>
        [Parameter]
        public bool ScrollHide {get;set;}
        /// <summary>
        /// 切换导航项时会触发该事件
        /// </summary>
        [Parameter]
        public EventCallback<BottomNavChangeEventArgs> OnChange { get; set; }

        [CascadingParameter]
        private Body? Body { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-bottom-nav-text-auto", () => TextAuto)
                .If("mdui-bottom-nav-scroll-hide", () => ScrollHide)
                ;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, _Tag);
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "id", Id);
            builder.AddAttribute(3, "class", ClassMapper.Class);
            builder.AddAttribute(4, "style", Style);
            builder.AddAttribute(5, "onMduiBottomNavChange", EventCallback.Factory.Create<BottomNavChangeEventArgs>(this, onMduiBottomNavChange));
            builder.AddElementReferenceCapture(6, x => Ref = x);
            builder.AddContent(7, ChildContent);
            builder.CloseElement();
        }

        private async Task onMduiBottomNavChange(BottomNavChangeEventArgs args)
        {
            if (OnChange.HasDelegate)
            {
                await OnChange.InvokeAsync(new BottomNavChangeEventArgs { Instance = this, Index = args.Index });
            }
        }
    }
}
