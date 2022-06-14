using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadTollSystemTest
{
    public class IsVehicleFeeFreeTest
    {
        public readonly VehicleRouls vehicleRouls = new();

        // testing IsVehicleFeeFree method 
        [Fact]
        public void IsVehicleFeeFree_ReturnTrueForFeeFreeVehicles()
        {
           
            Assert.True(vehicleRouls.IsVehicleFeeFree(VehicleCategory.EmergencyVehicle));
            Assert.True(vehicleRouls.IsVehicleFeeFree(VehicleCategory.Bus));
            //Vehicale with toll fee
            Assert.False(vehicleRouls.IsVehicleFeeFree(VehicleCategory.Car));
            
        }
    }
}
