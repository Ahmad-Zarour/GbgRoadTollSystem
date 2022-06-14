

namespace RoadTollSystemTest
{
 
    public class FeePerDayOperationTests
    {
        IList<FeePerDay> dataFromJsonFile = JsonFileReader.GetDayFeeDataFromJsonFile
                (Path.Combine(Directory.GetCurrentDirectory(), "tollFeeData.json"));
        FeePerDayOperation? feePerDayOperation ;

        [Fact]
        public void GetFeeInCertainTime_ReturnValidValue()
        {
            //Actual times for congestion tax in Gothenburg
            var firstTime = new  TimeOnly(06, 00, 00, 000);
            var secondTimes = new  TimeOnly(07, 10, 10, 000);
            var thirdTimes = new  TimeOnly(15, 05, 55, 000);
            feePerDayOperation = new FeePerDayOperation(dataFromJsonFile);

            // using GetFeeInCertainTime method
            var firstResult = feePerDayOperation.GetFeeInCertainTime(firstTime);
            var secondResult2 = feePerDayOperation.GetFeeInCertainTime(secondTimes);
            var thirdResult3 = feePerDayOperation.GetFeeInCertainTime(thirdTimes);

            //Actual fee in certain time
            double feeFirstTime = 9;
            double feeSecondTimes = 22;
            double feeThirdTime = 16;

            Assert.Equal(feeFirstTime, firstResult);
            Assert.Equal(feeSecondTimes, secondResult2);
            Assert.Equal(feeThirdTime, thirdResult3);


        }

        [Fact]
        public void SortGateEntryInOneHour_ReturnValidValue()
        {

            var carTraffic = new List<DateTime>{
            new DateTime(2022, 06, 10, 06, 00, 25,00),
            new DateTime(2022, 06, 10, 06, 15, 55,00),
            new DateTime(2022, 06, 10, 08, 15, 05,00),
            new DateTime(2022, 06, 10, 08, 35, 15,00)};

            feePerDayOperation = new FeePerDayOperation(dataFromJsonFile);
            // group data by time span 1 hour
            var sortedData =  feePerDayOperation.SortGateEntryInOneHour(new List<DateTime>(carTraffic), TimeSpan.FromHours(1));
            var totalElement = sortedData.Count();
            var firstHour = sortedData.First();
            var secondHour = sortedData.ElementAt(1);


            // test how many hours in carTraffic list , expected 2 hour == 2 element DateTime[] in the list
            Assert.Equal(2, totalElement);
            // test the first and second element in carTraffic list , first hour 6 o'clock , second hour 8 o'clock, 
            Assert.True(firstHour[0].Hour  == 06);
            Assert.True(firstHour[1].Hour  == 06);
            Assert.True(secondHour[1].Hour  == 08);
            Assert.True(secondHour[1].Hour  == 08);

        }

        [Fact]
        public void SumTotalFee_ReturnValidFee()
        {
            // 15:00–15:29	16 kr
            // 15:30–16:59 22 kr
            var carTraffic = new  DateTime[]{
            new DateTime(2022, 06, 10, 15, 15, 05,00),
            new DateTime(2022, 06, 10, 15, 35, 25,00),
            new DateTime(2022, 06, 10, 15, 45, 45,00)};

            feePerDayOperation = new FeePerDayOperation(dataFromJsonFile);
            // group data by time span 1 hour
            var data = feePerDayOperation.SumTotalFee(carTraffic);
            // 22kr is the highest fee in 15 o'clock period
            Assert.Equal(22, data);


        }

    }
}
