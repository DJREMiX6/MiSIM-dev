using MinecraftServerInstancesLauncher.ApplicationBuilder;

#region OLD WORKING
/*
//JAVA PATH
const string javaFilePath = @"C:\Program Files\Java\jdk-17.0.2\bin";
const string javaFileName = "java.exe";
const string javaFullFilePath = $@"{javaFilePath}\{javaFileName}";

//SERVER PATH
const string minecraftServerPath = @"C:\Users\Francesco\Desktop\Minecraft server\server1.19";
const string minecraftServerFileName = "minecraft_server.1.19.jar";
const string minecraftServerFullFilePath = $@"{minecraftServerPath}\{minecraftServerFileName}";

//RAM SETTINGS
const string minecraftServerMinRamValue = "4G";
const string minecraftServerMaxRamValue = "8G";
const string minecraftServerMinRam = $"-Xmx{minecraftServerMaxRamValue}";
const string minecraftServerMaxRam = $"-Xms{minecraftServerMinRamValue}";

//NOGUI
const string minecraftServerNoGui = "nogui";

//FULL ARGS
const string processFullArgs = $"{minecraftServerMaxRam} {minecraftServerMinRam} -jar \"{minecraftServerFullFilePath}\" {minecraftServerNoGui}";

Console.WriteLine();
Console.WriteLine($"Java full file path: {javaFullFilePath}");
Console.WriteLine($"Minecraft server full file path: {minecraftServerFullFilePath}");
Console.WriteLine($"Minecraft server process full args: {processFullArgs}");

using (Process serverInstance = new())
{
    serverInstance.StartInfo.FileName = javaFullFilePath;
    serverInstance.StartInfo.Arguments = processFullArgs;
    serverInstance.StartInfo.UseShellExecute = false;
    serverInstance.StartInfo.RedirectStandardOutput = true;
    serverInstance.StartInfo.RedirectStandardError = true;

    serverInstance.OutputDataReceived += OnOutputDataReceived;
    serverInstance.ErrorDataReceived += OnErrorDataReceived;

    serverInstance.Start();
    serverInstance.BeginErrorReadLine();
    serverInstance.BeginOutputReadLine();
    serverInstance.WaitForExit();
}

void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
{
    if (e.Data != null)
    {
        if (e.Data.Trim().CompareTo(string.Empty) != 0)
        {
            Console.WriteLine($"Data received:\t{e.Data}");
        }
    }
}

void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
{
    if (e.Data != null)
    {
        if (e.Data.Trim().CompareTo(string.Empty) != 0)
        {
            Console.WriteLine($"Error Data received:\t{e.Data}");
        }
    }
}*/
#endregion OLD WORKING

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