using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 抽屉栏状态变更 打开/关闭
    /// </summary>
    public class DrawerStateChangeEventArgs : MDUIEventArgs<Drawer>
    {
        public DrawerState State { get; set; }
    }
}
