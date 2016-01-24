using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace bright
{
    //This static class main function is create and release enroute
    // although more than one instance of EnRoute could be launch, it is highly recomended to
    // have only one. The release function ensures that the pointer to the com object is released
    // and it is called automatically at the form dispose, no need to call it.
    // the main EnRoute object ref are members if this class to make code nicer,  but there
    // is no actual need to follow this convention.
    public static class Enroute
    {
        public static EnRoute3.EnrouteApp enr;
        public static EnRoute3.IerDrawing drawing;
        public static EnRoute3.IerLayer layer;
        public static EnRoute3.IerGroup group;
        public static EnRoute3.IerStrategy strategy;
        public static EnRoute3.IerSelection selection;
        public static EnRoute3.ESpaceUnit units;

        public static EnRoute3.EnrouteApp getEnroute()
        {
            try
            {
                if (enr != null)
                    return enr;
                else
                    return new EnRoute3.EnrouteApp();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void release(EnRoute3.EnrouteApp enr)
        {
            Marshal.FinalReleaseComObject(enr);
        }

    }
}
