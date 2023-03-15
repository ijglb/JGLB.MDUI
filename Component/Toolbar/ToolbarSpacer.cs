using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 该元素两边的元素会被推到两侧
    /// </summary>
    public class ToolbarSpacer : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-toolbar-spacer";
    }
}
