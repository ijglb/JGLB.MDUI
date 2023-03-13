using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 含子菜单的菜单项的向右箭头
    /// </summary>
    public class MenuItemMore : AbstractSimpleComponent
    {
        protected override string _Tag => "span";

        protected override string _CSS => "mdui-menu-item-more";
    }
}
