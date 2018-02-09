using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace GradientRendererApp
{
    public class NewButton : ContentPage
    {
        public NewButton()
        {
            var button = new GradientColorButton
            {
                Text = "Gradient",
                TextColor = Color.White,
                StartColor = Color.Blue,
                EndColor = Color.DarkBlue,
                StartTouchColor = Color.Blue,
                EndTouchColor = Color.Wheat
            };
            button.Clicked += (sender, e) => 
            {
                Debug.WriteLine("Click");
            };

            Content = new StackLayout
            {
                Children = {
                    button
                }
            };
        }
    }
}
