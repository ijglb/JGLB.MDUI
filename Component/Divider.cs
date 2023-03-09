using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 分隔线
    /// </summary>
    public class Divider : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "";

        /// <summary>
        /// 内凹分隔线
        /// </summary>
        [Parameter]
        public bool Inset { get; set; }
        /// <summary>
        /// 颜色 light/dark
        /// 默认自动 在默认主题下为深色，在深色主题下为浅色。
        /// </summary>
        [Parameter]
        public string Color { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Get(() => $"mdui-divider{(Inset ? "-inset" : "")}{(string.IsNullOrEmpty(Color) ? "" : "-" + Color)}")
                ;
        }
    }
}
