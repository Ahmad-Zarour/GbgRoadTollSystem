namespace RoadTollSystem
{
    public class VehicleRouls
    {
        public bool IsVehicleFeeFree (VehicleCategory typeOfVehicle)
        {

            switch (typeOfVehicle)
            {
                //toll-free
                case VehicleCategory.EmergencyVehicle:
                case VehicleCategory.Bus:
                case VehicleCategory.DiplomatVehicle:
                case VehicleCategory.Motorcycles:
                case VehicleCategory.MilitaryVehicle:
                    return true;
                case VehicleCategory.Car:
                    {
                        return false;
                    }
                default:
                    // typeOfVehicle not exsist
                    throw new ArgumentOutOfRangeException($"Vehicle type not exist {nameof(typeOfVehicle)}");
            }
        }

    }
}
