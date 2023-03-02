using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 卡片
    /// </summary>
    public partial class Card : AbstractSimpleComponent
    {
        protected override string _Tag => "div";

        protected override string _CSS => "mdui-card";
    }
}
