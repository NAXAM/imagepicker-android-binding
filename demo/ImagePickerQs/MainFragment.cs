using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Com.Nguyenhoanglam.Imagepicker.Model;
using Com.Nguyenhoanglam.Imagepicker.UI.Imagepicker;
using static Android.Graphics.Interpolator;

namespace ImagePickerQs
{
    public class MainFragment : Fragment
    {
        public static String EXTRA_CONFIG = "Config";


        private RecyclerView recyclerView;
        private Button pickImageButton;

        private Config config;
        private ImageAdapter adapter;
        private List<Image> images = new List<Image>();

        public static MainFragment newInstance(Config config)
        {
            Bundle args = new Bundle();
            args.PutParcelable(EXTRA_CONFIG, config);

            MainFragment fragment = new MainFragment();
            fragment.Arguments=args;
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            config = (Config)Arguments.GetParcelable(EXTRA_CONFIG);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_main, container, false);

        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            recyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView);
            pickImageButton = (Button)view.FindViewById(Resource.Id.button_pick_image);
            pickImageButton.Click += (s, e) =>
            {
                start();

            };
        adapter = new ImageAdapter(view.Context);
        RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(view.Context, LinearLayoutManager.Horizontal, false);
        recyclerView.SetLayoutManager(layoutManager);
        recyclerView.SetAdapter(adapter);
        }
        private void start()
        {
            ImagePicker.With(this)
                    .SetFolderMode(config.FolderMode)
                    .SetCameraOnly(config.CameraOnly)
                    .SetFolderTitle(config.FolderTitle)
                    .SetMultipleMode(config.MultipleMode)
                    .SetSelectedImages(config.SelectedImages)
                    .SetMaxSize(config.MaxSize)
                    .Start();
        }
        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            if (requestCode == Config.RcPickImages && resultCode == -1 && data != null)
            {
                var list = data.GetParcelableArrayListExtra(Config.ExtraImages);
                foreach (var item in list)
                {
                    images.Add((Image)item);
                }
               // images = data.GetParcelableArrayListExtra(Config.ExtraImages);
                adapter.setData(images);
            }
        }

    }
}