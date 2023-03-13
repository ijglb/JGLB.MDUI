using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义瓦片中的操作栏
    /// </summary>
    public class TileActions : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-grid-tile-actions";
        /// <summary>
        /// 使操作栏位于瓦片顶部
        /// </summary>
        [Parameter]
        public bool Top { get; set; }
        /// <summary>
        /// 使操作栏拥有透明背景
        /// </summary>
        [Parameter]
        public bool Transparent { get; set; }
        /// <summary>
        /// 使操作栏拥有渐变背景
        /// </summary>
        [Parameter]
        public bool Gradient { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-grid-tile-actions-top", () => Top)
                .If("mdui-grid-tile-actions-transparent", () => Transparent)
                .If("mdui-grid-tile-actions-transparent", () => Gradient)
                ;
        }
    }
}
