using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 卡片头部的头像。
    /// </summary>
    public class CardHeaderAvatar : AbstractSimpleComponent
    {
        protected override string _Tag => "img";

        protected override string _CSS => "mdui-card-header-avatar";

        /// <summary>
        /// 头像路径
        /// </summary>
        [Parameter]
        public string Src { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (!string.IsNullOrWhiteSpace(Src))
            {
                if (AdditionalAttributes == null)
                {
                    AdditionalAttributes = new Dictionary<string, object>();
                }
                AdditionalAttributes.TryAdd("src", Src);
            }
        }
    }
}
