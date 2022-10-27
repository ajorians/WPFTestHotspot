using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace WPFTestHotspotExample
{
   public class CursorHotspotAttachedBehavior : Behavior<Canvas>
   {
      private bool _mouseDown = default;
      protected override void OnAttached()
      {
         AssociatedObject.MouseDown += OnMouseDown;
         AssociatedObject.MouseUp += OnMouseUp;
         AssociatedObject.MouseMove += OnMouseMove;
      }

      public static readonly DependencyProperty AnchorXProperty =
         DependencyProperty.Register( nameof( AnchorX ),
                                      typeof( double ),
                                      typeof( CursorHotspotAttachedBehavior ) );
      public double AnchorX
      {
         get => (int)GetValue( AnchorXProperty );
         set => SetValue( AnchorXProperty, value );
      }

      public static readonly DependencyProperty AnchorYProperty =
         DependencyProperty.Register( nameof( AnchorY ),
                                      typeof( double ),
                                      typeof( CursorHotspotAttachedBehavior ) );
      public double AnchorY
      {
         get => (int)GetValue( AnchorYProperty );
         set => SetValue( AnchorYProperty, value );
      }

      private void OnMouseDown( object sender, System.Windows.Input.MouseButtonEventArgs e )
      {
         if ( !AssociatedObject.CaptureMouse() )
            return;

         _mouseDown = true;

         var pos = e.GetPosition( AssociatedObject );
         AnchorX = pos.X;
         AnchorY = pos.Y;
      }

      private void OnMouseUp( object sender, System.Windows.Input.MouseButtonEventArgs e )
      {
         if ( !_mouseDown )
            return;

         _mouseDown = false;

         AssociatedObject.ReleaseMouseCapture();

         var pos = e.GetPosition( AssociatedObject );
         AnchorX = pos.X;
         AnchorY = pos.Y;
      }

      private void OnMouseMove( object sender, System.Windows.Input.MouseEventArgs e )
      {
         if ( !_mouseDown )
            return;

         var pos = e.GetPosition( AssociatedObject );
         AnchorX = pos.X;
         AnchorY = pos.Y;
      }
   }
}
