using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace WeatherAndroid
{
    [Activity(Label = "WeatherActivity")]
    public class WeatherActivity : Activity
    {

        Button buttonGetWeather;
        EditText editTextCity;
        EditText editTextState;
        TextView textViewWeather;
        ProgressBar progressBar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_weather);

            buttonGetWeather = FindViewById<Button>(Resource.Id.button_getweather);
            editTextCity = FindViewById<EditText>(Resource.Id.edittext_city);
            editTextState = FindViewById<EditText>(Resource.Id.edittext_state);
            textViewWeather = FindViewById<TextView>(Resource.Id.textview_weather);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressbar);
            progressBar.Visibility = ViewStates.Invisible;

            buttonGetWeather.Click += ButtonGetWeather_Click;

        }

        bool isBusy;
        private async void ButtonGetWeather_Click(object sender, EventArgs e)
        {
            if (isBusy)
                return;

            isBusy = true;
            try
            {
                var city = editTextCity.Text.Trim();
                var state = editTextState.Text.Trim();
                buttonGetWeather.Enabled = false;

                var weather = new XAMWeatherFetcher(city, state);


                var result = await Task.Run(() => weather.GetWeather());

                textViewWeather.Text = result.Temp + "°F " + result.Text;
                                
            }
            catch (Exception)
            {
                textViewWeather.Text = "Unable to get weather";
            }
            finally
            {
                progressBar.Visibility = ViewStates.Invisible;
                buttonGetWeather.Enabled = true;
                isBusy = true;
            }
            

        }
    }
}