using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 切换选项时，事件将被触发。
    /// </summary>
    public class TabChangeEventArgs : EventArgs
    {
        public Tab Instance { get; set; }
        /// <summary>
        /// 激活的选项的索引号
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 激活的选项的选项卡内容的id
        /// </summary>
        public string Id { get; set; }
    }
}
