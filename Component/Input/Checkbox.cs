//https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputCheckbox.cs
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JGLB.MDUI
{
    /// <summary>
    /// 复选框 / 开关（Switch）
    /// </summary>
    public class Checkbox : MduiInputBase<bool>
    {
        /// <summary>
        /// input class
        /// </summary>
        [Parameter]
        public bool InputClass { get; set; }
        private string _InputStyle;
        /// <summary>
        /// input style
        /// </summary>
        [Parameter]
        public string InputStyle
        {
            get => _InputStyle;
            set
            {
                _InputStyle = value;
                if (!string.IsNullOrWhiteSpace(_InputStyle) && !_InputStyle.EndsWith(";"))
                {
                    _InputStyle += ";";
                }
                //this.StateHasChanged();
            }
        }
        /// <summary>
        /// 指示不确定状态
        /// </summary>
        [Parameter]
        public bool Indeterminate { get; set; }
        /// <summary>
        /// 这是一个开关
        /// </summary>
        [Parameter]
        public bool Switch { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public ElementReference InputRef { get; set; }
        public string InputId => $"{Id}-input";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            await Js.InvokeVoidAsync("mduiblazor.SetCheckboxIndeterminate", InputRef, Indeterminate);
        }

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            /*
            <label class="mdui-checkbox">
              <input type="checkbox"/>
              <i class="mdui-checkbox-icon"></i>
              默认不选中
            </label>
             */
            string labelCls = Switch ? "mdui-switch" : "mdui-checkbox";
            builder.OpenElement(0, "label");
            builder.AddAttribute(1, "id", Id);
            builder.AddAttribute(2, "class", $"{labelCls} {ClassMapper.Class}");
            builder.AddAttribute(3, "style", Style);
            builder.AddElementReferenceCapture(4, x => Ref = x);
            //input
            builder.AddContent(5, builder2 =>
            {
                builder2.OpenElement(0, "input");
                builder2.AddMultipleAttributes(1, AdditionalAttributes);
                builder2.AddAttribute(2, "type", "checkbox");
                builder2.AddAttribute(3, "class", $"{InputClass} {CssClass}");
                builder2.AddAttribute(4, "style", InputStyle);
                builder2.AddAttribute(5, "id", InputId);
                builder2.AddAttribute(6, "checked", BindConverter.FormatValue(CurrentValue));
                builder2.AddAttribute(7, "onchange", EventCallback.Factory.CreateBinder<bool>(this, __value => CurrentValue = __value, CurrentValue));
                builder2.SetUpdatesAttributeName("checked");
                builder2.AddElementReferenceCapture(8, __inputReference => InputRef = __inputReference);
                builder2.CloseElement();
            });
            //icon
            string iconCls = Switch ? "mdui-switch-icon" : "mdui-checkbox-icon";
            builder.AddContent(6, builder3 =>
            {
                builder3.OpenElement(0, "i");
                builder3.AddAttribute(1, "class", iconCls);
                builder3.CloseElement();
            });
            //text
            builder.AddContent(7, ChildContent);
            builder.CloseElement();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage)
            => throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
    }
}
