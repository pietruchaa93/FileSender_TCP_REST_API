using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;
using Android.Content.PM;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android;
using System.Threading.Tasks;

namespace FileSender_TCP_REST_API
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            FindViewById<Button>(Resource.Id.button_connect_TCP).Click += (sender, args) =>
            {
                var test_sender = new FileSender_TCP();
                test_sender.Start();


                View view = (View)sender;
                Snackbar.Make(view, "Send file...", Snackbar.LengthLong)
                        .SetAction("Action", (View.IOnClickListener)null).Show();
            };

            FindViewById<Button>(Resource.Id.button_connect_REST_API).Click += (sender, args) =>
            {
                FileSender_REST_API.Start();


                View view = (View)sender;
                Snackbar.Make(view, "Send file...", Snackbar.LengthLong)
                        .SetAction("Action", (View.IOnClickListener)null).Show();
            };




        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == 1)
            {
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted && grantResults[1] == Permission.Granted)
                {
                    // Permissions have been enabled, you can perform memory read and write operations
                }
                else
                {
                    // Permissions not granted, display appropriate warning
                }
            }
        }
	}
}
