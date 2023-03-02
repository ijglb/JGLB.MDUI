using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义卡片的标题和副标题区域
    /// </summary>
    public class CardPrimary : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-card-primary";
    }
}
