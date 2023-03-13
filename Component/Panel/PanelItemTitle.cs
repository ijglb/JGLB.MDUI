using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI.Component.Panel
{
    /// <summary>
    /// 面板项头部的标题
    /// </summary>
    public class PanelItemTitle : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-panel-item-title";
    }
}
