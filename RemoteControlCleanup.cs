using Microsoft.VisualStudio.TestPlatform.ObjectModel;

public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;
    public RemoteControlCar() =>
        this.Telemetry = new RemoteControlCarTelemetry(this);
    public RemoteControlCarTelemetry Telemetry { get; private set; }
    public class RemoteControlCarTelemetry
    {
        public RemoteControlCarTelemetry(RemoteControlCar remoteControlCar) =>
            this.remoteControlCar = remoteControlCar;

        RemoteControlCar remoteControlCar;
        public void Calibrate(){ }

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName) => remoteControlCar.SetSponsor(sponsorName);
        
        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            remoteControlCar.SetSpeed(new Speed(amount, speedUnits));
        }
    }


    public string GetSpeed() => currentSpeed.ToString();

    public void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;
    private void SetSpeed(Speed speed) => currentSpeed = speed;
    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }
    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
}




