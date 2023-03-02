using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 覆盖在媒体元素上的内容
    /// </summary>
    public class CardMediaCovered : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-card-media-covered";

        /// <summary>
        /// 使覆盖层位于媒体元素顶部
        /// </summary>
        [Parameter]
        public bool CoveredTop { get; set; }

        /// <summary>
        /// 使覆盖层拥有透明背景
        /// </summary>
        [Parameter]
        public bool CoveredTransparent { get; set; }

        /// <summary>
        /// covered-gradient
        /// </summary>
        [Parameter]
        public bool CoveredGradient { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("mdui-card-media-covered-top", () => CoveredTop)
                .If("mdui-card-media-covered-transparent", () => CoveredTransparent)
                .If("mdui-card-media-covered-gradient", () => CoveredGradient)
                ;
        }
    }
}
