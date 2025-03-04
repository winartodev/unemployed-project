using Log = Freyja.Logger.Logger;

namespace UnemployedProject.Runtime
{
    public static class Logger
    {
        private static Log _show;

        public static Log Show
        {
            get
            {
                if (_show == null)
                {
                    _show = Log.AddLog("UnemployedProject");
                }

                return _show;
            }
        }
    }
}