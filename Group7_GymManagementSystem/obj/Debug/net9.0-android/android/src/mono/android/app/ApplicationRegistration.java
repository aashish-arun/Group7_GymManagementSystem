package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("Group7_GymManagementSystem.MainApplication, Group7_GymManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc64be1bd17dfec9b6c2.MainApplication.class, crc64be1bd17dfec9b6c2.MainApplication.__md_methods);
		mono.android.Runtime.register ("Microsoft.Maui.MauiApplication, Microsoft.Maui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc6488302ad6e9e4df1a.MauiApplication.class, crc6488302ad6e9e4df1a.MauiApplication.__md_methods);
		
	}
}
