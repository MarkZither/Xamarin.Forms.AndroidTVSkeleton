using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace Xamarin.Forms.AndroidTVSkeleton.Droid
{
    /// <summary>
    /// https://github.com/jamesmontemagno/MarshmallowSamples/tree/master/VoiceInteractions/VoiceCamera
    /// </summary>
    [Activity(Label = "Voice Camera", LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { MediaStore.IntentActionStillImageCamera }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryVoice })]
    [IntentFilter(new[] { MediaStore.IntentActionStillImageCameraSecure }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryVoice })]

    public abstract class BaseActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public Toolbar Toolbar
        {
            get;
            set;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //SetContentView(LayoutResource);
            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }
        }

        protected abstract int LayoutResource
        {
            get;
        }

        protected int ActionBarIcon
        {
            set { Toolbar.SetNavigationIcon(value); }
        }
    }
}