using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Resources;

namespace WPFTestHotspotExample
{
   public class VM : INotifyPropertyChanged
   {
      public VM()
      {
         _cursorBitmapSource = Convert( Properties.Resources.dilbert );
      }

      private static BitmapSource Convert( System.Drawing.Bitmap bitmap )
      {
         var bitmapData = bitmap.LockBits(
        new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
        System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

         var bitmapSource = BitmapSource.Create(
        bitmapData.Width, bitmapData.Height,
        bitmap.HorizontalResolution, bitmap.VerticalResolution,
        PixelFormats.Bgr32, null,
        bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

         bitmap.UnlockBits( bitmapData );

         return bitmapSource;
      }

      private BitmapSource _cursorBitmapSource;
      public BitmapSource CursorBitmapSource
      {
         get { return _cursorBitmapSource; }
         set
         {
            if ( _cursorBitmapSource != value )
            {
               _cursorBitmapSource = value;
               PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( nameof( CursorBitmapSource ) ) );
            }
         }
      }

      private double _anchorx;
      public double AnchorX
      {
         get => _anchorx;
         set
         {
            if( _anchorx != value )
            {
               _anchorx = value;
               PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( nameof( AnchorX ) ) );
            }
         }
      }

      private double _anchory;
      public double AnchorY
      {
         get => _anchory;
         set
         {
            if ( _anchory != value )
            {
               _anchory = value;
               PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( nameof( AnchorY ) ) );
            }
         }
      }

      public event PropertyChangedEventHandler PropertyChanged;
   }
}