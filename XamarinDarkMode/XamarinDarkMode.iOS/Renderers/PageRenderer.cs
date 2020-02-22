[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.ContentPage), typeof(XamarinDarkMode.iOS.Renderers.PageRenderer))]
namespace XamarinDarkMode.iOS.Renderers
{
    using System;
    using UIKit;
    using Xamarin.Forms.Platform.iOS;
    using XamarinDarkMode.Styles;

    public class PageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                return;

            if (Element == null)
                return;

            try
            {
                SetTheme();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error changing theme. {ex?.Message}");
            }
        }

        public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
        {
            base.TraitCollectionDidChange(previousTraitCollection);
            if (TraitCollection.UserInterfaceStyle != previousTraitCollection.UserInterfaceStyle)
                SetTheme();
        }

        private void SetTheme()
        {
            if (TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark)
                App.Current.Resources = new DarkTheme();
            else
                App.Current.Resources = new LightTheme();
        }
    }
}