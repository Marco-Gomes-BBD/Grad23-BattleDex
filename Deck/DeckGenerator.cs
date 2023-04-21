using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using BlipFill = DocumentFormat.OpenXml.Presentation.BlipFill;
using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
using NonVisualPictureDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureDrawingProperties;
using NonVisualPictureProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureProperties;
using Picture = DocumentFormat.OpenXml.Presentation.Picture;
using ShapeProperties = DocumentFormat.OpenXml.Presentation.ShapeProperties;
using DShape = DocumentFormat.OpenXml.Drawing.Shape;
using Path = System.IO.Path;

namespace Grad23_BattleDex.services;

public class DeckGenerator
{
    public static void CreatePresentation(string templateFile, string resultFilePath,
        string topic, List<string> imagePaths)
    {
        File.Copy(templateFile, resultFilePath, true);

        using (PresentationDocument presentation = PresentationDocument.Open(resultFilePath, true))
        {
            AddTopic(presentation.PresentationPart, topic);
            for (int i = 0; i < imagePaths.Count; i++)
            {
                InsertSlide(presentation.PresentationPart, imagePaths[i]);
            }
        }
    }

    private static void AddTopic(PresentationPart presentationPart, string topic)
    {
        Slide slide = presentationPart.SlideParts.First().Slide;
        if (slide.InnerXml.Contains("PlaceHolder"))
        {
            Regex regex = new Regex("PlaceHolder");
            slide.InnerXml = regex.Replace(slide.InnerXml, topic);
        }
    }

    private static void AddImage(SlidePart slidePart, string image, ImagePartType imagePartType)
    {
        ImagePart imagePart = slidePart
            .AddImagePart(imagePartType);

        using (var stream = File.OpenRead(image))
        {
            imagePart.FeedData(stream);
        }

        ShapeTree tree = slidePart
            .Slide
            .Descendants<ShapeTree>()
            .First();

        var picture = new Picture();

        picture.NonVisualPictureProperties = new NonVisualPictureProperties();
        picture.NonVisualPictureProperties.Append(new NonVisualDrawingProperties
        {
            Name = "My Shape",
            Id = (uint)tree.ChildElements.Count - 1
        });

        var nonVisualPictureDrawingProperties = new NonVisualPictureDrawingProperties();
        nonVisualPictureDrawingProperties.Append(new PictureLocks
        {
            NoChangeAspect = true
        });
        picture.NonVisualPictureProperties.Append(nonVisualPictureDrawingProperties);
        picture.NonVisualPictureProperties.Append(new ApplicationNonVisualDrawingProperties());

        var blipFill = new BlipFill();
        var blip1 = new Blip
        {
            Embed = slidePart.GetIdOfPart(imagePart)
        };
        var blipExtensionList1 = new BlipExtensionList();
        var blipExtension1 = new BlipExtension
        {
            Uri = $"{{{Guid.NewGuid().ToString()}}}"
        };
        blipExtensionList1.Append(blipExtension1);
        blip1.Append(blipExtensionList1);
        var stretch = new Stretch();
        stretch.Append(new FillRectangle());
        blipFill.Append(blip1);
        blipFill.Append(stretch);
        picture.Append(blipFill);

        picture.ShapeProperties = new ShapeProperties();
        picture.ShapeProperties.Transform2D = new Transform2D(new Offset
        {
            X = 0,
            Y = 0
        }, new Extents
        {
            Cx= 12192000,
            Cy= 6858000
        });
        picture.ShapeProperties.Append(new PresetGeometry
        {
            Preset = ShapeTypeValues.Rectangle
        });

        tree.Append(picture);
    }

    private static void InsertSlide(PresentationPart presentationPart, string imagePath)
    {
        ImagePartType? imagePartType;
        string type = Path.GetExtension(imagePath);

        switch (type.Trim().ToUpper())
        {
            case ".BMP":
                imagePartType = ImagePartType.Bmp;
                break;
            case ".JPG":
            case ".JPEG":
                imagePartType = ImagePartType.Jpeg;
                break;
            case ".PNG":
                imagePartType = ImagePartType.Png;
                break;
            default:
                return;
        }

        Slide slide = new Slide(new CommonSlideData(new ShapeTree()));
        SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

        slide.Save(slidePart);
        SlideMasterPart smPart = presentationPart.SlideMasterParts.First();
        SlideLayoutPart? slPart = smPart.SlideLayoutParts.First();

        slidePart.AddPart<SlideLayoutPart>(slPart);
        slidePart.Slide.CommonSlideData = (CommonSlideData)slPart.SlideLayout.CommonSlideData.Clone();

        AddImage(slidePart, imagePath, imagePartType.Value);
        presentationPart.Presentation.SlideIdList.AppendChild<SlideId>(new SlideId());
    }
}