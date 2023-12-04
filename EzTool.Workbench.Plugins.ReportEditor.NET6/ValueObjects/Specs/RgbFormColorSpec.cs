namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs
{
    public  class RgbFormColorSpec
    {

        #region -- 靜態方法 (Shared Method ) --

        public static RgbFormColorSpec  Initial(int R, int G, int B)
        {
            return new RgbFormColorSpec()
            {
                R = R,
                G = G,
                B = B
            };
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        public int R { get; set; } = 0;
        public int G { get; set; } = 0;
        public int B { get; set; } = 0;

        #endregion

    }
}
