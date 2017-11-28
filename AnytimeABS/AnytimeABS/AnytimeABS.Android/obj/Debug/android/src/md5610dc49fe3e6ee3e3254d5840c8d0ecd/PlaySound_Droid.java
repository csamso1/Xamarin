package md5610dc49fe3e6ee3e3254d5840c8d0ecd;


public class PlaySound_Droid
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AnytimeABS.Droid.Dependency.PlaySound_Droid, AnytimeABS.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PlaySound_Droid.class, __md_methods);
	}


	public PlaySound_Droid ()
	{
		super ();
		if (getClass () == PlaySound_Droid.class)
			mono.android.TypeManager.Activate ("AnytimeABS.Droid.Dependency.PlaySound_Droid, AnytimeABS.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
