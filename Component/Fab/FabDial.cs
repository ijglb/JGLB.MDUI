using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 带弹出菜单的浮动操作按钮的菜单外层元素
    /// </summary>
    public class FabDial : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-fab-dial";
    }
}
