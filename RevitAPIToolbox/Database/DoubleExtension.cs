//======================================
//Copyright              2017
//CLR版本:               4.0.30319.42000
//机器名称:              XU-PC
//命名空间名称/文件名:   Techyard.Revit.Database/Class1
//创建人:                XU ZHAO BIN
//创建时间:              2017/12/10 22:31:43
//网址:                   
//======================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Techyard.Revit.Database
{
    public static class DoubleExtension
    {
        public static bool IsEqual(this double d1,double d2)
        {
            double precision = 1e-6;

            if (d1-d1<precision)
            {
                return true;
            }
            return false;
        }
    }
}
