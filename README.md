## ImagePicker
A simple library to select images from the gallery and camera.

## Download
```
Install-Package Naxam.ImagePicker.Droid
```
## How to use
### Start image picker activity
- Quick call
```c#
ImagePicker.Create(this)
            .FolderMode(true) // set folder mode (false by default)
            .FolderTitle("Folder") // folder selection title
            .ImageTitle("Tap to select") // image selection title
            .Single() // single mode
            .Multi() // multi mode (default mode)
            .Limit(10) // max images can be selected (999 by default)
            .ShowCamera(true) // show camera or not (true by default)
            .ImageDirectory("Camera")   // captured image directory name ("Camera" folder by default)
            .Origin(images) // original selected images, used in multi mode
            .Start(REQUEST_CODE_PICKER); // start image picker activity with request code
```                
       
### Receive result

```c#
protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
{
    if (resultCode == Result.Ok && requestCode == REQUEST_CODE_PICKER) {
        var pickedImages = data.GetParcelableArrayListExtra(ImagePickerActivity.IntentExtraSelectedImages);

        Toast.MakeText(this, $"You picked {pickedImages.Count} images", ToastLength.Short)
                .Show();
    }
}
```

## Screenshot

|  |  | |
| ---: | ---| :---|
| <img src="https://cloud.githubusercontent.com/assets/4979755/18304733/46cfad58-750e-11e6-9a6c-129ece6cfc7d.png" /> |  | 
<img src="https://cloud.githubusercontent.com/assets/4979755/18304727/44117484-750e-11e6-8ad1-85301a171690.png" /> |


### Thanks
- @NguyenHoangLam for his library in Java