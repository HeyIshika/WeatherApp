public class LocationKeyModel{
    public string Key { get; set; }

    public string LocalizedName{get;set;}
}

public class CurrentWeather{
    public string City{ get; set; }
    public string CurrentTemperature{get;set; }

    public string FeelsLikeDescription{ get; set; }
}

public class CurrentConditionsDto
{
    public string LocalObservationDateTime{get;set;}
    
}