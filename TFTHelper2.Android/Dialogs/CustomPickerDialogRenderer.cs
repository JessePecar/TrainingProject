using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Android.Widget;
using TFTHelper2.Models;

namespace TFTHelper2.Droid.Dialogs
{
    public class CustomPickerDialogRenderer: Dialog
    {
        public CustomPickerDialogRenderer(Context context, EventHandler<PickerEventArgs> callBack) : base(context)
        {
            RequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.CustomPickerDialog);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public void SetCancelButton(string buttonText, EventHandler<DialogClickEventArgs> e)
        {
            Button cancel = (Button)FindViewById(Resource.Id.CancelButton);
            if(cancel != null)
            {
                cancel.Text = buttonText;
            }
            
        }

        public void SetPickerTitle(string title)
        {
            TextView titleView = (TextView)FindViewById(Resource.Id.PickerTitle);
            if(titleView != null)
                titleView.Text = title;
        }

        public void SetListViewItems(List<ClassModel> ItemsList)
        {
            if (Context.Resources == null) return;
            List<IDictionary<string, object>> items = new List<IDictionary<string, Object>>();
            foreach(ClassModel model in ItemsList)
            {
                int resourceId = Context.Resources.GetIdentifier(model.ClassIcon, "drawable", Context.PackageName);
                if (resourceId == 0)
                {
                    items.Add(new Dictionary<string, object>() {
                        {"Name", model.Name},
                        {"Icon",  Resource.Drawable.darius}
                    });
                }
                else
                {
                    items.Add(new Dictionary<string, object>() {
                        {"Name", model.Name},
                        {"Icon", Context.Resources.GetDrawable(resourceId, Context.Theme)}
                    });
                }
            }
            SimpleAdapter simple = new SimpleAdapter(this.Context, items, Resource.Layout.CustomPickerDialog, new string[] { "Name", "Icon"}, new int[] { Resource.Id.userTitle , Resource.Id.userImage });
            ListView listView = (ListView)FindViewById(Resource.Id.ListView);
            if(listView != null)
            {
                listView.Adapter = simple;
            }
        }

    }

    //This will be used somehow I think
    public class PickerEventArgs : EventArgs 
    {
        public PickerEventArgs(){ }
        public string SelectedItem { get; }
    }

}
