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
   public static  class LineExtension
    {
        /// <summary>
        /// 线面相交求交点
        /// </summary>
        /// <param name="l"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static XYZ Intersect(this Line l,Plane p)
        {
            XYZ result = null;
            if (! l.Direction.DotProduct(p.Normal).IsEqual(0))
            {
                if (l.IsBound)
                {
                    XYZ end1_p = l.GetEndPoint(0).ProjectToPlane(p);
                    XYZ end2_p = l.GetEndPoint(1).ProjectToPlane(p);
                    Line l_tem = Line.CreateUnbound(end1_p, end2_p);
                    result = l_tem.GetIntersection(l);
                }

                else
                {
                    XYZ end1_p = l.Origin.ProjectToPlane(p);
                    XYZ end2_p = (l.Origin + l.Direction * 3).ProjectToPlane(p);
                    Line l_tem = Line.CreateUnbound(end1_p, end2_p);
                    result = l_tem.GetIntersection(l);
                }
            }
            return result;
        }

    }
}
