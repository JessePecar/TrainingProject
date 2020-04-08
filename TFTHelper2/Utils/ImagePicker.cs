using System;
using System.Collections;
using Xamarin.Forms;

namespace TFTHelper2.Mobile.UI.Utils
{
    public class ImagePicker : Picker
    {
        public readonly BindableProperty ImageSourceBinding = BindableProperty.Create("ItemsImageSource",
            typeof(IList),
            typeof(Picker),
            null,
            BindingMode.OneWay,
            null,
            OnItemsSourceChanged);

        public IList ItemsImageSource {
            get;
            set;
            }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue);
    }
}
