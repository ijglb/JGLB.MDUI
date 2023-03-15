using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 图标
    /// </summary>
    public class Icon : AbstractSimpleComponent
    {
        /// <summary>
        /// 第三方图标库css类
        /// </summary>
        [Parameter]
        public string ExIcon { get; set; }
        /// <summary>
        /// 图标位于按钮 left / right
        /// </summary>
        [Parameter]
        public string LocationInButton { get; set; }

        /// <summary>
        /// 面板项的展开收起图标
        /// </summary>
        [Parameter]
        public bool PanelItemArrow { get; set; }
        /// <summary>
        /// 定义菜单图标
        /// </summary>
        [Parameter]
        public bool MenuItemIcon { get; set; }
        /// <summary>
        /// 折叠内容块插件展开收起图标
        /// </summary>
        [Parameter]
        public bool CollapseItemArrow { get; set; }

        [CascadingParameter]
        private Tab? Tab { get; set; }

        protected override string _Tag => "i";

        protected override string _CSS => "mdui-icon";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Tab?.SetHasIcon(true);
            SetClassMap();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if ((PanelItemArrow || CollapseItemArrow) && ChildContent == null)
            {
                ChildContent = (builder) =>
                {
                    builder.AddContent(0, "keyboard_arrow_down");
                };
            }
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("material-icons", () => string.IsNullOrWhiteSpace(ExIcon))
                .GetIf(() => ExIcon, () => !string.IsNullOrWhiteSpace(ExIcon))
                .GetIf(() => $"mdui-icon-{LocationInButton}", () => !string.IsNullOrWhiteSpace(LocationInButton))
                .If("mdui-panel-item-arrow", () => PanelItemArrow)
                .If("mdui-menu-item-icon", () => MenuItemIcon)
                .If("mdui-collapse-item-arrow", () => CollapseItemArrow)
                ;
        }
    }
}
