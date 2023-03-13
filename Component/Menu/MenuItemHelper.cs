using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义菜单的帮助文本
    /// </summary>
    public class MenuItemHelper : AbstractSimpleComponent
    {
        protected override string _Tag => "span";

        protected override string _CSS => "mdui-menu-item-helper";
    }
}
