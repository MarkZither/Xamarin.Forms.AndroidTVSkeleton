using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;

namespace Xamarin.Forms.AndroidTVSkeleton.Droid
{

    [Activity(Label = "Xamarin.Forms.AndroidTVSkeleton", Icon = "@mipmap/icon", Theme = "@style/MainTheme", 
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : BaseActivity
    {
        readonly string[] Permissions =
            {
                Manifest.Permission.Camera,
                Manifest.Permission.WriteExternalStorage
            };

        protected override int LayoutResource
        {
            get
            {
                return 0;// Resource.Layout.main; 
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

