// // using Microsoft.Office.Interop.PowerPoint;
// // using Application = Microsoft.Office.Interop.PowerPoint.Application;
//
// // using PowerpointApp = Microsoft.Office.Interop.PowerPoint.Application;
//
// using System.Windows.Documents;
// using DocumentFormat.OpenXml.ExtendedProperties;
// using DocumentFormat.OpenXml.Presentation;
//
// namespace Grad23_BattleDex.services;
//
// public class PresentationGenerator
// {
//     // public static void CreatePresentation(List<string> imagePaths)
//     // {
//     //     PowerpointApp pptApplication = new PowerpointApp();
//     //
//     //     // IPresentation presentation = Presentation.Create();
//     //     Presentation pp = new Presentation();
//     //
//     //     Slides slides;
//     //     // _Slide slide;
//     //     TextRange objText;
//     //
//     //     for (int i = 0 ; i < imagePaths.Count ; i++)
//     //     {
//     //         Slide slide = pp.Slides[i];
//     //
//     //         // Presentation pptPresentation = pp.Slides.Add();
//     //
//     //         Presentation pptPresentation = pptApplication.Presentations.Add(MsoTriState.msoTrue);
//     //
//     //         ISlide slide = presentation.Slides.Add(SlideLayoutType.Blank);
//     //         Stream pic = new FileStream(path, FileMode.Open);
//     //
//     //         // slide.Shapes.AddTextBox(400, 250, 200, 100).TextBody.AddParagraph("Hello World");
//     //         slide.Shapes.AddPicture(pic, 400, 250, 200, 100);
//     //     }
//     //
//     //     presentation.Save(@"C:\Users\dubeb003\projects\grad\cs-lvlup\battle-dex\result.pptx");
//     //     System.Console.WriteLine("Well well well...");
//     // }
//
//     public static void CreatePresentation(List<string> imagePaths)
//     {
//         // _Slide slide;
//         // TextRange objText;
//
//         Presentation presentation = new Presentation();
//
//         Slide ss = presentation;
//
//         Microsoft.Office.Interop.PowerPoint.Application pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();
//
//         CustomLayout customLayout = presentation.SlideMaster.CustomLayouts[PpSlideLayout.ppLayoutText];
//
//         Slides slides = presentation.Slides;
//         slide = slides.AddSlide(1, customLayout);
//
//         // Add title
//         objText = slide.Shapes[1].TextFrame.TextRange;
//         objText.Text = "FPPT.com";
//         objText.Font.Name = "Arial";
//         objText.Font.Size = 32;
//
//         objText = slide.Shapes[2].TextFrame.TextRange;
//         objText.Text = "Content goes here\nYou can add text\nItem 3";
//
//         // Shape shape = slide.Shapes[3].PictureFormat.;
//         slide.Shapes.AddPicture(pictureFileName,Microsoft.Office.Core.MsoTriState.msoFalse,Microsoft.Office.Core.MsoTriState.msoTrue,shape.Left, shape.Top, shape.Width, shape.Height);
//
//         // slide.NotesPage.Shapes[2].TextFrame.TextRange.Text = "This demo is created by FPPT using C# - Download free templates from http://FPPT.com";
//
//
//
//         presentation.SaveAs(@"c:\temp\fppt.pptx", PpSaveAsFileType.ppSaveAsDefault, new MsoTriState());
//         presentation.Close();
//         pptApplication.Quit();
//     }
//
//     // public static void CreatePresentation(List<string> imagePaths)
//     // {
//     //     _Slide slide;
//     //     TextRange objText;
//     //
//     //     Presentation presentation = new Presentation();
//     //
//     //     Slide ss = presentation.Slides[0];
//     //
//     //     Microsoft.Office.Interop.PowerPoint.Application pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();
//     //
//     //     CustomLayout customLayout = presentation.SlideMaster.CustomLayouts[PpSlideLayout.ppLayoutText];
//     //
//     //     Slides slides = presentation.Slides;
//     //     slide = slides.AddSlide(1, customLayout);
//     //
//     //     // Add title
//     //     objText = slide.Shapes[1].TextFrame.TextRange;
//     //     objText.Text = "FPPT.com";
//     //     objText.Font.Name = "Arial";
//     //     objText.Font.Size = 32;
//     //
//     //     objText = slide.Shapes[2].TextFrame.TextRange;
//     //     objText.Text = "Content goes here\nYou can add text\nItem 3";
//     //
//     //     // Shape shape = slide.Shapes[3].PictureFormat.;
//     //     slide.Shapes.AddPicture(pictureFileName,Microsoft.Office.Core.MsoTriState.msoFalse,Microsoft.Office.Core.MsoTriState.msoTrue,shape.Left, shape.Top, shape.Width, shape.Height);
//     //
//     //     // slide.NotesPage.Shapes[2].TextFrame.TextRange.Text = "This demo is created by FPPT using C# - Download free templates from http://FPPT.com";
//     //
//     //
//     //
//     //     presentation.SaveAs(@"c:\temp\fppt.pptx", PpSaveAsFileType.ppSaveAsDefault, new MsoTriState());
//     //     presentation.Close();
//     //     pptApplication.Quit();
//     // }
// }