using System;
using Android.Support.V7.Widget;

namespace Com.Nguyenhoanglam.Imagepicker.Adapter
{
    partial class FolderPickerAdapter
    {
        public override RecyclerView.ViewHolder OnCreateViewHolder(Android.Views.ViewGroup parent, int viewType) {
            return OnCreateFolderViewHolder(parent, viewType);
        }

        public override unsafe void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
            OnBindViewHolder((FolderPickerAdapter.FolderViewHolder) holder, position);
        }
	}
	partial class ImagePickerAdapter
	{
		public override RecyclerView.ViewHolder OnCreateViewHolder(Android.Views.ViewGroup parent, int viewType)
		{
			return OnCreateImageViewHolder(parent, viewType);
		}

		public override unsafe void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			OnBindViewHolder((ImagePickerAdapter.ImageViewHolder)holder, position);
		}
	}
}
