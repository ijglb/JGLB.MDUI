using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JGLB.MDUI
{
    public abstract class AbstractSimpleComponent : MDUIComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)] 
        public Dictionary<string, object>? AdditionalAttributes { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        /// <summary>
        /// html标签
        /// </summary>
        protected abstract string _Tag { get; }
        /// <summary>
        /// CSS类
        /// </summary>
        protected abstract string _CSS { get; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper.Add(_CSS);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (builder != null)
            {
                builder.OpenElement(0, _Tag);
                builder.AddMultipleAttributes(1, AdditionalAttributes);
                builder.AddAttribute(2, "id", Id);
                builder.AddAttribute(3, "class", ClassMapper.Class);
                builder.AddAttribute(4, "style", Style);
                builder.AddElementReferenceCapture(5, x => Ref = x);
                builder.AddContent(6, ChildContent);
                builder.CloseElement();
            }
        }
    }
}
