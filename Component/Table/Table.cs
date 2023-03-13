using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.MDUI
{
    /// <summary>
    /// 表格 table
    /// </summary>
    public class Table : AbstractSimpleComponent
    {
        /// <summary>
        /// 使列右对齐class 加在th上
        /// </summary>
        public const string ColNumericCls = "mdui-table-col-numeric";
        protected override string _Tag => "table";

        protected override string _CSS => "mdui-table";
        /// <summary>
        /// 使表格的行在鼠标悬浮状态做出响应
        /// </summary>
        [Parameter]
        public bool Hoverable { get; set; }
        /// <summary>
        /// 在每一行前面添加复选框
        /// </summary>
        [Parameter]
        public bool Selectable { get; set; }

        //private List<Tr> TrList { get; set; } = new List<Tr>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ClassMapper
                .If("mdui-table-hoverable", () => Hoverable)
                .If("mdui-table-selectable", () => Selectable)
                ;
        }

        //internal void AddTr(Tr tr) 
        //{
        //    TrList.Add(tr);
        //}
    }
}
