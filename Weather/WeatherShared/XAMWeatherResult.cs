using System;

public class XAMWeatherResult
{
	public string Temp { get; private set; }
	public string City { get; private set; }
	public string State { get; private set; }
	public string Text { get; private set; }

	public XAMWeatherResult(string temp, string text, string city, string state)
	{
		Temp = temp;
		Text = text;
        City = city;
        State = state;
	}
}

