namespace EzTool.Workbench.Plugins.ReportEditor.NET6.ValueObjects.Specs
{
    public class ThicknessSepc
    {

        #region -- 靜態方法 (Shared Method ) --

        public static ThicknessSepc Initial(double pi_nUniformLength)
        {
            return new ThicknessSepc()
            {
                Top = pi_nUniformLength,
                Left = pi_nUniformLength,
                Right = pi_nUniformLength,
                Bottom = pi_nUniformLength
            };
        }

        public static ThicknessSepc Initial(double Left, double Top, double Right, double Bottom)
        {
            return new ThicknessSepc()
            {
                Top = Top,
                Left = Left,
                Right = Right,
                Bottom = Bottom
            };
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        public double Left { get; set; } = 0;
        public double Top { get; set; } = 0;
        public double Right { get; set; } = 0;
        public double Bottom { get; set; } = 0;

        #endregion

    }
}
