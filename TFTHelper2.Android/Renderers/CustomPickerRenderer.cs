using System;
using System.Collections.Generic;
using Android.Content;
using TFTHelper2.Droid.Dialogs;
using TFTHelper2.Droid.Renderers;
using TFTHelper2.Mobile.UI.Controls;
using TFTHelper2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace TFTHelper2.Droid.Renderers
{
    public class CustomPickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        CustomPickerDialogRenderer _dialog;
        
        CustomPicker PickerElement;
        public CustomPickerRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null || e.NewElement == null) return;

            if (e.OldElement == null && e.NewElement == null) return;
            PickerElement = e.NewElement as CustomPicker;
            this.Control.Click += OnPickerClick;
            
        }

        void OnPickerClick(object sender, EventArgs e)
        {
            OpenPicker();
        }

        void OpenPicker()
        {
            CreateNewPickerDialog();
            _dialog.Show();
        }

        void CreateNewPickerDialog()
        {
            CustomPicker view = PickerElement;
            
            _dialog = new CustomPickerDialogRenderer(Context, (o, e) =>
            {
                //This is convoluted, I want to try and make this a linq query
                view.SelectedItem = view.ItemsSource[view.ItemsSource.IndexOf(e.SelectedItem)];
                //Clear focus when it is destroyed
                Control.ClearFocus();
                //Set to null after clearing focus
                _dialog = null;
            });
            if(view.ItemsSource.GetType() == typeof(List<ClassModel>))
            {
                _dialog.SetListViewItems((List<ClassModel>)view.ItemsSource);
            }
            _dialog.SetCancelButton("Cancel", (s, o) =>
            {
                _dialog.Dismiss();
            });
            _dialog.SetPickerTitle("Select Filter");


        }
    }
}
