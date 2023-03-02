using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 切换到指定选项时，事件将被触发。
    /// </summary>
    public class TabShowEventArgs : EventArgs
    {
        public TabItem Instance { get; set; }
    }
}
