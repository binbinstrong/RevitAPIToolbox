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
using Autodesk.Revit.DB;

namespace Techyard.Revit.Database
{
    public static class PlaneHelper
    {
        /// <summary>
        /// 求两个面的交线
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Line Intersect(this Plane p1 ,Plane p2)
        {
            Line result = null;

            XYZ p1_dir = p1.Normal;
            XYZ p2_dir = p2.Normal;

            XYZ p1_o = p1.Origin;
            XYZ p1_o_projectTop2 = p1_o.ProjectToPlane(p2);
            XYZ p1_o_projectTop2_projectTop1 = p1_o_projectTop2.ProjectToPlane(p1);

            Line l = Line.CreateBound(p1_o, p1_o_projectTop2_projectTop1);

            XYZ resultLineOrigin = l.Intersect(p2);
            XYZ resultLineDir = p1_dir.CrossProduct(p2_dir);

            result = Line.CreateUnbound(resultLineOrigin, resultLineDir);
            return result;
        }
    }
}
