using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 应用栏
    /// </summary>
    public partial class Appbar : MDUIComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [CascadingParameter]
        private Body? Body { get; set; }
        /// <summary>
        /// 使应用栏固定到页面顶部。
        /// </summary>
        [Parameter]
        public bool Fixed { get; set; }
        /// <summary>
        /// 透明背景
        /// </summary>
        [Parameter]
        public bool Transparent { get; set; }
        /// <summary>
        /// 在页面向下滚动时隐藏应用栏，向上滚动时显示应用栏。
        /// </summary>
        [Parameter]
        public bool ScrollHide { get; set; }
        /// <summary>
        /// 在应用栏中同时含有工具栏和 Tab 选项卡时，页面向下滚动时隐藏工具栏，向上滚动时显示工具栏。
        /// </summary>
        [Parameter]
        public bool ScrollToolbarHide { get; set; }

        internal Tab? Tab { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if(Body != null) Body.Appbar = this;

            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper.Add("mdui-appbar")
                .If("mdui-appbar-fixed", ()=>Fixed)
                .If("mdui-appbar-scroll-hide", () => ScrollHide)
                .If("mdui-appbar-scroll-toolbar-hide", () => ScrollToolbarHide)
                .If("mdui-shadow-0",() => Transparent)
                ;
        }
    }
}
