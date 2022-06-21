namespace GbgRoadTollSystemTest
{
    public class TollCalculatorTests
    {
        public  VehicleRouls vehicleRouls = new();
        public  NoFeeDayOperation? noFeeDayOperation;
        public FeePerDayOperation? feePerDayOperation;
        IList<DateOnly> holydaysData = JsonFileReader.GetHolidaysDataFromJson
               (Path.Combine(Directory.GetCurrentDirectory(), "holidayData.json"));
        IList<FeePerDay> FeeData = JsonFileReader.GetDayFeeDataFromJsonFile
               (Path.Combine(Directory.GetCurrentDirectory(), "tollFeeData.json"));
        

        [Fact]
        public void GetTollFee_shouldCalculateFeeCorrectly()
        {
            noFeeDayOperation = new NoFeeDayOperation(holydaysData);
            feePerDayOperation = new FeePerDayOperation(FeeData);
            TollCalculator tollCalculator = new TollCalculator(holydaysData, FeeData);

            // traffic on working day
            var carTraffic = new DateTime[]
                    {
                        new DateTime(2022, 6, 10, 6, 0, 25), // 06:00–06:29 => 9 kr
                        new DateTime(2022, 6, 10, 9, 15, 25),// 08:30–14:59 => 9 kr
                        new DateTime(2022, 6, 10, 11, 25, 5),// 08:30–14:59 => 9 kr
                        new DateTime(2022, 6, 10, 15, 20, 0),// 15:00–15:29 => 16 kr Total expected Fee = 43 kr
                       
                    };
            var tollFee = tollCalculator.GetTollFee(VehicleCategory.Car,carTraffic);
            //As expected 43 kr
            Assert.Equal(43, tollFee);

            // traffic on holiday
            var carTrafficInHoliday = new DateTime[] // 18 april  Annandag påsk
                    {
                        new DateTime(2022, 4, 18, 6, 0, 25), // 06:00–06:29 => 9 kr
                        new DateTime(2022, 4, 18, 9, 15, 25),// 08:30–14:59 => 9 kr
                        new DateTime(2022, 4, 18, 11, 25, 5),// 08:30–14:59 => 9 kr
                        new DateTime(2022, 4, 18, 15, 20, 0),// 15:00–15:29 => 16 kr Total expected Fee = 43 kr
                       
                    };
            var tollFeeInHoliday = tollCalculator.GetTollFee(VehicleCategory.Car, carTrafficInHoliday);
            // 18 april  Annandag påsk holiyday
            Assert.Equal(0, tollFeeInHoliday);

            // rush traffic 
            var maxCarTraffic = new DateTime[]
                    {
                        new DateTime(2022, 5, 10, 6, 0, 25), // 06:00–06:29 => 9 kr
                        new DateTime(2022, 5, 10, 7, 10, 25), // 07:00–07:59 => 22 kr
                        new DateTime(2022, 5, 10, 9, 5, 25),// 08:30–14:59 => 9 kr
                        new DateTime(2022, 5, 10, 10, 10, 50),// 08:30–14:59 => 9 kr
                        new DateTime(2022, 5, 10, 11, 25, 5),// 08:30–14:59 => 9 kr
                        new DateTime(2022, 5, 10, 15, 20, 0),// 15:00–15:29 => 16 kr 
                        new DateTime(2022, 5, 10, 15, 30, 0),// 15:00–15:29 => Same hour => 0 kr
                        new DateTime(2022, 5, 10, 17, 20, 0),// 17:00–17:59 => 16 kr Total expected = 90 kr
                       
                    };
            var multiEntryTollFee = tollCalculator.GetTollFee(VehicleCategory.Car, maxCarTraffic);
            // max fee per day 60 kr
            Assert.Equal(60, multiEntryTollFee);


            // trafic on weekend 

            var carTrafficWeekend = new DateTime[] 
                   {
                        new DateTime(2022, 4, 2, 6, 0, 25), // 06:00–06:29 => 9 kr
                        new DateTime(2022, 4, 2, 9, 15, 25),// 08:30–14:59 => 9 kr
                        new DateTime(2022, 4, 2, 11, 25, 5),// 08:30–14:59 => 9 kr
                        new DateTime(2022, 4, 2, 15, 20, 0),// 15:00–15:29 => 16 kr Total expected Fee = 43 kr

                   };
            var tollFeeWeekend = tollCalculator.GetTollFee(VehicleCategory.Car, carTrafficInHoliday);
            // 6 of april saturday
            Assert.Equal(0, tollFeeWeekend);
        }
    }
}