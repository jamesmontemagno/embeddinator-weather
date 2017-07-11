package com.refractored.myweatherandroid;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.*;
import weatherandroid_dll.*;

public class MainActivity extends AppCompatActivity {
    Button button;
    EditText city;
    EditText state;
    TextView weather;
    ProgressBar progressBar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        button = (Button)findViewById(R.id.button_getweather);
        city = (EditText)findViewById(R.id.edittext_city);
        state = (EditText)findViewById(R.id.edittext_state);
        weather = (TextView)findViewById(R.id.textview_weather);
        progressBar = (ProgressBar)findViewById(R.id.progressbar);

        progressBar.setVisibility(View.INVISIBLE);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                XAMWeatherFetcher fetcher = new XAMWeatherFetcher(city.getText().toString(), state.getText().toString());
                XAMWeatherResult result = fetcher.getWeather();
                if (result != null) {
                    weather.setText(result.getTemp() + "°F " +  result.getText());
                } else {
                    weather.setText("An error occurred :(");
                }
            }
        });
    }

    @Override
    protected void onResume() {
        super.onResume();

        //Intent intent = new Intent(this, WeatherActivity.class);
        //startActivity(intent);
    }
}
