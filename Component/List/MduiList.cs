using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 列表
    /// </summary>
    public class MduiList : AbstractSimpleComponent
    {
        protected override string _Tag => Tag;

        protected override string _CSS => "mdui-list";
        /// <summary>
        /// html标签
        /// </summary>
        [Parameter]
        public string Tag { get; set; } = "div";
        /// <summary>
        /// 密集型列表
        /// </summary>
        [Parameter]
        public bool Dense { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .If("mdui-list-dense", () => Dense)
                ;
        }
    }
}
