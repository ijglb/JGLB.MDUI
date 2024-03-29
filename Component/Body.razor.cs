﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// MDUI Body 
    /// </summary>
    public partial class Body : MDUIComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        /// <summary>
        /// 主题色
        /// </summary>
        [Parameter]
        public Theme Theme { get; set; } = Theme.Light;
        /// <summary>
        /// 主题主色
        /// </summary>
        [Parameter]
        public Color PrimaryColor { get; set; } = Color.None;
        /// <summary>
        /// 主题强调色
        /// </summary>
        [Parameter]
        public Color AccentColor { get; set; } = Color.None;
        /// <summary>
        /// 左侧有默认打开的抽屉栏
        /// </summary>
        [Parameter]
        public bool DrawerLeft { get; set; }
        /// <summary>
        /// 右侧有默认打开的抽屉栏
        /// </summary>
        [Parameter]
        public bool DrawerRight { get; set; }

        internal Appbar? Appbar { get; set; }
        internal BottomNav? BottomNav { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }
        protected void SetClassMap()
        {
            ClassMapper
                .GetIf(() => Theme.GetDescription(), () => Theme != Theme.Light)
                .GetIf(() => $"mdui-theme-primary-{PrimaryColor.GetDescription()}", () => PrimaryColor != Color.None)
                .GetIf(() => $"mdui-theme-accent-{AccentColor.GetDescription()}", () => AccentColor != Color.None)
                .If("mdui-appbar-with-toolbar", () => Appbar != null && Appbar.Fixed && Appbar.Toolbar != null)
                .If("mdui-appbar-with-tab", () => Appbar != null && Appbar.Fixed && Appbar.Tab != null)
                .If("mdui-appbar-with-tab-larger", () => Appbar != null && Appbar.Fixed && Appbar.Tab != null && Appbar.Tab.HasIcon)
                .If("mdui-drawer-body-left", () => DrawerLeft)
                .If("mdui-drawer-body-right", () => DrawerRight)
                .If("mdui-bottom-nav-fixed", () => BottomNav != null && BottomNav.Fixed)
                ;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                //先简单处理，直接重新渲染一次 后续考虑js处理性能较好
                if ((Appbar != null && Appbar.Fixed)
                    || (BottomNav != null && BottomNav.Fixed))
                {
                    await InvokeAsync(StateHasChanged);
                }
            }
        }
    }
}
