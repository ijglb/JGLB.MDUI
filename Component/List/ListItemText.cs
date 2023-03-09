using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 列表条目的内容中的副文本
    /// </summary>
    internal class ListItemText : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-list-item-text";

        /// <summary>
        /// 文本行数限制 1-3
        /// </summary>
        [Parameter]
        public int Line { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-list-item-one-line", () => Line == 1)
                .If("mdui-list-item-two-line", () => Line == 2)
                .If("mdui-list-item-three-line", () => Line == 3)
                ;
        }
    }
}
