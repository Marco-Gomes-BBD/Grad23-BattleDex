using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Validation;
using BlipFill = DocumentFormat.OpenXml.Presentation.BlipFill;
using ColorMap = DocumentFormat.OpenXml.Presentation.ColorMap;
using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
using NonVisualGroupShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeDrawingProperties;
using NonVisualGroupShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualGroupShapeProperties;
using NonVisualPictureDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureDrawingProperties;
using NonVisualPictureProperties = DocumentFormat.OpenXml.Presentation.NonVisualPictureProperties;
using NonVisualShapeDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeDrawingProperties;
using NonVisualShapeProperties = DocumentFormat.OpenXml.Presentation.NonVisualShapeProperties;
using Picture = DocumentFormat.OpenXml.Presentation.Picture;
using Shape = DocumentFormat.OpenXml.Presentation.Shape;
using ShapeProperties = DocumentFormat.OpenXml.Presentation.ShapeProperties;
using TextBody = DocumentFormat.OpenXml.Presentation.TextBody;
using Transform2D = DocumentFormat.OpenXml.Drawing.Transform2D;
using GroupShapeProperties = DocumentFormat.OpenXml.Presentation.GroupShapeProperties;

namespace Grad23_BattleDex.services;

public class DeckGenerator
{
    public static void CreatePresentation(string templateFile, string resultFilePath,
        string topic, List<string> imagePaths)
    {
        File.Copy(templateFile, resultFilePath, true);

        using (PresentationDocument presentation = PresentationDocument.Open(resultFilePath, true))
        {
            BuildSlides(presentation.PresentationPart, imagePaths);

            OpenXmlValidator validator = new OpenXmlValidator();
            var errors = validator.Validate(presentation.PresentationPart.OpenXmlPackage);

            if (errors.Count() > 0)
            {
                Console.WriteLine("The deck creation process completed but " +
                                  "the created presentation failed to validate.");
                Console.WriteLine("There are " + errors.Count() +
                                  " errors:\r\n");

                // DisplayValidationErrors(errors);
            }
            else
            {
                Console.WriteLine("The deck creation process completed and " +
                                  "the created presentation validated with 0 errors.");
            }
        }

        // var presentationDoc = PresentationDocument.Create(resultFilePath, PresentationDocumentType.Presentation);
        // var presentationPart = presentationDoc.AddPresentationPart();
        // presentationPart.Presentation = new Presentation();

        // CreatePresentationParts(presentationPart, imagePaths);
    }

    // private static void AddTopic(PresentationPart presentationPart, string topic)
    // {
    //     Shape textbox = (Shape) presentationPart.SlideParts.First().Slide.CommonSlideData.ShapeTree.LastChild;
    //     if (textbox.InnerText.Contains("PlaceHolder"))
    //     {
    //         textbox = topic;
    //     }
    //
    //     throw new NotImplementedException();
    // }

    private static void CreatePresentationParts(PresentationPart presentationPart, List<string> imagePaths)
    {
        var slideMasterIdList1 = new SlideMasterIdList(new SlideMasterId
            { Id = (UInt32Value)2147483648U, RelationshipId = "rId1" });

        var slideIdList1 = new SlideIdList(new SlideId { Id = (UInt32Value)256U, RelationshipId = "rId2" });
        var slideSize1 = new SlideSize { Cx = 9144000, Cy = 6858000, Type = SlideSizeValues.Screen4x3 };
        var notesSize1 = new NotesSize { Cx = 6858000, Cy = 9144000 };
        var defaultTextStyle1 = new DefaultTextStyle();

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

        BuildSlides(presentationPart, imagePaths);
    }

    private static SlidePart CreateSlidePart(PresentationPart presentationPart)
    {
        var slidePart1 = presentationPart.AddNewPart<SlidePart>("rId2");
        slidePart1.Slide = new Slide(
            new CommonSlideData(
                new ShapeTree(
                    new NonVisualGroupShapeProperties(
                        new NonVisualDrawingProperties { Id = (UInt32Value)1U, Name = "" },
                        new NonVisualGroupShapeDrawingProperties(),
                        new ApplicationNonVisualDrawingProperties()),
                    new GroupShapeProperties(new TransformGroup()),
                    new Shape(
                        new NonVisualShapeProperties(
                            new NonVisualDrawingProperties { Id = (UInt32Value)2U, Name = "Title 1" },
                            new NonVisualShapeDrawingProperties(new ShapeLocks { NoGrouping = true }),
                            new ApplicationNonVisualDrawingProperties(new PlaceholderShape())),
                        new ShapeProperties()))),
            new ColorMapOverride(new MasterColorMapping()));
        return slidePart1;
    }

    private static SlideLayoutPart CreateSlideLayoutPart(SlidePart slidePart1)
    {
        SlideLayoutPart layoutPart = slidePart1.AddNewPart<SlideLayoutPart>("rId1");
        SlideLayout slideLayout = new SlideLayout(
            new CommonSlideData(new ShapeTree(
                new NonVisualGroupShapeProperties(
                    new NonVisualDrawingProperties { Id = (UInt32Value)1U, Name = "" },
                    new NonVisualGroupShapeDrawingProperties(),
                    new ApplicationNonVisualDrawingProperties()),
                new GroupShapeProperties(new TransformGroup()),
                new Shape(
                    new NonVisualShapeProperties(
                        new NonVisualDrawingProperties { Id = (UInt32Value)2U, Name = "" },
                        new NonVisualShapeDrawingProperties(new ShapeLocks { NoGrouping = true }),
                        new ApplicationNonVisualDrawingProperties(new PlaceholderShape())),
                    new ShapeProperties()
                    // new DocumentFormat.OpenXml.Drawing.Pictures.Picture(oiefhwufh)
                ))),
            new ColorMapOverride(new MasterColorMapping())
        );

        layoutPart.SlideLayout = slideLayout;
        return layoutPart;
    }

    private static SlideMasterPart CreateSlideMasterPart(SlideLayoutPart slideLayoutPart1)
    {
        var slideMasterPart1 = slideLayoutPart1.AddNewPart<SlideMasterPart>("rId1");
        var slideMaster = new SlideMaster(
            new CommonSlideData(new ShapeTree(
                new NonVisualGroupShapeProperties(
                    new NonVisualDrawingProperties { Id = (UInt32Value)1U, Name = "" },
                    new NonVisualGroupShapeDrawingProperties(),
                    new ApplicationNonVisualDrawingProperties()),
                new GroupShapeProperties(new TransformGroup()),
                new Shape(
                    new NonVisualShapeProperties(
                        new NonVisualDrawingProperties { Id = (UInt32Value)2U, Name = "Title Placeholder 1" },
                        new NonVisualShapeDrawingProperties(new ShapeLocks { NoGrouping = true }),
                        new ApplicationNonVisualDrawingProperties(new PlaceholderShape
                            { Type = PlaceholderValues.Title })),
                    new ShapeProperties(),
                    new TextBody(
                        new BodyProperties(),
                        new ListStyle(),
                        new Paragraph())))),
            new ColorMap
            {
                Background1 = ColorSchemeIndexValues.Light1, Text1 = ColorSchemeIndexValues.Dark1,
                Background2 = ColorSchemeIndexValues.Light2, Text2 = ColorSchemeIndexValues.Dark2,
                Accent1 = ColorSchemeIndexValues.Accent1, Accent2 = ColorSchemeIndexValues.Accent2,
                Accent3 = ColorSchemeIndexValues.Accent3, Accent4 = ColorSchemeIndexValues.Accent4,
                Accent5 = ColorSchemeIndexValues.Accent5, Accent6 = ColorSchemeIndexValues.Accent6,
                Hyperlink = ColorSchemeIndexValues.Hyperlink,
                FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink
            },
            new SlideLayoutIdList(new SlideLayoutId { Id = (UInt32Value)2147483649U, RelationshipId = "rId1" }),
            new TextStyles(new TitleStyle(), new BodyStyle(), new OtherStyle()));
        slideMasterPart1.SlideMaster = slideMaster;

        return slideMasterPart1;
    }

    private static ThemePart CreateTheme(SlideMasterPart slideMasterPart1)
    {
        var themePart1 = slideMasterPart1.AddNewPart<ThemePart>("rId5");
        var theme1 = new Theme { Name = "Office Theme" };

        var themeElements1 = new ThemeElements(
            new ColorScheme(
                new Dark1Color(new SystemColor { Val = SystemColorValues.WindowText, LastColor = "000000" }),
                new Light1Color(new SystemColor { Val = SystemColorValues.Window, LastColor = "FFFFFF" }),
                new Dark2Color(new RgbColorModelHex { Val = "1F497D" }),
                new Light2Color(new RgbColorModelHex { Val = "EEECE1" }),
                new Accent1Color(new RgbColorModelHex { Val = "4F81BD" }),
                new Accent2Color(new RgbColorModelHex { Val = "C0504D" }),
                new Accent3Color(new RgbColorModelHex { Val = "9BBB59" }),
                new Accent4Color(new RgbColorModelHex { Val = "8064A2" }),
                new Accent5Color(new RgbColorModelHex { Val = "4BACC6" }),
                new Accent6Color(new RgbColorModelHex { Val = "F79646" }),
                new Hyperlink(new RgbColorModelHex { Val = "0000FF" }),
                new FollowedHyperlinkColor(new RgbColorModelHex { Val = "800080" })) { Name = "Office" },
            new FontScheme(
                new MajorFont(
                    new LatinFont { Typeface = "Calibri" },
                    new EastAsianFont { Typeface = "" },
                    new ComplexScriptFont { Typeface = "" }),
                new MinorFont(
                    new LatinFont { Typeface = "Calibri" },
                    new EastAsianFont { Typeface = "" },
                    new ComplexScriptFont { Typeface = "" })) { Name = "Office" },
            new FormatScheme(
                new FillStyleList(
                    new SolidFill(new SchemeColor { Val = SchemeColorValues.PhColor }),
                    new GradientFill(
                        new GradientStopList(
                            new GradientStop(new SchemeColor(new Tint { Val = 50000 },
                                    new SaturationModulation { Val = 300000 }) { Val = SchemeColorValues.PhColor })
                                { Position = 0 },
                            new GradientStop(new SchemeColor(new Tint { Val = 37000 },
                                    new SaturationModulation { Val = 300000 }) { Val = SchemeColorValues.PhColor })
                                { Position = 35000 },
                            new GradientStop(new SchemeColor(new Tint { Val = 15000 },
                                    new SaturationModulation { Val = 350000 }) { Val = SchemeColorValues.PhColor })
                                { Position = 100000 }
                        ),
                        new LinearGradientFill { Angle = 16200000, Scaled = true }),
                    new NoFill(),
                    new PatternFill(),
                    new GroupFill()),
                new LineStyleList(
                    new Outline(
                        new SolidFill(
                            new SchemeColor(
                                new Shade { Val = 95000 },
                                new SaturationModulation { Val = 105000 }) { Val = SchemeColorValues.PhColor }),
                        new PresetDash { Val = PresetLineDashValues.Solid })
                    {
                        Width = 9525,
                        CapType = LineCapValues.Flat,
                        CompoundLineType = CompoundLineValues.Single,
                        Alignment = PenAlignmentValues.Center
                    },
                    new Outline(
                        new SolidFill(
                            new SchemeColor(
                                new Shade { Val = 95000 },
                                new SaturationModulation { Val = 105000 }) { Val = SchemeColorValues.PhColor }),
                        new PresetDash { Val = PresetLineDashValues.Solid })
                    {
                        Width = 9525,
                        CapType = LineCapValues.Flat,
                        CompoundLineType = CompoundLineValues.Single,
                        Alignment = PenAlignmentValues.Center
                    },
                    new Outline(
                        new SolidFill(
                            new SchemeColor(
                                new Shade { Val = 95000 },
                                new SaturationModulation { Val = 105000 }) { Val = SchemeColorValues.PhColor }),
                        new PresetDash { Val = PresetLineDashValues.Solid })
                    {
                        Width = 9525,
                        CapType = LineCapValues.Flat,
                        CompoundLineType = CompoundLineValues.Single,
                        Alignment = PenAlignmentValues.Center
                    }),
                new EffectStyleList(
                    new EffectStyle(
                        new EffectList(
                            new OuterShadow(
                                new RgbColorModelHex(
                                    new Alpha { Val = 38000 }) { Val = "000000" })
                            {
                                BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false
                            })),
                    new EffectStyle(
                        new EffectList(
                            new OuterShadow(
                                new RgbColorModelHex(
                                    new Alpha { Val = 38000 }) { Val = "000000" })
                            {
                                BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false
                            })),
                    new EffectStyle(
                        new EffectList(
                            new OuterShadow(
                                new RgbColorModelHex(
                                    new Alpha { Val = 38000 }) { Val = "000000" })
                            {
                                BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false
                            }))),
                new BackgroundFillStyleList(
                    new SolidFill(new SchemeColor { Val = SchemeColorValues.PhColor }),
                    new GradientFill(
                        new GradientStopList(
                            new GradientStop(
                                    new SchemeColor(new Tint { Val = 50000 },
                                            new SaturationModulation { Val = 300000 })
                                        { Val = SchemeColorValues.PhColor })
                                { Position = 0 },
                            new GradientStop(
                                    new SchemeColor(new Tint { Val = 50000 },
                                            new SaturationModulation { Val = 300000 })
                                        { Val = SchemeColorValues.PhColor })
                                { Position = 0 },
                            new GradientStop(
                                    new SchemeColor(new Tint { Val = 50000 },
                                            new SaturationModulation { Val = 300000 })
                                        { Val = SchemeColorValues.PhColor })
                                { Position = 0 }),
                        new LinearGradientFill { Angle = 16200000, Scaled = true }),
                    new GradientFill(
                        new GradientStopList(
                            new GradientStop(
                                    new SchemeColor(new Tint { Val = 50000 },
                                            new SaturationModulation { Val = 300000 })
                                        { Val = SchemeColorValues.PhColor })
                                { Position = 0 },
                            new GradientStop(
                                    new SchemeColor(new Tint { Val = 50000 },
                                            new SaturationModulation { Val = 300000 })
                                        { Val = SchemeColorValues.PhColor })
                                { Position = 0 }),
                        new LinearGradientFill { Angle = 16200000, Scaled = true }))) { Name = "Office" });

        theme1.Append(themeElements1);
        theme1.Append(new ObjectDefaults());
        theme1.Append(new ExtraColorSchemeList());

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