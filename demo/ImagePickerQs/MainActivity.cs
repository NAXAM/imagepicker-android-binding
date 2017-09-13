using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Com.Nguyenhoanglam.Imagepicker.UI.Imagepicker;
using Android.Support.V7.Widget;
using Com.Nguyenhoanglam.Imagepicker.Model;
using System.Collections.Generic;
using static Android.Resource;

namespace ImagePickerQs
{
    [Activity(Label = "ImagePickerQs", MainLauncher = true, Icon = "@mipmap/ic_launcher", Theme = "@style/MyTheme.Base")]
    public class MainActivity : AppCompatActivity
    {
        private Switch folderModeSwitch;
        private Switch multipleModeSwitch;
        private Switch cameraOnlySwitch;
        private Button pickImageButton;
        private Button launchFragmentButton;
        private RecyclerView recyclerView;

        private ImageAdapter adapter;
        private List<Image> images = new List<Image>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //
            folderModeSwitch = FindViewById<Switch>(Resource.Id.switch_folder_mode);
            multipleModeSwitch = FindViewById<Switch>(Resource.Id.switch_multiple_mode);
            cameraOnlySwitch = FindViewById<Switch>(Resource.Id.switch_camera_only);
            pickImageButton = FindViewById<Button>(Resource.Id.button_pick_image);
            launchFragmentButton = FindViewById<Button>(Resource.Id.button_launch_fragment);
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            pickImageButton.Click += (s, e) =>
            {
                Start();
            };
            launchFragmentButton.Click += (s, e) =>
            {
                launchFragment();

            };
            adapter = new ImageAdapter(this);
            RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);


        }
		public void Start()
		{
            bool folderMode = folderModeSwitch.Checked;
            bool multipleMode = multipleModeSwitch.Checked;
            bool cameraOnly = cameraOnlySwitch.Checked;

            ImagePicker.With(this)
                    .SetFolderMode(folderMode)
                    .SetCameraOnly(cameraOnly)
                    .SetFolderTitle("Album")
                    .SetMultipleMode(multipleMode)
                    .SetSelectedImages(images)
                    .SetMaxSize(10)
                    .Start();
        }
        private void launchFragment()
        {
            bool folderMode = folderModeSwitch.Checked;
            bool multipleMode = multipleModeSwitch.Checked;
            bool cameraOnly = cameraOnlySwitch.Checked;

            Config config = new Config();
            config.CameraOnly=cameraOnly;
            config.MultipleMode=multipleMode;
            config.FolderMode=folderMode;
            config.ShowCamera=true;
            config.MaxSize = 100;
            config.DoneTitle = "done title";
            config.FolderTitle="folder title";
            config.ImageTitle="image title";
            config.SavePath=SavePath.Default;
            config.SelectedImages=new List<Image>();

            SupportFragmentManager
                    .BeginTransaction()
                    .Replace(Resource.Id.fragment_container, MainFragment.newInstance(config))
                    .CommitAllowingStateLoss();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            if (requestCode == Config.RcPickImages && (int)resultCode == -1 && data != null)
            {
               

                var list = data.GetParcelableArrayListExtra(Config.ExtraImages);
                if (list != null) {
                    foreach (var item in list)
                    {
                        images.Add((Image)item);
                    }
                }
               
                adapter.setData(images);
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }

        //public override void OnBackPressed()
        //{
        //    FragmentManager fm = GetSupportFragmentManager();
        //    Fragment fragment = fm.FindFragmentById(Resource.Id.fragment_container);
        //    if (fragment == null)
        //    {
        //        Finish();
        //    }
        //    else
        //    {
        //        fm.BeginTransaction().Remove(fragment).CommitAllowingStateLoss();
        //    }
        //}

    }
}

