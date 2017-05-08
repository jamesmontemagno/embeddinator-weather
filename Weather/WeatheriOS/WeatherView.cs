using System;
using UIKit;
using CoreLocation;

public class WeatherView : UIView
{
	UITextField cityField, stateField;
	UILabel info;
	UIButton getWeatherButton, getLocationButton;
	CLLocationManager locationManager;
	CLGeocoder coder;
	public WeatherView ()
	{
		BackgroundColor = UIColor.LightGray;

		nfloat h = 31.0f;
		nfloat w = Bounds.Width;

		cityField = new UITextField {
			Placeholder = "City",
			BorderStyle = UITextBorderStyle.RoundedRect,
			Frame = new CoreGraphics.CGRect (40, 32, w - 40, h),
			AutoresizingMask = UIViewAutoresizing.FlexibleWidth
		};

		stateField = new UITextField {
			Placeholder = "State Code",
			BorderStyle = UITextBorderStyle.RoundedRect,
			Frame = new CoreGraphics.CGRect (40, 64, w - 40, h),
			SecureTextEntry = false,
			AutoresizingMask = UIViewAutoresizing.FlexibleWidth
		};

		info = new UILabel {

			Frame = new CoreGraphics.CGRect (40, 96, w - 40, h),
			AutoresizingMask = UIViewAutoresizing.FlexibleWidth
		};

		getWeatherButton = UIButton.FromType (UIButtonType.RoundedRect);
		getWeatherButton.Frame = new CoreGraphics.CGRect (40, 150, w - 40, 44);
		getWeatherButton.SetTitle ("Get Weather", UIControlState.Normal);
		getWeatherButton.Layer.CornerRadius = 5f;
		getWeatherButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

		getWeatherButton.TouchUpInside += delegate {
			var weather = new XAMWeatherFetcher (cityField.Text, stateField.Text);
			getWeatherButton.Enabled = false;

			var result = weather.GetWeather ();
			info.Text = result.Temp + " " + result.Text;

			getWeatherButton.Enabled = true;

		};

		getLocationButton = UIButton.FromType (UIButtonType.RoundedRect);
		getLocationButton.Frame = new CoreGraphics.CGRect (40, 190, w - 40, 44);
		getLocationButton.SetTitle ("Get Location", UIControlState.Normal);
		getLocationButton.Layer.CornerRadius = 5f;
		getLocationButton.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

		getLocationButton.TouchUpInside += delegate {
			if (locationManager != null)
				return;

			locationManager = new CLLocationManager ();
			locationManager.RequestWhenInUseAuthorization ();
			locationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => {
				var l = e.Locations [0].Coordinate;

				coder = new CLGeocoder ();
				coder.ReverseGeocodeLocation (new CLLocation (l.Latitude, l.Longitude), (placemarks, error) => {
					var weather = new XAMWeatherFetcher (placemarks [0].Locality, placemarks [0].AdministrativeArea);
					getWeatherButton.Enabled = false;
					var result = weather.GetWeather ();
					info.Text = result.Temp + "°F " + result.Text + "Lat/Lng = " + l.Latitude + ", " + l.Longitude;

					getWeatherButton.Enabled = true;

				});
			};

			locationManager.StartUpdatingLocation ();
		};

		AddSubviews (new UIView [] { cityField, stateField, info, getWeatherButton, getLocationButton });
	}
}

