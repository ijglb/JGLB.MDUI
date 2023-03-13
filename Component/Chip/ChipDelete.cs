using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 定义纸片的删除按钮
    /// </summary>
    public class ChipDelete : AbstractSimpleComponent
    {
        protected override string _Tag => "span";

        protected override string _CSS => "mdui-chip-delete";
    }
}
