package md5153917b688e611682e166e47b0f6f595;


public class MainActivity2
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("CPNativeNoForm.Droid.MainActivity2, CPNativeNoForm.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity2.class, __md_methods);
	}


	public MainActivity2 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity2.class)
			mono.android.TypeManager.Activate ("CPNativeNoForm.Droid.MainActivity2, CPNativeNoForm.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
