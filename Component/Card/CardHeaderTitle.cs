using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 卡片头部的标题
    /// </summary>
    public class CardHeaderTitle : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-card-header-title";
    }
}
