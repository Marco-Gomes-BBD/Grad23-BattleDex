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

namespace Grad23_BattleDex.services;

public class DeckGenerator
{
    public static void CreatePresentation(string templateFile, string resultFilePath,
        string topic, List<string> imagePaths)
    {
        File.Copy(templateFile, resultFilePath, true);

        PresentationDocument presentation = PresentationDocument.Open(resultFilePath, true);
        BuildSlides(presentation.PresentationPart, imagePaths);
        AddTopic(presentation.PresentationPart, topic);
    }

    private static void AddTopic(PresentationPart presentationPart, string topic)
    {
        DShape textbox = (DShape) presentationPart.SlideParts.First().Slide.CommonSlideData.ShapeTree.LastChild;
        if (textbox.InnerText.Contains("PlaceHolder"))
        {
            Regex regex = new Regex("PlaceHolder");
            textbox.InnerXml = regex.Replace(textbox.InnerXml, topic); //.TextBody.BodyProperties. = topic;
        }
    }

    public static void AddImage(SlidePart slidePart, string image, ImageTypes type)
    {
        ImagePartType imagePartType;
        switch (type)
        {
            case ImageTypes.Bmp:
                imagePartType = ImagePartType.Bmp;
                break;
            case ImageTypes.Jpg:
                imagePartType = ImagePartType.Jpeg;
                break;
            case ImageTypes.Png:
                imagePartType = ImagePartType.Png;
                break;
            default:
                throw new ArgumentException("Image type not recognised");
        }

        var part = slidePart
            .AddImagePart(imagePartType);

        using (var stream = File.OpenRead(image))
        {
            part.FeedData(stream);
        }

        var tree = slidePart
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
            Embed = slidePart.GetIdOfPart(part)
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
            // TODO:  Check padding size on actual image
            X = 5,
            Y = 5
        }, new Extents
        {
            Cx = 9143990,
            Cy = 6857990
        });
        picture.ShapeProperties.Append(new PresetGeometry
        {
            Preset = ShapeTypeValues.Rectangle
        });

        tree.Append(picture);
    }

    private static void InsertSlide(PresentationPart presentationPart, string imagePath)
    {
        Slide slide = new Slide(new CommonSlideData(new ShapeTree()));
        SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

        slide.Save(slidePart);
        SlideMasterPart smPart = presentationPart.SlideMasterParts.First();
        SlideLayoutPart slPart = smPart.SlideLayoutParts.First();

        slidePart.AddPart<SlideLayoutPart>(slPart);
        slidePart.Slide.CommonSlideData = (CommonSlideData)slPart.SlideLayout.CommonSlideData.Clone();

        AddImage(slidePart, imagePath, ImageTypes.Png);

        presentationPart.Presentation.SlideIdList.AppendChild<SlideId>(new SlideId());
    }

    private static void BuildSlides(PresentationPart pPart, List<string> imagePaths)
    {
        for (int i = 0; i < imagePaths.Count; i++)
        {
            InsertSlide(pPart, imagePaths[i]);
        }
    }
}