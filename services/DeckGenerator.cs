using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office2010.Drawing;
using DocumentFormat.OpenXml.Packaging;

namespace Grad23_BattleDex.services;

using P = DocumentFormat.OpenXml.Presentation;
using D = DocumentFormat.OpenXml.Drawing;

public class DeckGenerator
{
    public static void CreatePresentation(string filepath, List<string> imagePaths)
    {
        var presentationDoc = PresentationDocument.Create(filepath, PresentationDocumentType.Presentation);
        var presentationPart = presentationDoc.AddPresentationPart();
        presentationPart.Presentation = new P.Presentation();

        CreatePresentationParts(presentationPart, imagePaths);

        presentationDoc.Dispose();
    }

    private static void CreatePresentationParts(PresentationPart presentationPart, List<string> imagePaths)
    {
        var slideMasterIdList1 = new P.SlideMasterIdList(new P.SlideMasterId
            { Id = (UInt32Value)2147483648U, RelationshipId = "rId1" });

        var slideIdList1 = new P.SlideIdList(new P.SlideId { Id = (UInt32Value)256U, RelationshipId = "rId2" });
        var slideSize1 = new P.SlideSize { Cx = 9144000, Cy = 6858000, Type = P.SlideSizeValues.Screen4x3 };
        var notesSize1 = new P.NotesSize { Cx = 6858000, Cy = 9144000 };
        var defaultTextStyle1 = new P.DefaultTextStyle();

        presentationPart.Presentation.Append(slideMasterIdList1, slideIdList1, slideSize1, notesSize1,
            defaultTextStyle1);

        SlidePart slidePart1;
        SlideLayoutPart slideLayoutPart1;
        SlideMasterPart slideMasterPart1;
        ThemePart themePart1;


        slidePart1 = CreateSlidePart(presentationPart);
        slideLayoutPart1 = CreateSlideLayoutPart(slidePart1);
        slideMasterPart1 = CreateSlideMasterPart(slideLayoutPart1);
        themePart1 = CreateTheme(slideMasterPart1);

        slideMasterPart1.AddPart(slideLayoutPart1, "rId1");
        presentationPart.AddPart(slideMasterPart1, "rId1");
        presentationPart.AddPart(themePart1, "rId5");
    }

    private static SlidePart CreateSlidePart(PresentationPart presentationPart)
    {
        var slidePart1 = presentationPart.AddNewPart<SlidePart>("rId2");
        slidePart1.Slide = new P.Slide(
            new P.CommonSlideData(
                new P.ShapeTree(
                    new P.NonVisualGroupShapeProperties(
                        new P.NonVisualDrawingProperties { Id = (UInt32Value)1U, Name = "" },
                        new P.NonVisualGroupShapeDrawingProperties(),
                        new P.ApplicationNonVisualDrawingProperties()),
                    new P.GroupShapeProperties(new D.TransformGroup()),
                    new P.Shape(
                        new P.NonVisualShapeProperties(
                            new P.NonVisualDrawingProperties { Id = (UInt32Value)2U, Name = "Title 1" },
                            new P.NonVisualShapeDrawingProperties(new D.ShapeLocks { NoGrouping = true }),
                            new P.ApplicationNonVisualDrawingProperties(new P.PlaceholderShape())),
                        new P.ShapeProperties(),
                        new P.TextBody(
                            new D.BodyProperties(),
                            new D.ListStyle(),
                            new D.Paragraph(new D.EndParagraphRunProperties { Language = "en-US" }))))),
            new P.ColorMapOverride(new D.MasterColorMapping()));
        return slidePart1;
    }

    private static SlideLayoutPart CreateSlideLayoutPart(SlidePart slidePart1)
    {
        var slideLayoutPart1 = slidePart1.AddNewPart<SlideLayoutPart>("rId1");
        var slideLayout = new P.SlideLayout(
            new P.CommonSlideData(new P.ShapeTree(
                new P.NonVisualGroupShapeProperties(
                    new P.NonVisualDrawingProperties { Id = (UInt32Value)1U, Name = "" },
                    new P.NonVisualGroupShapeDrawingProperties(),
                    new P.ApplicationNonVisualDrawingProperties()),
                new P.GroupShapeProperties(new D.TransformGroup()),
                new P.Shape(
                    new P.NonVisualShapeProperties(
                        new P.NonVisualDrawingProperties { Id = (UInt32Value)2U, Name = "" },
                        new P.NonVisualShapeDrawingProperties(new D.ShapeLocks { NoGrouping = true }),
                        new P.ApplicationNonVisualDrawingProperties(new P.PlaceholderShape())),
                    new P.ShapeProperties(),
                    new P.TextBody(
                        new D.BodyProperties(),
                        new D.ListStyle(),
                        new D.Paragraph(new D.EndParagraphRunProperties()))))),
            new P.ColorMapOverride(new D.MasterColorMapping()));
        slideLayoutPart1.SlideLayout = slideLayout;
        return slideLayoutPart1;
    }

    private static SlideMasterPart CreateSlideMasterPart(SlideLayoutPart slideLayoutPart1)
    {
        var slideMasterPart1 = slideLayoutPart1.AddNewPart<SlideMasterPart>("rId1");
        var slideMaster = new P.SlideMaster(
            new P.CommonSlideData(new P.ShapeTree(
                new P.NonVisualGroupShapeProperties(
                    new P.NonVisualDrawingProperties { Id = (UInt32Value)1U, Name = "" },
                    new P.NonVisualGroupShapeDrawingProperties(),
                    new P.ApplicationNonVisualDrawingProperties()),
                new P.GroupShapeProperties(new D.TransformGroup()),
                new P.Shape(
                    new P.NonVisualShapeProperties(
                        new P.NonVisualDrawingProperties { Id = (UInt32Value)2U, Name = "Title Placeholder 1" },
                        new P.NonVisualShapeDrawingProperties(new D.ShapeLocks { NoGrouping = true }),
                        new P.ApplicationNonVisualDrawingProperties(new P.PlaceholderShape
                            { Type = P.PlaceholderValues.Title })),
                    new P.ShapeProperties(),
                    new P.TextBody(
                        new D.BodyProperties(),
                        new D.ListStyle(),
                        new D.Paragraph())))),
            new P.ColorMap
            {
                Background1 = D.ColorSchemeIndexValues.Light1, Text1 = D.ColorSchemeIndexValues.Dark1,
                Background2 = D.ColorSchemeIndexValues.Light2, Text2 = D.ColorSchemeIndexValues.Dark2,
                Accent1 = D.ColorSchemeIndexValues.Accent1, Accent2 = D.ColorSchemeIndexValues.Accent2,
                Accent3 = D.ColorSchemeIndexValues.Accent3, Accent4 = D.ColorSchemeIndexValues.Accent4,
                Accent5 = D.ColorSchemeIndexValues.Accent5, Accent6 = D.ColorSchemeIndexValues.Accent6,
                Hyperlink = D.ColorSchemeIndexValues.Hyperlink,
                FollowedHyperlink = D.ColorSchemeIndexValues.FollowedHyperlink
            },
            new P.SlideLayoutIdList(new P.SlideLayoutId { Id = (UInt32Value)2147483649U, RelationshipId = "rId1" }),
            new P.TextStyles(new P.TitleStyle(), new P.BodyStyle(), new P.OtherStyle()));
        slideMasterPart1.SlideMaster = slideMaster;

        return slideMasterPart1;
    }

    private static ThemePart CreateTheme(SlideMasterPart slideMasterPart1)
    {
        var themePart1 = slideMasterPart1.AddNewPart<ThemePart>("rId5");
        var theme1 = new D.Theme { Name = "Office Theme" };

        var themeElements1 = new D.ThemeElements(
            new D.ColorScheme(
                new D.Dark1Color(new D.SystemColor { Val = D.SystemColorValues.WindowText, LastColor = "000000" }),
                new D.Light1Color(new D.SystemColor { Val = D.SystemColorValues.Window, LastColor = "FFFFFF" }),
                new D.Dark2Color(new D.RgbColorModelHex { Val = "1F497D" }),
                new D.Light2Color(new D.RgbColorModelHex { Val = "EEECE1" }),
                new D.Accent1Color(new D.RgbColorModelHex { Val = "4F81BD" }),
                new D.Accent2Color(new D.RgbColorModelHex { Val = "C0504D" }),
                new D.Accent3Color(new D.RgbColorModelHex { Val = "9BBB59" }),
                new D.Accent4Color(new D.RgbColorModelHex { Val = "8064A2" }),
                new D.Accent5Color(new D.RgbColorModelHex { Val = "4BACC6" }),
                new D.Accent6Color(new D.RgbColorModelHex { Val = "F79646" }),
                new D.Hyperlink(new D.RgbColorModelHex { Val = "0000FF" }),
                new D.FollowedHyperlinkColor(new D.RgbColorModelHex { Val = "800080" })) { Name = "Office" },
            new D.FontScheme(
                new D.MajorFont(
                    new D.LatinFont { Typeface = "Calibri" },
                    new D.EastAsianFont { Typeface = "" },
                    new D.ComplexScriptFont { Typeface = "" }),
                new D.MinorFont(
                    new D.LatinFont { Typeface = "Calibri" },
                    new D.EastAsianFont { Typeface = "" },
                    new D.ComplexScriptFont { Typeface = "" })) { Name = "Office" },
            new D.FormatScheme(
                new D.FillStyleList(
                    new D.SolidFill(new D.SchemeColor { Val = D.SchemeColorValues.PhColor }),
                    new D.GradientFill(
                        new D.GradientStopList(
                            new D.GradientStop(new D.SchemeColor(new D.Tint { Val = 50000 },
                                    new D.SaturationModulation { Val = 300000 }) { Val = D.SchemeColorValues.PhColor })
                                { Position = 0 },
                            new D.GradientStop(new D.SchemeColor(new D.Tint { Val = 37000 },
                                    new D.SaturationModulation { Val = 300000 }) { Val = D.SchemeColorValues.PhColor })
                                { Position = 35000 },
                            new D.GradientStop(new D.SchemeColor(new D.Tint { Val = 15000 },
                                    new D.SaturationModulation { Val = 350000 }) { Val = D.SchemeColorValues.PhColor })
                                { Position = 100000 }
                        ),
                        new D.LinearGradientFill { Angle = 16200000, Scaled = true }),
                    new D.NoFill(),
                    new D.PatternFill(),
                    new D.GroupFill()),
                new D.LineStyleList(
                    new D.Outline(
                        new D.SolidFill(
                            new D.SchemeColor(
                                new D.Shade { Val = 95000 },
                                new D.SaturationModulation { Val = 105000 }) { Val = D.SchemeColorValues.PhColor }),
                        new D.PresetDash { Val = D.PresetLineDashValues.Solid })
                    {
                        Width = 9525,
                        CapType = D.LineCapValues.Flat,
                        CompoundLineType = D.CompoundLineValues.Single,
                        Alignment = D.PenAlignmentValues.Center
                    },
                    new D.Outline(
                        new D.SolidFill(
                            new D.SchemeColor(
                                new D.Shade { Val = 95000 },
                                new D.SaturationModulation { Val = 105000 }) { Val = D.SchemeColorValues.PhColor }),
                        new D.PresetDash { Val = D.PresetLineDashValues.Solid })
                    {
                        Width = 9525,
                        CapType = D.LineCapValues.Flat,
                        CompoundLineType = D.CompoundLineValues.Single,
                        Alignment = D.PenAlignmentValues.Center
                    },
                    new D.Outline(
                        new D.SolidFill(
                            new D.SchemeColor(
                                new D.Shade { Val = 95000 },
                                new D.SaturationModulation { Val = 105000 }) { Val = D.SchemeColorValues.PhColor }),
                        new D.PresetDash { Val = D.PresetLineDashValues.Solid })
                    {
                        Width = 9525,
                        CapType = D.LineCapValues.Flat,
                        CompoundLineType = D.CompoundLineValues.Single,
                        Alignment = D.PenAlignmentValues.Center
                    }),
                new D.EffectStyleList(
                    new D.EffectStyle(
                        new D.EffectList(
                            new D.OuterShadow(
                                new D.RgbColorModelHex(
                                    new D.Alpha { Val = 38000 }) { Val = "000000" })
                            {
                                BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false
                            })),
                    new D.EffectStyle(
                        new D.EffectList(
                            new D.OuterShadow(
                                new D.RgbColorModelHex(
                                    new D.Alpha { Val = 38000 }) { Val = "000000" })
                            {
                                BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false
                            })),
                    new D.EffectStyle(
                        new D.EffectList(
                            new D.OuterShadow(
                                new D.RgbColorModelHex(
                                    new D.Alpha { Val = 38000 }) { Val = "000000" })
                            {
                                BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false
                            }))),
                new D.BackgroundFillStyleList(
                    new D.SolidFill(new D.SchemeColor { Val = D.SchemeColorValues.PhColor }),
                    new D.GradientFill(
                        new D.GradientStopList(
                            new D.GradientStop(
                                    new D.SchemeColor(new D.Tint { Val = 50000 },
                                            new D.SaturationModulation { Val = 300000 })
                                        { Val = D.SchemeColorValues.PhColor })
                                { Position = 0 },
                            new D.GradientStop(
                                    new D.SchemeColor(new D.Tint { Val = 50000 },
                                            new D.SaturationModulation { Val = 300000 })
                                        { Val = D.SchemeColorValues.PhColor })
                                { Position = 0 },
                            new D.GradientStop(
                                    new D.SchemeColor(new D.Tint { Val = 50000 },
                                            new D.SaturationModulation { Val = 300000 })
                                        { Val = D.SchemeColorValues.PhColor })
                                { Position = 0 }),
                        new D.LinearGradientFill { Angle = 16200000, Scaled = true }),
                    new D.GradientFill(
                        new D.GradientStopList(
                            new D.GradientStop(
                                    new D.SchemeColor(new D.Tint { Val = 50000 },
                                            new D.SaturationModulation { Val = 300000 })
                                        { Val = D.SchemeColorValues.PhColor })
                                { Position = 0 },
                            new D.GradientStop(
                                    new D.SchemeColor(new D.Tint { Val = 50000 },
                                            new D.SaturationModulation { Val = 300000 })
                                        { Val = D.SchemeColorValues.PhColor })
                                { Position = 0 }),
                        new D.LinearGradientFill { Angle = 16200000, Scaled = true }))) { Name = "Office" });

        theme1.Append(themeElements1);
        theme1.Append(new D.ObjectDefaults());
        theme1.Append(new D.ExtraColorSchemeList());

        themePart1.Theme = theme1;
        return themePart1;
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
            .Descendants<P.ShapeTree>()
            .First();

        var picture = new P.Picture();

        picture.NonVisualPictureProperties = new P.NonVisualPictureProperties();
        picture.NonVisualPictureProperties.Append(new P.NonVisualDrawingProperties
        {
            Name = "My Shape",
            Id = (uint)tree.ChildElements.Count - 1
        });

        var nonVisualPictureDrawingProperties = new P.NonVisualPictureDrawingProperties();
        nonVisualPictureDrawingProperties.Append(new D.PictureLocks
        {
            NoChangeAspect = true
        });
        picture.NonVisualPictureProperties.Append(nonVisualPictureDrawingProperties);
        picture.NonVisualPictureProperties.Append(new P.ApplicationNonVisualDrawingProperties());

        var blipFill = new P.BlipFill();
        var blip1 = new D.Blip
        {
            Embed = slidePart.GetIdOfPart(part)
        };
        var blipExtensionList1 = new D.BlipExtensionList();
        var blipExtension1 = new D.BlipExtension
        {
            Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"
        };
        var useLocalDpi1 = new UseLocalDpi
        {
            Val = false
        };
        useLocalDpi1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");
        blipExtension1.Append(useLocalDpi1);
        blipExtensionList1.Append(blipExtension1);
        blip1.Append(blipExtensionList1);
        var stretch = new D.Stretch();
        stretch.Append(new D.FillRectangle());
        blipFill.Append(blip1);
        blipFill.Append(stretch);
        picture.Append(blipFill);

        picture.ShapeProperties = new P.ShapeProperties();
        picture.ShapeProperties.Transform2D = new D.Transform2D();
        picture.ShapeProperties.Transform2D.Append(new D.Offset
        {
            X = 0,
            Y = 0
        });
        picture.ShapeProperties.Transform2D.Append(new D.Extents
        {
            Cx = 1000000,
            Cy = 1000000
        });
        picture.ShapeProperties.Append(new D.PresetGeometry
        {
            Preset = D.ShapeTypeValues.Rectangle
        });

        tree.Append(picture);
    }

    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix
    // TODO:  Fix

    // private static void InsertSlide(PresentationPart pPart, string layoutName, UInt32 slideId)
    // {
    //     P.Slide slide = new P.Slide(new P.CommonSlideData(new P.ShapeTree()));
    //     SlidePart sPart = pPart.AddNewPart<SlidePart>();
    //     slide.Save(sPart);
    //
    //     SlideMasterPart smPart = pPart.SlideMasterParts.First();
    //     SlideLayoutPart slPart =
    //         smPart.SlideLayoutParts.Single(part => part.SlideLayout.CommonSlideData.Name == layoutName);
    //
    //     //Add the layout part to the new slide from the slide master
    //     sPart.AddPart<SlideLayoutPart>(slPart);
    //     sPart.Slide.CommonSlideData = (P.CommonSlideData)smPart.SlideLayoutParts
    //         .Single(part => part.SlideLayout.CommonSlideData.Name == layoutName).SlideLayout.CommonSlideData.Clone();
    //
    //     using (Stream stream = slPart.GetStream())
    //     {
    //         sPart.SlideLayoutPart.FeedData(stream);
    //     }
    //
    //     //UPDATED: Copy the images from the slide master layout to the new slide
    //     foreach (ImagePart iPart in slPart.ImageParts)
    //     {
    //         ImagePart newImagePart = sPart.AddImagePart(iPart.ContentType, slPart.GetIdOfPart(iPart));
    //         newImagePart.FeedData(iPart.GetStream());
    //     }
    //
    //     P.SlideId newSlideId = pPart.Presentation.SlideIdList.AppendChild<P.SlideId>(new P.SlideId());
    //     newSlideId.Id = slideId;
    //     newSlideId.RelationshipId = pPart.GetIdOfPart(sPart);
    // }
    //
    // public static void InsertNewSlide(PresentationPart presentationPart, string layoutName, int? position = null)
    // {
    //     P.Slide slide = new P.Slide();
    //     SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();
    //     slide.Save(slidePart);
    //
    //     SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.FirstOrDefault();
    //     SlideLayoutPart slideLayoutPart = slideMasterPart.GetSlideLayoutPartByLayoutName(layoutName);
    //
    //     slidePart.AddPart(slideLayoutPart, slideMasterPart.GetIdOfPart(slideLayoutPart));
    //     slidePart.Slide.CommonSlideData = (P.CommonSlideData)slideLayoutPart.SlideLayout.CommonSlideData.Clone();
    //
    //     string id = slideMasterPart.GetIdOfPart(slideLayoutPart);
    //     slidePart.CloneSlideLayout(slideLayoutPart, id);
    //
    //     slideMasterPart.AddPart(slideLayoutPart, id);
    //     presentationPart.SetSlideID(slidePart, position);
    // }
    //
    // public static void SetSlideID(PresentationPart presentationPart, SlidePart slidePart, int? position = null)
    // {
    //     P.SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;
    //     if (slideIdList == null)
    //     {
    //         slideIdList = new P.SlideIdList();
    //         presentationPart.Presentation.SlideIdList = slideIdList;
    //     }
    //
    //     if (position != null && position > slideIdList.Count())
    //         throw new InvalidOperationException(
    //             $"Unable to set slide to position '{position}'. There are only '{slideIdList.Count()}' slides.");
    //
    //     uint newId = slideIdList.ChildElements.Count() == 0 ? 256 : slideIdList.GetMaxSlideId() + 1;
    //     if (position == null)
    //     {
    //         var newSlideId = slideIdList.AppendChild(new P.SlideId());
    //         newSlideId.Id = newId;
    //         newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);
    //     }
    //     else
    //     {
    //         P.SlideId nextSlideId = (P.SlideId)slideIdList.ChildElements[position.Value - 1];
    //         var newSlideId = slideIdList.InsertBefore(new P.SlideId(), nextSlideId);
    //         newSlideId.Id = newId;
    //         newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);
    //     }
    // }
    //
    // public static uint GetMaxSlideId(P.SlideIdList slideIdList)
    // {
    //     uint maxSlideId = 0;
    //     if (slideIdList.ChildElements.Count() > 0)
    //         maxSlideId = slideIdList.ChildElements
    //             .Cast<P.SlideId>()
    //             .Max(x => x.Id.Value);
    //     return maxSlideId;
    // }
    //
    // public static SlideLayoutPart GetSlideLayoutPartByLayoutName(SlideMasterPart slideMasterPart,
    //     string layoutName)
    // {
    //     return slideMasterPart.SlideLayoutParts.SingleOrDefault
    //         (sl => sl.SlideLayout.CommonSlideData.Name.Value.Equals(layoutName, StringComparison.OrdinalIgnoreCase));
    // }
    //
    // public static void CloneSlideLayout(SlidePart newSlidePart, SlideLayoutPart slPart, string id)
    // {
    //     /* ensure we added the rel ID to this part */
    //     newSlidePart.AddPart(slPart, id);
    //     using (Stream stream = slPart.GetStream())
    //     {
    //         newSlidePart.SlideLayoutPart.FeedData(stream);
    //     }
    //
    //     newSlidePart.Slide.CommonSlideData = (P.CommonSlideData)slPart.SlideLayout.CommonSlideData.Clone();
    //
    //     foreach (ImagePart iPart in slPart.ImageParts)
    //         newSlidePart.AddPart(iPart, slPart.GetIdOfPart(iPart));
    // }
}