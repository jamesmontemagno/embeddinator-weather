using System;

public class XAMWeatherResult
{
	public string Temp { get; private set; }
	public string Text { get; private set; }

	public XAMWeatherResult(string temp, string text)
	{
		Temp = temp;
		Text = text;
	}
}

