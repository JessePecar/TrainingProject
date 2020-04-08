package crc64f6add88a2be4342e;


public class CustomPickerDialogRenderer
	extends android.app.Dialog
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TFTHelper2.Droid.Dialogs.CustomPickerDialogRenderer, TFTHelper2.Android", CustomPickerDialogRenderer.class, __md_methods);
	}


	public CustomPickerDialogRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomPickerDialogRenderer.class)
			mono.android.TypeManager.Activate ("TFTHelper2.Droid.Dialogs.CustomPickerDialogRenderer, TFTHelper2.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CustomPickerDialogRenderer (android.content.Context p0, boolean p1, android.content.DialogInterface.OnCancelListener p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomPickerDialogRenderer.class)
			mono.android.TypeManager.Activate ("TFTHelper2.Droid.Dialogs.CustomPickerDialogRenderer, TFTHelper2.Android", "Android.Content.Context, Mono.Android:System.Boolean, mscorlib:Android.Content.IDialogInterfaceOnCancelListener, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CustomPickerDialogRenderer (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == CustomPickerDialogRenderer.class)
			mono.android.TypeManager.Activate ("TFTHelper2.Droid.Dialogs.CustomPickerDialogRenderer, TFTHelper2.Android", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
