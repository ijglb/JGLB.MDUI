using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 列表条目
    /// </summary>
    public class ListItem : AbstractSimpleComponent
    {
        protected override string _Tag => Tag;

        protected override string _CSS => "mdui-list-item mdui-ripple";

        /// <summary>
        /// html标签
        /// </summary>
        [Parameter]
        public string Tag { get; set; } = "div";
        /// <summary>
        /// 设置列表条目为激活状态
        /// </summary>
        [Parameter]
        public bool Active { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("mdui-list-item-active", () => Active)
                ;
        }
    }
}
