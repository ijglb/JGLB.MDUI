using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 浮动操作按钮
    /// </summary>
    public class Fab : AbstractSimpleComponent
    {
        /// <summary>
        /// 带弹出菜单的浮动操作按钮打开菜单后切换到该图标。 css
        /// </summary>
        public const string OpenedCSS = "mdui-fab-opened";
        protected override string _Tag => "button";

        protected override string _CSS => "mdui-fab mdui-ripple";

        /// <summary>
        /// 迷你型浮动操作按钮
        /// </summary>
        [Parameter]
        public bool Mini { get; set; }
        /// <summary>
        /// 固定到右下角
        /// </summary>
        [Parameter]
        public bool Fixed { get; set; }

        /// <summary>
        /// 隐藏按钮
        /// </summary>
        public bool IsHide { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-fab-mini", () => Mini)
                .If("mdui-fab-fixed", () => Fixed)
                .If("mdui-fab-hide", () => IsHide)
                ;
        }

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
    }
}
