﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Ch05_AutomatingExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            const int xlPie = 5;
            Console.WriteLine("enter a number: ");
            double number = Convert.ToDouble(Console.ReadLine());
            var excel = new Application();
            excel.Visible = true;
            excel.Workbooks.Add();
            excel.Range["A1"].Value = number;
            excel.Range["A2"].Formula = "=A1*2";
            excel.Range["A1:A2"].Select();
            excel.ActiveSheet.Shapes.AddChart2(251, xlPie).Select();
            excel.ActiveChart.SetSourceData(Source: excel.Range["Sheet1!$A$1:$A$2"]);
        }
    }
}
