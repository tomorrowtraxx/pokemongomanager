using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TTraxx.PokemonGOManager.WPF.Controls
{

    /// <summary>
    /// Represents a control that displays an image with a monotone color.
    /// </summary>
    public class GreyableImage : Image
    {

        private List<BitmapSource> m_availableFrames = new List<BitmapSource>();

        /// <summary>
        /// Initializes the MonotoneImage class.
        /// </summary>
        static GreyableImage()
        {
            // Create a new style, based on Image's default style:
            Style defaultStyle = new Style(typeof(GreyableImage), StyleProperty.DefaultMetadata.DefaultValue as Style);

            // Bind the "IsFullColor" property to the "IsEnabled" property:
            defaultStyle.Setters.Add(new Setter(GreyableImage.IsFullColorProperty, new Binding("IsEnabled") { RelativeSource = RelativeSource.Self }));
            defaultStyle.Seal();
            StyleProperty.OverrideMetadata(typeof(GreyableImage), new FrameworkPropertyMetadata(defaultStyle));
            SourceProperty.OverrideMetadata(typeof(GreyableImage), new FrameworkPropertyMetadata(new PropertyChangedCallback(HandleSourceChanged)));
        }

        private static void HandleSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            GreyableImage img = sender as GreyableImage;
            img.UpdateAvailableFrames();
        }

        private void UpdateAvailableFrames()
        {
            m_availableFrames.Clear();
            BitmapFrame bmFrame = Source as BitmapFrame;

            if ((bmFrame == null)) return;

            BitmapDecoder decoder = bmFrame.Decoder;
            if (decoder != null && decoder.Frames != null && (decoder.Frames.Count > 0))
            {
                var framesInSizeOrder = from frame in decoder.Frames
                                        group frame by new { frameSize = frame.PixelHeight * frame.PixelWidth } into g
                                        orderby g.Key.frameSize
                                        select new { Size = g.Key.frameSize, Frames = g.OrderByDescending(GetFramePixelDepth) };

                m_availableFrames.AddRange(framesInSizeOrder.Select(group => group.Frames.First()));
            }
        }

        private int GetFramePixelDepth(BitmapFrame frame)
        {
            if (frame.Decoder.CodecInfo.ContainerFormat == new Guid("{a3a860c4-338f-4c17-919a-fba4b5628f21}") && frame.Thumbnail != null)
            {
                // Windows Icon format, original pixel depth is in the thumbnail
                return frame.Thumbnail.Format.BitsPerPixel;
            }
            else
            {
                // Other formats, just assume the frame has the correct BPP info
                return frame.Format.BitsPerPixel;
            }

        }

        protected override void OnRender(DrawingContext dc)
        {
            if ((this.Source == null))
            {
                base.OnRender(dc);
                return;
            }

            int predefinedHeight = 48;
            int predefinedWidth = 48;

            // Render the bitmap from source drawing
            int desiredHeight = double.IsNaN(this.RenderSize.Height) ?
                                predefinedHeight :
                                (this.RenderSize.Height > 0 ? (int)this.RenderSize.Height : (double.IsNaN(this.Height) ? predefinedHeight : (int)this.Height));
            int desiredWidth = double.IsNaN(this.RenderSize.Width) ?
                                predefinedWidth :
                                (this.RenderSize.Width > 0 ? (int)this.RenderSize.Width : (double.IsNaN(this.Width) ? predefinedWidth : (int)this.Width));


            double validSize = desiredWidth * desiredHeight;

            // Get the source image that needs to be converted to a monotone image:
            BitmapSource btmSource = this.Source as BitmapSource;
            DrawingImage drawSource = this.Source as DrawingImage;

            if (btmSource == null && drawSource == null)
            {
                base.OnRender(dc);
                return;
            }
            else if (drawSource != null)
            {
                if (desiredHeight <= 0 || desiredWidth <= 0)
                {
                    base.OnRender(dc);
                    return;
                }

                btmSource = new RenderTargetBitmap(desiredWidth, desiredHeight, 96, 96, PixelFormats.Pbgra32);
                DrawingVisual dv = new DrawingVisual();

                using (DrawingContext ctx = dv.RenderOpen())
                {
                    ctx.DrawImage(drawSource, new Rect(new Point(0, 0), new Size(desiredWidth, desiredHeight)));
                }

                ((RenderTargetBitmap)btmSource).Render(dv);
            }
            else
            {
                BitmapSource correctFrame = m_availableFrames.FirstOrDefault(f => (f.PixelWidth == 0 ? 1 : f.PixelWidth) * f.PixelHeight >= validSize);

                if (correctFrame != null) btmSource = correctFrame;

                if (!IsFullColor)
                {
                    // The converted monotone image:
                    // Dim target As BitmapSource = Nothing
                    Color biasColor = (this.BiasColor != null ? this.BiasColor : Colors.White);
                    if ((biasColor == Colors.White))
                    {
                        // If the bias color is white,
                        // convert the image to a grayscale image:
                        FormatConvertedBitmap bitmap = new FormatConvertedBitmap();

                        bitmap.BeginInit();
                        bitmap.DestinationFormat = PixelFormats.Gray32Float;
                        bitmap.Source = btmSource;
                        bitmap.EndInit();

                        dc.PushOpacityMask(new ImageBrush(btmSource));
                        btmSource = bitmap;
                    }

                }

                if (btmSource != null && btmSource.CanFreeze)
                {
                    btmSource.Freeze();
                    dc.DrawImage(btmSource, new Rect(new Point(0, 0), new Size(desiredWidth, desiredHeight)));
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of which the palette will be created.
        ///</summary>
        public Color BiasColor
        {
            get
            {
                return (Color)GetValue(BiasColorProperty);
            }
            set
            {
                SetValue(BiasColorProperty, value);
            }
        }

        public static readonly DependencyProperty BiasColorProperty = DependencyProperty.Register("BiasColor", typeof(Color), typeof(GreyableImage), new FrameworkPropertyMetadata(Colors.White, FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Gets or sets whether to display the image in full color,
        /// or on a single color.
        /// </summary>
        public bool IsFullColor
        {
            get
            {
                return (bool)GetValue(IsFullColorProperty);
            }
            set
            {
                SetValue(IsFullColorProperty, value);
            }
        }

        public static readonly DependencyProperty IsFullColorProperty = DependencyProperty.Register("IsFullColor", typeof(bool), typeof(GreyableImage), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    }

}
