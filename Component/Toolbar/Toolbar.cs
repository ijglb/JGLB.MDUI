using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 工具栏
    /// </summary>
    public class Toolbar : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-toolbar";

        [CascadingParameter]
        private Appbar? Appbar { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Appbar != null) Appbar.Toolbar = this;
        }
    }
}
