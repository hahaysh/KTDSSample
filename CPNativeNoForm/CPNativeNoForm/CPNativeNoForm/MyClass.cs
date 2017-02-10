using System;

namespace CPNativeNoForm
{
    public class MyClass
    {
        public MyClass()
        {
        }

        public string AddInt(ref int ncount) => string.Format("{0} clicks!",++ncount);
    }
}

