using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Temperature;


namespace Client.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        this.InputValue = 0;
        this.ConvertedValue = 0;
    }

    [BindProperty]
    public double InputValue { get; set; }
    [BindProperty]
    public string InputUnit { get; set; }

    [BindProperty]
    public double ConvertedValue { get; set; }
    [BindProperty]
    public string ConvertedUnit { get; set; }

    private Conversion.ConversionMode ConversionType;

    private void setConversionType()
    {
        if (InputUnit.Equals("Celcius") && ConvertedUnit.Equals("Fahrenheit"))
        {
            ConversionType = Conversion.ConversionMode.Celsius_to_Fahrenheit;
        }
        else if (InputUnit.Equals("Celcius") && ConvertedUnit.Equals("Kelvin"))
        {
            ConversionType = Conversion.ConversionMode.Celsius_to_Kelvin;
        }
        else if (InputUnit.Equals("Fahrenheit") && ConvertedUnit.Equals("Celcius"))
        {
            ConversionType = Conversion.ConversionMode.Fahrenheit_to_Celsius;
        }
        else if (InputUnit.Equals("Fahrenheit") && ConvertedUnit.Equals("Kelvin"))
        {
            ConversionType = Conversion.ConversionMode.Fahrenheit_to_Celsius;
        }
        else if (InputUnit.Equals("Kelvin") && ConvertedUnit.Equals("Celcius"))
        {
            ConversionType = Conversion.ConversionMode.Fahrenheit_to_Celsius;
        }
        else if (InputUnit.Equals("Kelvin") && ConvertedUnit.Equals("Fahrenheit"))
        {
            ConversionType = Conversion.ConversionMode.Fahrenheit_to_Celsius;
        }
        //     else if ((InputUnit.Equals("Celcius") && ConvertedUnit.Equals("Celcius")) ||
        //   (InputUnit.Equals("Fahrenheit") && ConvertedUnit.Equals("Fahrenheit")) ||
        //   (InputUnit.Equals("Kelvin") && ConvertedUnit.Equals("Kelvin")))
        //     {
        //         return;
        //     }

    }
    public void OnPost()
    {
        setConversionType();
        if (InputUnit.Equals(ConvertedUnit))
        {
            ConvertedValue = InputValue;
        }
        else
        {
            Conversion conversion = new Conversion();
            ConvertedValue = conversion.Convert(ConversionType, InputValue);
        }
    }
}
