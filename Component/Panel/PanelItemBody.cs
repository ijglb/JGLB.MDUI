using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI.Component.Panel
{
    /// <summary>
    /// 面板项内容
    /// </summary>
    public class PanelItemBody : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-panel-item-body";
    }
}
