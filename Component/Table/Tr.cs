using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// mdui表格行 用于跟踪复选框，如果不使用复选框可直接使用html tr标签
    /// </summary>
    public class Tr : AbstractSimpleComponent
    {
        protected override string _Tag => "tr";

        protected override string _CSS => "";

        [CascadingParameter]
        private Table? Table { get; set; }

        private bool _Checked;
        /// <summary>
        /// 行是否选中
        /// </summary>
        [Parameter]
        public bool Checked
        {
            get => _Checked;
            set 
            {
                if (_Checked != value) 
                {
                    _Checked = value;
                    try
                    {
                        Js.InvokeVoidAsync("mduiblazor.TrTriggerChangeEvent", Ref);
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
        }

        [Parameter]
        public EventCallback<MDUIEventArgs<Tr>> OnCheckedChange { get; set; }
        //internal event EventHandler OnTrCheckedChange;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //Table?.AddTr(this);
            ClassMapper
                .If("mdui-table-row-selected", () => Checked)
                ;
        }

        protected void OnCheckboxChange(ChangeEventArgs args) 
        {
            if (args.Value != null && args.Value is bool) 
            {
                bool value = (bool)args.Value;
                if (_Checked != value) 
                {
                    _Checked = (bool)args.Value;
                    if (OnCheckedChange.HasDelegate)
                    {
                        OnCheckedChange.InvokeAsync(new MDUIEventArgs<Tr>() { Instance = this });
                    }
                }
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, _Tag);
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "id", Id);
            builder.AddAttribute(3, "class", ClassMapper.Class);
            builder.AddAttribute(4, "style", Style);
            builder.AddAttribute(5, "onchange", EventCallback.Factory.Create(this, OnCheckboxChange));
            builder.AddElementReferenceCapture(6, x => Ref = x);
            builder.AddContent(7, ChildContent);
            builder.CloseElement();
        }
    }
}
