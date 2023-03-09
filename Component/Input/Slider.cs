using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 滑块
    /// </summary>
    public class Slider : MduiInputBase<double>
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
        /// 间续滑块
        /// </summary>
        [Parameter]
        public bool Discrete { get; set; }
        public ElementReference InputRef { get; set; }
        public string InputId => $"{Id}-input";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-slider-discrete", () => Discrete);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "label");
            builder.AddAttribute(1, "id", Id);
            builder.AddAttribute(2, "class", ClassMapper.Class);
            builder.AddAttribute(3, "style", Style);
            builder.AddElementReferenceCapture(4, x => Ref = x);
            //input
            builder.AddContent(5, builder2 =>
            {
                builder2.OpenElement(0, "input");
                builder2.AddMultipleAttributes(1, AdditionalAttributes);
                builder2.AddAttribute(2, "type", "range");
                builder2.AddAttribute(3, "class", $"{InputClass} {CssClass}");
                builder2.AddAttribute(4, "style", InputStyle);
                builder2.AddAttribute(5, "id", InputId);
                builder2.AddAttribute(6, "value", CurrentValueAsString);
                builder2.AddAttribute(7, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
                builder2.SetUpdatesAttributeName("value");
                builder2.AddElementReferenceCapture(8, __inputReference => InputRef = __inputReference);
                builder2.CloseElement();
            });
            builder.CloseElement();
        }

        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out double result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            if (double.TryParse(value, out result))
            {
                validationErrorMessage = null;
                return true;
            }
            else
            {
                validationErrorMessage = $"The {DisplayName} field is not a number.";
                return false;
            }
        }
    }
}
