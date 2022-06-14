
namespace RoadTollSystemTest
{
    public class JsonFileReaderTests
    {
        // testing GetDayFeeDataFromJsonFile method
        [Fact]
        public void GetDayFeeDataFromJsonFile_ReturnValidData()
        {
            var dataFromJsonFile = JsonFileReader.GetDayFeeDataFromJsonFile
                (Path.Combine(Directory.GetCurrentDirectory(), "tollFeeData.json"));
            // data format before serialization to Json file
            var feePerDay = new FeePerDay(9 ,new TimeOnly( 06,00,00, 000),new TimeOnly( 06,29,59,999));
            // take the first data from dataFromJsonFile list
            var firstElement = dataFromJsonFile.First();
         
            Assert.Equal(firstElement.Cost, feePerDay.Cost);
            Assert.Equal(firstElement.StartTime, feePerDay.StartTime);
            Assert.Equal(firstElement.EndTime, feePerDay.EndTime);
        }

        // testing GetHolydaysDataFromJson method 
        [Fact]
        public void GetHolydaysDataFromJson_ReturnValidData()
        {

            var dataFromJsonFile = JsonFileReader.GetHolydaysDataFromJson
                (Path.Combine(Directory.GetCurrentDirectory(), "holydayData.json"));

            IList<DateOnly> holidays = new List<DateOnly> {
                new DateOnly(2022,01,05),
                new DateOnly(2022,01,06),
                new DateOnly(2022,04,18),
                new DateOnly(2022,05,25),
                new DateOnly(2022,05,26),
                new DateOnly(2022,06,06),
                new DateOnly(2022,06,24),
                new DateOnly(2022,11,04),
                new DateOnly(2022,12,26)};

           Assert.Equal(holidays,dataFromJsonFile);
        }

    }
}
