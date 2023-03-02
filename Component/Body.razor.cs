using Microsoft.AspNetCore.Components;
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

        internal Appbar? Appbar { get; set; }

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
                .If("mdui-appbar-with-tab",()=> Appbar != null && Appbar.Fixed && Appbar.Tab != null)
                .If("mdui-appbar-with-tab-larger", () => Appbar != null && Appbar.Fixed && Appbar.Tab != null && Appbar.Tab.HasIcon)
                ;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //base.OnAfterRenderAsync(firstRender);
            if (firstRender) 
            {
                //先简单处理，直接重新渲染一次 后续考虑js处理性能较好
                if (Appbar != null && Appbar.Fixed) 
                {
                    await InvokeAsync(StateHasChanged);
                }
            }
        }
    }
}
