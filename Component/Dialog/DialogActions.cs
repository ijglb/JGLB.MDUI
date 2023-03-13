using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义对话框的操作栏
    /// </summary>
    public class DialogActions : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-dialog-actions";
        /// <summary>
        /// 使对话框操作栏的按钮竖直排列
        /// </summary>
        [Parameter]
        public bool Stacked { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-dialog-actions-stacked", () => Stacked)
                ;
        }
    }
}
