using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 列表条目中的图标
    /// </summary>
    public class ListItemIcon : Icon
    {
        /// <summary>
        /// 用图标代替头像
        /// </summary>
        [Parameter]
        public bool AvatarIcon { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-list-item-icon", () => !AvatarIcon)
                .If("mdui-list-item-avatar", () => AvatarIcon)
                ;
        }
    }
}
