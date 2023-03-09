using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 折叠内容块标题
    /// </summary>
    public class CollapseItemHeader : AbstractSimpleComponent
    {
        protected override string _Tag => Tag;

        protected override string _CSS => "mdui-collapse-item-header";
        /// <summary>
        /// html标签
        /// </summary>
        [Parameter]
        public string Tag { get; set; } = "div";
    }
}
