using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectName.Views.Controls
{
    public class GradientButton : Button
    {
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
        public Color StartTouchColor { get; set; }
        public Color EndTouchColor { get; set; }

        public GradientButton()
        {
            BackgroundColor = Color.Transparent;
        }
    }
}
