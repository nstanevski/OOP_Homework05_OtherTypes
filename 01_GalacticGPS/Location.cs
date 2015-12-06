using System;

struct Location
{
    private double latitude;
    private double longitude;


    public Location(double latitude, double longitude, Planet planet)
        :this()
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
        this.Planet = planet;
    }
    public double Latitude
    {
        get { return this.latitude; }
        private set
        {
            if (value < -90.0 || value > 90.0)
            {
                throw new ArgumentOutOfRangeException("Invalid latitude value (valid range is [-90 90])");
            }
            this.latitude = value;
        }
    }

    public double Longitude
    {
        get { return this.longitude; }
        private set
        {
            if (value < -180.0 || value > 1800.0)
            {
                throw new ArgumentOutOfRangeException("Invalid longitude value (valid range is [-180 180])");
            }
            this.longitude = value;
        }
    }

    public Planet Planet { get; set; }

    public override string ToString()
    {
        return string.Format("{0:f6}, {1:f6} {2}", this.Latitude, this.Longitude, this.Planet);
    }
}
