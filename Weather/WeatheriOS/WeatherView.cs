using System;
using UIKit;
using CoreLocation;
using System.Threading.Tasks;

public class WeatherView : UIView
{
	UITextField cityField, stateField;
	UILabel info, latLong;
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
        latLong = new UILabel();

		getWeatherButton = UIButton.FromType (UIButtonType.RoundedRect);
		getWeatherButton.SetTitle ("Get Weather", UIControlState.Normal);
		getWeatherButton.Layer.CornerRadius = 5f;

		getWeatherButton.TouchUpInside += delegate {
            
            getWeatherButton.Enabled = false;


            var weather = new XAMWeatherFetcher(cityField.Text, stateField.Text);
            var result = weather.GetWeather();


            info.Text = result.Temp + " " + result.Text;

            getWeatherButton.Enabled = true;
		};

		getLocationButton = UIButton.FromType (UIButtonType.RoundedRect);
		getLocationButton.SetTitle ("Get Location", UIControlState.Normal);
		getLocationButton.Layer.CornerRadius = 5f;

		getLocationButton.TouchUpInside += delegate {
			if (locationManager == null)
            {
				locationManager = new CLLocationManager();
				locationManager.RequestWhenInUseAuthorization();
                locationManager.LocationsUpdated += LocationManager_LocationsUpdated;
            }
            getWeatherButton.Enabled = false;
            getLocationButton.Enabled = false;
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
        mainStackView.AddArrangedSubview(latLong);
	}

    void LocationManager_LocationsUpdated(object sender, CLLocationsUpdatedEventArgs e)
    {
        locationManager.StopUpdatingLocation();
		var l = e.Locations[0].Coordinate;


		coder = new CLGeocoder();
		coder.ReverseGeocodeLocation(new CLLocation(l.Latitude, l.Longitude), (placemarks, error) =>
		{

			var city = placemarks[0].Locality;
			var state = placemarks[0].AdministrativeArea;
			var weather = new XAMWeatherFetcher(city, state);
			
			var result = weather.GetWeather();

            InvokeOnMainThread(()=>
            {
    			info.Text = result.Temp + "°F " + result.Text;
    			latLong.Text = l.Latitude + ", " + l.Longitude;
    			cityField.Text = result.City;
    			stateField.Text = result.State;

				getWeatherButton.Enabled = true;
				getLocationButton.Enabled = true;
            });

		});
		     
    }
}

