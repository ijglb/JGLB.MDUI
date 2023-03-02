using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 布局容器 默认92% - 96% 的屏幕宽度，且最大宽度 1280px
    /// </summary>
    public class Container : AbstractSimpleComponent
    {
        /// <summary>
        /// 100% 宽度的布局容器
        /// </summary>
        [Parameter]
        public bool Fluid { get; set; }
        protected override string _Tag => "div";
        protected override string _CSS => "";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("mdui-container-fluid", () => Fluid)
                .If("mdui-container", () => !Fluid)
                ;
        }
    }
}
