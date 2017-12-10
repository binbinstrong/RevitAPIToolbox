using System.Collections.Generic;
using Autodesk.Revit.DB;
using Techyard.Revit.Implementations.CurveDivide;

namespace Techyard.Revit.Database
{
    public static class CurveExtension
    {
        //public static IEnumerable<XYZ> EquallyDivideByInterpolation(this Curve curve, int divideNum)
        //{
        //    return CurveDivider.GetDivider(curve.GetType()).Divide(curve, divideNum);
        //}

        /// <summary>
        ///  求曲线交点
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static XYZ GetIntersection(this Curve c1, Curve c2)
        {
            IntersectionResultArray intersectionR = new IntersectionResultArray();
            SetComparisonResult comparisonR;

            comparisonR = c1.Intersect(c2, out intersectionR);

            XYZ intersectionResult = null;
            if (SetComparisonResult.Disjoint != comparisonR)
            {
                if (!intersectionR.IsEmpty)
                {
                    intersectionResult = intersectionR.get_Item(0).XYZPoint;
                }
            }
            return intersectionResult;
        }
    }
}