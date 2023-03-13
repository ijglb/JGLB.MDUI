using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义菜单项
    /// </summary>
    public class MenuItem : AbstractSimpleComponent
    {
        protected override string _Tag => "li";

        protected override string _CSS => "mdui-menu-item";
    }
}
