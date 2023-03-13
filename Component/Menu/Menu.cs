using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu : AbstractSimpleComponent
    {
        protected override string _Tag => "ul";

        protected override string _CSS => "mdui-menu";
        /// <summary>
        /// 级联菜单
        /// </summary>
        [Parameter]
        public bool Cascade { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-menu-cascade", () => Cascade)
                ;
        }
    }
}
