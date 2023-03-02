using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 按钮
    /// </summary>
    public class Button : AbstractSimpleComponent
    {
        /// <summary>
        /// html标签 a/button/input 默认button
        /// </summary>
        [Parameter]
        public string Tag { get; set; } = "button";
        /// <summary>
        /// 浮动按钮
        /// </summary>
        [Parameter]
        public bool Raised { get; set; }
        /// <summary>
        /// 图标按钮
        /// </summary>
        [Parameter]
        public bool Icon { get; set; }
        /// <summary>
        /// 密集型按钮
        /// </summary>
        [Parameter]
        public bool Dense { get; set; }
        /// <summary>
        /// 块级元素
        /// </summary>
        [Parameter]
        public bool Block { get; set; }
        /// <summary>
        /// 按钮组中的按钮处于选中状态
        /// </summary>
        [Parameter]
        public bool Active { get; set; }

        protected override string _Tag => Tag;

        protected override string _CSS => "mdui-btn";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("mdui-btn-raised", () => Raised)
                .If("mdui-btn-icon", () => Icon)
                .If("mdui-btn-block", () => Block)
                .If("mdui-btn-active", () => Active)
                ;
        }
    }
}
