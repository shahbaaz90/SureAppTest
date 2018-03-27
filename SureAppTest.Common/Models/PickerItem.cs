// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="PickerItem.cs" company="Zepto Systems">
// //   Zepto Systems
// // </copyright>
// // <summary>
// //   PickerItem
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
using System;
namespace SureAppTest.Common.Models
{
    public class PickerItem
    {
        public int Value { get; set; }
        public string DisplayField { get; set; }

        public override string ToString()
        {
            return this.DisplayField;
        }
    }
}
