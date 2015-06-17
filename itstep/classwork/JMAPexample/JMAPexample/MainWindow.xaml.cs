using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace JMAPexample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Map.MapProvider = GMapProviders.OpenStreetMap;
            Map.Position = new PointLatLng(32, 20);
            Map.MinZoom = 0;
            Map.MaxZoom = 24;
            Map.Zoom = 9;

            Map.DragButton = MouseButton.Left;
            GMapMarker marker = new GMapMarker(new PointLatLng(32, 20));
            marker.
            
            Map.Markers.Add(new GMapMarker());

        }

    }
}
