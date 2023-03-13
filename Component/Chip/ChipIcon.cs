using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义纸片的头像或图标
    /// </summary>
    public class ChipIcon : AbstractSimpleComponent
    {
        protected override string _Tag => Tag;

        protected override string _CSS => "mdui-chip-icon";

        /// <summary>
        /// html标签 默认span
        /// </summary>
        [Parameter]
        public string Tag { get; set; } = "span";
    }
}
