using Autodesk.Revit.DB;

namespace Techyard.Revit.Database
{
    public static class XYZExtension
    {
        public static XYZ LinearInterpolation(this XYZ first, XYZ second, double length2First)
        {
            var vector = second - first;
            return first + vector * (length2First / vector.GetLength());
        }

        public static XYZ Copy(this XYZ xyz)
        {
            return new XYZ(xyz.X, xyz.Y, xyz.Z);
        }

        public static string AsString(this XYZ point)
        {
            return $"( {point.X} , {point.Y} , {point.Z} )";
        }


        //++++++++++++++++++++++++++++++++
        //   BinAdd 
        //   xuzhaobin
        //++++++++++++++++++++++++++++++++

        /// <summary>
        /// 点在面上的投影点
        /// </summary>
        /// <param name="po"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static XYZ ProjectToPlane(this XYZ po, Plane p)
        {

            XYZ vec_po_to_planeOrigin = p.Origin - po;

            if (!IsEqual(vec_po_to_planeOrigin.DotProduct(p.Normal), 0))
            {
                return po + p.Normal * vec_po_to_planeOrigin.DotProduct(p.Normal);
            }
            else
            {
                return po;
            }
        }
        /// <summary>
        /// 判断浮点数相等
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        private static bool IsEqual(double d1,double d2)
        {
            double precision = 1e-6;

            if (d1-d2<precision)
            {
                return true;
            }
            return false;
        }
    }
}
