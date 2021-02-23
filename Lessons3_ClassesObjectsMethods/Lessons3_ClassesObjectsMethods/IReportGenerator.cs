using System.Collections;

namespace Lessons3_ClassesObjectsMethods
{
    interface IReportGenerator<out TUser> : IComparer
    {
        public int Compare(object a, object b);
    }
}