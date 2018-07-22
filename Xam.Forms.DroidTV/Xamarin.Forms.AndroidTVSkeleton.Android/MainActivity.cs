using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using System.Linq;
using Android.Content;

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

        View layout;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            var intent = Intent;
            if (NeedPermissions(this))
            {
                RequestPermissions();
            }
            else if (intent != null)
            {
                /*intent.SetComponent(null);
                intent.SetPackage("com.google.android.GoogleCamera");
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);
                //Finish();*/
            }
            else
            {
                //Finish();
            }

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        const int RequestLocationId = 0;

        public static bool NeedPermissions(Activity activity)
        {
            return activity.CheckSelfPermission(Manifest.Permission.Camera) != Permission.Granted ||
            activity.CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Permission.Granted;
        }

        void RequestPermissions()
        {
            RequestPermissions(Permissions, RequestLocationId);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            switch (requestCode)
            {
                case RequestLocationId:
                    {
                        bool hasAllPermissions = grantResults.Where(r => r == Permission.Denied).Count() == 0;

                        if (!hasAllPermissions)
                        {
                            Toast.MakeText(this, "Unable to get all required permissions", ToastLength.Long).Show();
                        }

                        //Finish();

                    }
                    break;
            }
        }
        CameraChoiceRequest request;
        Button buttonRear, buttonFront;
        protected override void OnResume()
        {
            base.OnResume();
            if (!IsVoiceInteraction)
            {
                return;
            }

            //Send our our first request asking for front or rear facing camera to use.
            var front = new VoiceInteractor.PickOptionRequest.Option("Front Camera", 0);
            front.AddSynonym("Front");
            front.AddSynonym("Selfie");
            front.AddSynonym("Forward");

            var rear = new VoiceInteractor.PickOptionRequest.Option("Rear Camera", 1);
            rear.AddSynonym("Rear");
            rear.AddSynonym("Back");
            rear.AddSynonym("Normal");

            var prompt = new VoiceInteractor.Prompt("Which camera would you like to use?");
            request = new CameraChoiceRequest(prompt, new[] { front, rear }, new[] { buttonFront, buttonRear });

            VoiceInteractor.SubmitRequest(request);
        }

        protected class CameraChoiceRequest : VoiceInteractor.PickOptionRequest
        {
            View[] views;
            public CameraChoiceRequest(VoiceInteractor.Prompt prompt, Option[] choices, View[] views)
                : base(prompt, choices, null)
            {
                this.views = views;
            }

            public override void OnPickOptionResult(bool finished, Option[] selections, Bundle result)
            {
                base.OnPickOptionResult(finished, selections, result);

                /*if (!finished || selections.Length != 1)
                    return;

                Log.Debug("VoiceCamera", "Selected: " + selections[0].Label + " Index: " + selections[0].Index);

                var fragment = CameraFragment.NewInstance();
                Activity.Intent.PutExtra("android.intent.extra.USE_FRONT_CAMERA", selections[0].Index == 0);
                fragment.Arguments = Activity.Intent.Extras;
                Activity.FragmentManager.BeginTransaction().Replace(Resource.Id.container, fragment).Commit();
                foreach (var view in views)
                    view.Visibility = ViewStates.Gone;*/
            }
        }
    }
}

