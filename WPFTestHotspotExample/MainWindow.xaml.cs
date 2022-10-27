using System.Windows;

namespace WPFTestHotspotExample
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         DataContext = new VM();
      }
   }
}
