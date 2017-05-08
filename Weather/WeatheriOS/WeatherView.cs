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
		nfloat h = 31.0f;
		nfloat w = Bounds.Width;

		cityField = new UITextField {
			Placeholder = "City",
			BorderStyle = UITextBorderStyle.RoundedRect,
		};

		stateField = new UITextField {
			Placeholder = "State Code",
			BorderStyle = UITextBorderStyle.RoundedRect,
			SecureTextEntry = false,
		};

		info = new UILabel ();

		getWeatherButton = UIButton.FromType (UIButtonType.RoundedRect);
		getWeatherButton.SetTitle ("Get Weather", UIControlState.Normal);
		getWeatherButton.Layer.CornerRadius = 5f;

		getWeatherButton.TouchUpInside += delegate {
			var weather = new XAMWeatherFetcher (cityField.Text, stateField.Text);
			getWeatherButton.Enabled = false;

			var result = weather.GetWeather ();
			info.Text = result.Temp + " " + result.Text;

			getWeatherButton.Enabled = true;
		};

		getLocationButton = UIButton.FromType (UIButtonType.RoundedRect);
		getLocationButton.SetTitle ("Get Location", UIControlState.Normal);
		getLocationButton.Layer.CornerRadius = 5f;

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

		// Stack views make it easier to handle auto layout
		var mainStackView = new UIStackView {
			TranslatesAutoresizingMaskIntoConstraints = false,
			Axis = UILayoutConstraintAxis.Vertical,
			Spacing = 8
		};
		AddSubview (mainStackView);

		// Constaints for the stack view
		mainStackView.TopAnchor.ConstraintEqualTo (LayoutMarginsGuide.TopAnchor, 20).Active = true;
		mainStackView.LeadingAnchor.ConstraintEqualTo (LayoutMarginsGuide.LeadingAnchor).Active = true;
		mainStackView.TrailingAnchor.ConstraintEqualTo (LayoutMarginsGuide.TrailingAnchor).Active = true;

		// Add the labels to a new stack view to align them horizontally
		var labelsStackView = new UIStackView {
			Axis = UILayoutConstraintAxis.Horizontal,
			Distribution = UIStackViewDistribution.FillEqually
		};
		labelsStackView.AddArrangedSubview (getWeatherButton);
		labelsStackView.AddArrangedSubview (getLocationButton);

		// Add all the UI elements to the main stack view
		mainStackView.AddArrangedSubview (cityField);
		mainStackView.AddArrangedSubview (stateField);
		mainStackView.AddArrangedSubview (labelsStackView);
		mainStackView.AddArrangedSubview (info);
	}
}

