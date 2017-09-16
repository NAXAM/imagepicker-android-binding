<img src="./art/repo_header.png" alt="RxJava2 for Xamarin.Android" width="728" />

# ImagePicker for Xamarin.Android

A Xamarin.Android binding library for [ImagePicker](https://github.com/nguyenhoanglam/imagepicker) library.

    A simple library to select images from the gallery and camera.

|  | |
| ---: | :---|
| <img src="https://cloud.githubusercontent.com/assets/4979755/18304733/46cfad58-750e-11e6-9a6c-129ece6cfc7d.png" /> | <img src="https://cloud.githubusercontent.com/assets/4979755/18304727/44117484-750e-11e6-8ad1-85301a171690.png" /> |

## About
This project is maintained by Naxam Co.,Ltd.<br>
We specialize in developing mobile applications using Xamarin and native technology stack.<br>

**Looking for developers for your project?**<br>

<a href="mailto:tuyen@naxam.net"> 
<img src="https://github.com/NAXAM/naxam.github.io/blob/master/assets/img/hire_button.png?raw=true" height="40"></a> <br>

## Installation

    Install-Package Naxam.ImagePicker.Droid

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

### Thanks
- @NguyenHoangLam for his library in Java

## License

ImagePicker binding library for Android is released under the MIT license.
See [LICENSE](./LICENSE) for details.

# Get our showcases on AppStore/PlayStore
Try our showcases to know more about our capabilities. 

<a href="https://itunes.apple.com/us/developer/tuyen-vu/id1255432728/" > 
<img src="./art/apple_store.png" width="117" height="34"></a>

<a href="https://play.google.com/store/apps/developer?id=NAXAM+CO.,+LTD" > 
<img src="./art/google_store.png" width="117" height="34"></a>

Contact us if interested.

<a href="mailto:tuyen@naxam.net"> 
<img src="https://github.com/NAXAM/naxam.github.io/blob/master/assets/img/hire_button.png" height="34"></a> <br>
<br>

Follow us for the latest updates<br>[![Twitter URL](https://img.shields.io/twitter/url/http/shields.io.svg?style=social)](https://twitter.com/intent/tweet?text=https://github.com/naxam/imagepicker-android-binding)
[![Twitter Follow](https://img.shields.io/twitter/follow/naxamco.svg?style=social)](https://twitter.com/naxamco)