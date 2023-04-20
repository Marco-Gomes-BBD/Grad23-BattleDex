using Grad23_BattleDex.services;

namespace Grad23_BattleDex;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        string filePath = @"C:\Users\dubeb003\projects\grad\cs-lvlup\battle-dex\result.pptx";
        List<string> imagePaths = new List<string>
        {
            @"C:\Users\dubeb003\projects\grad\cs-lvlup\battle-dex\images\unfinished.png",
            @"C:\Users\dubeb003\projects\grad\cs-lvlup\battle-dex\images\747.png",
            @"C:\Users\dubeb003\projects\grad\cs-lvlup\battle-dex\images\java.png",
            @"C:\Users\dubeb003\projects\grad\cs-lvlup\battle-dex\images\bad.png"
        };

        WellWellWell.CreatePresentation(filePath, imagePaths);
        // PresentationGenerator.CreatePresentation(new List<string> { "C:\\Users\\dubeb003\\projects\\grad\\cs-lvlup\\battle-dex\\images\\MicrosoftTeams-image(1).png" });

        // Application.Run(new BattleDex());
    }    
}
