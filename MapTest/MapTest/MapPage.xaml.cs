//using Xamarin.Forms.Maps;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms;

namespace MapTest
{
    public partial class MapPage : ContentPage
    {
        Xamarin.Forms.GoogleMaps.Map gmap = new Xamarin.Forms.GoogleMaps.Map();
        Polyline poliline = new Polyline();
        public MapPage()
        {
            InitializeComponent();

            poliline.StrokeColor = Color.Red;
            poliline.StrokeWidth = 5f;
            poliline.Tag = "New Route";

            //var poliline = new Polyline();
            //poliline.Positions.Add(new Position(37.797534, -122.401827));
            //poliline.Positions.Add(new Position(37.797510, -122.402060));
            //poliline.Positions.Add(new Position(37.790269, -122.400589));
            //poliline.Positions.Add(new Position(37.790265, -122.400474));
            //poliline.Positions.Add(new Position(37.790228, -122.400391));
            //poliline.Positions.Add(new Position(37.790126, -122.400360));
            //poliline.Positions.Add(new Position(37.789250, -122.401451));
            //poliline.Positions.Add(new Position(37.788440, -122.400396));
            //poliline.Positions.Add(new Position(37.787999, -122.399780));
            //poliline.Positions.Add(new Position(37.786736, -122.398202));
            //poliline.Positions.Add(new Position(37.786345, -122.397722));
            //poliline.Positions.Add(new Position(37.785983, -122.397295));
            //poliline.Positions.Add(new Position(37.785559, -122.396728));
            //poliline.Positions.Add(new Position(37.780624, -122.390541));
            //poliline.Positions.Add(new Position(37.777113, -122.394983));
            //poliline.Positions.Add(new Position(37.776831, -122.394627));

            //poliline.StrokeColor = Color.Blue;
            //poliline.StrokeWidth = 5f;
            //poliline.Tag = "POLYLINE";

            //gmap.Polylines.Add(poliline);
            gmap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));

            gmap.MapClicked += Gmap_MapClicked;

            Content = gmap;

            //CustomMap customMap = new CustomMap()
            //{
            //    MapType = MapType.Street,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};

            //customMap.RouteCoordinates.Add(new Position(37.797534, -122.401827));
            //customMap.RouteCoordinates.Add(new Position(37.797510, -122.402060));
            //customMap.RouteCoordinates.Add(new Position(37.790269, -122.400589));
            //customMap.RouteCoordinates.Add(new Position(37.790265, -122.400474));
            //customMap.RouteCoordinates.Add(new Position(37.790228, -122.400391));
            //customMap.RouteCoordinates.Add(new Position(37.790126, -122.400360));
            //customMap.RouteCoordinates.Add(new Position(37.789250, -122.401451));
            //customMap.RouteCoordinates.Add(new Position(37.788440, -122.400396));
            //customMap.RouteCoordinates.Add(new Position(37.787999, -122.399780));
            //customMap.RouteCoordinates.Add(new Position(37.786736, -122.398202));
            //customMap.RouteCoordinates.Add(new Position(37.786345, -122.397722));
            //customMap.RouteCoordinates.Add(new Position(37.785983, -122.397295));
            //customMap.RouteCoordinates.Add(new Position(37.785559, -122.396728));
            //customMap.RouteCoordinates.Add(new Position(37.780624, -122.390541));
            //customMap.RouteCoordinates.Add(new Position(37.777113, -122.394983));
            //customMap.RouteCoordinates.Add(new Position(37.776831, -122.394627));

            //Pin pin1 = new Pin
            //{
            //    Type = PinType.Place,
            //    Position = new Position(37.79752, -122.40183),
            //    Label = "Pin Here",
            //    Address = "www.google.com"
            //};

            //customMap.Pins.Add(pin1);

            //customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));
            //Content = customMap;
        }

        private void Gmap_MapClicked(object sender, MapClickedEventArgs e)
        {            
            Pin pin = new Pin
            {
                Position = e.Point,
                Label = "HOLA",
                IsDraggable = true
            };

            poliline.Positions.Add(pin.Position);

            gmap.Pins.Add(pin);

            Drawer();                            
        }

        private void Drawer()
        {
            if (poliline.Positions.Count > 1)
            {
                gmap.Polylines.Clear();
                gmap.Polylines.Add(poliline);
                foreach (Pin pin in gmap.Pins)
                {
                    pin.PropertyChanged += Pin_PropertyChanged;
                }
                
            }
        }

        private void Pin_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            poliline.Positions.Clear();
            gmap.Polylines.Clear();
            foreach (Pin pin in gmap.Pins)
            {
                poliline.Positions.Add(pin.Position);
            }
            gmap.Polylines.Add(poliline);
        }
    }
}
