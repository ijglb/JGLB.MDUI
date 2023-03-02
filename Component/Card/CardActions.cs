using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义卡片的操作栏
    /// </summary>
    public class CardActions : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-card-actions";
        /// <summary>
        /// 使操作栏竖直排列
        /// </summary>
        [Parameter]
        public bool Stacked { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-card-actions-stacked", () => Stacked)
                ;
        }
    }
}
