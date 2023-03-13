using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    public partial class Progress : MDUIComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        /// <summary>
        /// 进度
        /// </summary>
        [Parameter]
        public decimal? Process { get; set; } = null;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Add("mdui-progress");
        }
    }
}
