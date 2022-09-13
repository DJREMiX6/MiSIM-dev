using MinecraftServerInstancesLauncher.ApplicationBuilder;

//https://www.minecraft.net/en-us/eula

#region LOG MINECRAFT SERVER ARGS AND JAVA PATH

/*ServerInstanceLauncherConfigurationLoader serverInstanceLauncherConfigurationLoader = new();
serverInstanceLauncherConfigurationLoader.LoadConfigFromFile();
Console.WriteLine(MinecraftServerStringBuilder.BuildJavaPath(serverInstanceLauncherConfigurationLoader.ServerInstanceLauncherConfiguration));
Console.WriteLine(MinecraftServerStringBuilder.BuildArgs(serverInstanceLauncherConfigurationLoader.ServerInstanceLauncherConfiguration));*/

#endregion LOG MINECRAFT SERVER ARGS AND JAVA PATH

#region JAVA VERSIONS LISTING
/*foreach(string directory in Directory.EnumerateDirectories(Constants.JAVA_INSTANCES_FULL_PATH))
{
    string[] splittedPath = directory.Split(@"\");
    Console.WriteLine(splittedPath[splittedPath.Length - 1]);
}*/
#endregion JAVA VERSIONS LISTING

#region INITIALIZE APPLICATION BUILDER BASED ON DEBUG

IApplicationBuilder builder = ((IApplicationBuilder)(ConstantsAbstraction.DEBUG ? new DebugApplicationBuilder() : new DefaultApplicationBuilder()))
    .Build(args)
    .Start();

#endregion INITIALIZE APPLICATION BUILDER BASED ON DEBUG