using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Com.Nguyenhoanglam.Imagepicker.Activity;

namespace ImagePickerQs
{
    [Activity(Label = "ImagePickerQs", MainLauncher = true, Icon = "@mipmap/ic_launcher", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        int REQUEST_CODE_PICKER = 2000;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.button_pick_image);

            button.Click += delegate {
                Start();
            };
        }
		public void Start()
		{
			ImagePicker.Create(this)
					.FolderMode(true) // set folder mode (false by default)
					.FolderTitle("Folder") // folder selection title
					.ImageTitle("Tap to select") // image selection title
					.Single() // single mode
					.Multi() // multi mode (default mode)
					.Limit(10) // max images can be selected (999 by default)
					.ShowCamera(true) // show camera or not (true by default)
					.ImageDirectory("Camera")   // captured image directory name ("Camera" folder by default)
					//.Origin(images) // original selected images, used in multi mode
					.Start(REQUEST_CODE_PICKER); // start image picker activity with request code
		}

        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            if (resultCode == Result.Ok && requestCode == REQUEST_CODE_PICKER) {
                var pickedImages = data.GetParcelableArrayListExtra(ImagePickerActivity.IntentExtraSelectedImages);

                Toast.MakeText(this, $"You picked {pickedImages.Count} images", ToastLength.Short)
                     .Show();
            }
        }

    }
}

