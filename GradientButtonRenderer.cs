using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using ProjectName.Droid;
using ProjectName.Views.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace ProjectName.Droid
{
    public class GradientButtonRenderer : ButtonRenderer
    {
        private Xamarin.Forms.Color StartColor { get; set; }
        private Xamarin.Forms.Color EndColor { get; set; }
        private Xamarin.Forms.Color StartTouchColor { get; set; }
        private Xamarin.Forms.Color EndTouchColor { get; set; }

        Android.Widget.Button thisButton;

        GradientDrawable gradient;
        GradientDrawable gradientTouch;

        public GradientButtonRenderer(Context context) : base(context)
        {
        }

        public GradientDrawable DrawGradient(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            var btn = e.NewElement as GradientButton;
            gradient = new GradientDrawable(GradientDrawable.Orientation.BlTr, new[] {
                                btn.StartColor.ToAndroid().ToArgb(),
                                btn.EndColor.ToAndroid().ToArgb()
                });

            //gradient.SetGradientRadius(0f);
            gradient.SetCornerRadius(20);
            gradient.SetStroke(0, btn.StartColor.ToAndroid());
    
            return gradient;
        }

        public GradientDrawable DrawGradientTouch(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            var btn = e.NewElement as GradientButton;
            gradientTouch = new GradientDrawable(GradientDrawable.Orientation.BlTr, new[] {
                                btn.StartTouchColor.ToAndroid().ToArgb(),
                                btn.EndTouchColor.ToAndroid().ToArgb()
                });
            gradientTouch.SetCornerRadius(20);
            gradientTouch.SetStroke(0, btn.StartColor.ToAndroid());
            return gradientTouch;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            // thisButton.Click += HandleButtonClicked;

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                thisButton = Control as Android.Widget.Button;
                //thisButton.SetBackgroundResource(Resource.Drawable.btn_unpress);
                thisButton.Touch += ThisButton_Touch;

                Control.StateListAnimator = new Android.Animation.StateListAnimator();

                Control.SetBackground(DrawGradient(e));

                gradientTouch = DrawGradientTouch(e);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR: ", ex.Message);
            }
        }

        private void ThisButton_Touch(object sender, TouchEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == MotionEventActions.Down)
            {
                //System.Diagnostics.Debug.WriteLine("TouchDownEvent");
                if (gradient != null)
                {
                    //gradient.Alpha = 50; //0-255 
                    thisButton.SetBackground(gradientTouch);
                }
                //thisButton.SetBackgroundColor(Android.Graphics.Color.Gray);
            }
            else if (e.Event.Action == MotionEventActions.Up)
            {
                //System.Diagnostics.Debug.WriteLine("TouchUpEvent");
                if (gradientTouch != null)
                {
                    //gradientTouch.Alpha = 255;
                    thisButton.SetBackground(gradient);
                }
                //thisButton.SetBackgroundColor(Android.Graphics.Color.Blue);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (thisButton != null)
            {
                thisButton.Touch -= ThisButton_Touch;
                //thisButton.Click -= HandleButtonClicked;
            }
            base.Dispose(disposing);
        }
    }
}

/*public enum Orientation {
        *//** draw the gradient from the top to the bottom *//*
        TOP_BOTTOM,
        *//** draw the gradient from the top-right to the bottom-left *//*
        TR_BL,
        *//** draw the gradient from the right to the left *//*
        RIGHT_LEFT,
        *//** draw the gradient from the bottom-right to the top-left *//*
        BR_TL,
        *//** draw the gradient from the bottom to the top *//*
        BOTTOM_TOP,
        *//** draw the gradient from the bottom-left to the top-right *//*
        BL_TR,
        *//** draw the gradient from the left to the right *//*
        LEFT_RIGHT,
        *//** draw the gradient from the top-left to the bottom-right *//*
        TL_BR,
    }*/