package crc6452ffdc5b34af3a0f;


public class StepperHandlerManager_StepperListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Maui.Platform.StepperHandlerManager+StepperListener, Microsoft.Maui", StepperHandlerManager_StepperListener.class, __md_methods);
	}

	public StepperHandlerManager_StepperListener ()
	{
		super ();
		if (getClass () == StepperHandlerManager_StepperListener.class) {
			mono.android.TypeManager.Activate ("Microsoft.Maui.Platform.StepperHandlerManager+StepperListener, Microsoft.Maui", "", this, new java.lang.Object[] {  });
		}
	}

	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
