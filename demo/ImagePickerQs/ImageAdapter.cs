using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Nguyenhoanglam.Imagepicker.Model;
using Android.Support.V7.Widget;
using Com.Bumptech.Glide;

namespace ImagePickerQs
{
    public class ImageAdapter : RecyclerView.Adapter
    {
        private Context context;
        private List<Image> images;
        private LayoutInflater inflater;
        // private RequestOptions options;

        public ImageAdapter(Context context)
        {
            this.context = context;
            inflater = LayoutInflater.From(context);
            images = new List<Image>();
            //options = new RequestOptions().placeholder(R.drawable.image_placeholder).error(R.drawable.image_placeholder);
        }
        public override int ItemCount =>images.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
             Image image = images[position];
            ImageViewHolder mHoder = (ImageViewHolder)holder;

            Glide.With(context)
                    .Load(image.Path)
                    .Into(mHoder.imageView);
        }
        public void setData(List<Image> images)
        {
            this.images.Clear();
            if (images != null)
            {
                this.images.AddRange(images);
            }
           NotifyDataSetChanged();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new ImageViewHolder(inflater.Inflate(Resource.Layout.item_image, parent, false));
        }
         class ImageViewHolder : RecyclerView.ViewHolder
        {
           public ImageView imageView;

            public ImageViewHolder(View itemView) : base(itemView)
            {
                imageView = (ImageView)itemView.FindViewById(Resource.Id.image_thumbnail);
            }

          
        }

}
}