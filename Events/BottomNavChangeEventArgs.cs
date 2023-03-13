using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 切换导航项时会触发该事件
    /// </summary>
    public class BottomNavChangeEventArgs : MDUIEventArgs<BottomNav>
    {
        /// <summary>
        /// 激活的导航项的索引号
        /// </summary>
        public int Index { get; set; }
    }
}
