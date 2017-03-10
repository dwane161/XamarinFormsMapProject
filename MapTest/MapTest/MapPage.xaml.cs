//using Xamarin.Forms.Maps;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms;
using System.Linq;
using System;

namespace MapTest
{
    public partial class MapPage : ContentPage
    {
        Polyline poliline = new Polyline();
        Geocoder gcoder = new Geocoder();

        public MapPage()
        {
            InitializeComponent();


            poliline.StrokeColor = Color.Red;
            poliline.StrokeWidth = 5f;
            poliline.Tag = "New Route";

            //gmap.Polylines.Add(poliline);
            gmap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(18.482146, -69.939571), Distance.FromMiles(1.0)));
            
            if(gmap.Pins.Count == 0) { 
                gmap.MapLongClicked += Gmap_MapLongClicked;
            }

            btnGuardarRestaurante.Clicked += ButtonClicked;

        }

        void ButtonClicked(object sender, EventArgs args)
        {
            DisplayAlert("Button Clicked", "This Button has been clicked", "OK");
        }

        private async void Gmap_MapLongClicked(object sender, MapLongClickedEventArgs e)
        {
            var aproximatedLocation = await gcoder.GetAddressesForPositionAsync(e.Point);

            string street = aproximatedLocation.First();
            
            Pin pin = new Pin
            {
                Position = e.Point,
                Label = "label",
                IsDraggable = true,
                Address = street
            };

            poliline.Positions.Add(pin.Position);
            gmap.Pins.Add(pin);

        }
        
        private async void Pin_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            poliline.Positions.Clear();
            gmap.Polylines.Clear();
            foreach (Pin pin in gmap.Pins)
            {
                //var aproximatedLocation = await gcoder.GetAddressesForPositionAsync(pin.Position);
                //string street = aproximatedLocation.First();
                //pin.Address = street;

                poliline.Positions.Add(pin.Position);
            }
            gmap.Polylines.Add(poliline);
        }

    }
}
