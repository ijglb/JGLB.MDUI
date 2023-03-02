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

        protected override string _Tag => "i";

        protected override string _CSS => "mdui-icon";

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("material-icons", () => string.IsNullOrWhiteSpace(ExIcon))
                .If(ExIcon, () => !string.IsNullOrWhiteSpace(ExIcon))
                .If($"mdui-icon-{LocationInButton}", () => !string.IsNullOrWhiteSpace(LocationInButton))
                ;
        }
    }
}
