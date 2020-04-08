using System;
using Xamarin.Forms;

namespace TFTHelper2.Mobile.UI.ViewModels.Base
{
    public class Behaviors : Behavior<View>
    {
        protected override void OnAttachedTo(View bindable)
        {
            
            base.OnAttachedTo(bindable);
            // Perform setup
        }

        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);
            // Perform clean up
        }
    }
}
