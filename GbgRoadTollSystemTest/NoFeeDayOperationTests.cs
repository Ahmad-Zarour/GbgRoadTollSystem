

namespace RoadTollSystemTest
{
    public class NoFeeDayOperationTests
    {
        IList<DateOnly> dataFromJsonFile = JsonFileReader.GetHolidaysDataFromJson
                (Path.Combine(Directory.GetCurrentDirectory(), "holidayData.json"));
        NoFeeDayOperation? noFeeDayOperation;


        // test CheckIfHoliday method , return true if date is holiday day
        [Fact]
        public void CheckIfHoliday_ReturnTrueIFDateIsHoliday()
        {
            noFeeDayOperation = new NoFeeDayOperation(dataFromJsonFile);

            DateOnly nationalDayDate = new (2022,6,6);
            DateOnly allHelgonaAftonDate = new (2022,11,4);
            DateOnly workingDayDate = new (2022,3,3);

            Assert.True(noFeeDayOperation.CheckIfHoliday(nationalDayDate));
            Assert.True(noFeeDayOperation.CheckIfHoliday(allHelgonaAftonDate));
            Assert.False(noFeeDayOperation.CheckIfHoliday(workingDayDate));

        }


        //CheckDayBeforeHoliday

        // test CheckIfHoliday method , return true if date is holiday day
        [Fact]
        public void CheckDayBeforeHoliday_ReturnTrueIFDateIsHoliday()
        {
            noFeeDayOperation = new NoFeeDayOperation(dataFromJsonFile);

            DateOnly dayBeforeNationalDayDate = new (2022, 6, 5); // nationalDay 6 of june
            DateOnly dayBeforeAllHelgonaAftonDate = new (2022, 11, 3); //allHelgonaAfton Date 11, 4
            DateOnly dayBeforeWorkingDayDate = new (2022, 3, 3); // normal Working Day Date

            Assert.True(noFeeDayOperation.CheckIfDayBeforeHoliday(dayBeforeNationalDayDate));
            Assert.True(noFeeDayOperation.CheckIfDayBeforeHoliday(dayBeforeAllHelgonaAftonDate));
            Assert.False(noFeeDayOperation.CheckIfDayBeforeHoliday(dayBeforeWorkingDayDate));

        }


        // test CheckIfWeekend method , return true if date is Weekend
        [Fact]
        public void CheckIfWeekend_ReturnTureForSaturdayAndSunday()
        {
            noFeeDayOperation = new NoFeeDayOperation(dataFromJsonFile);

            DateOnly saturdayDate = new (2022, 4, 30);
            DateOnly sundayDate = new (2022, 5, 1);
            DateOnly tuesdayDate = new (2022, 9, 20);

            Assert.True(noFeeDayOperation.CheckIfWeekend(saturdayDate));
            Assert.True(noFeeDayOperation.CheckIfWeekend(sundayDate));
            Assert.False(noFeeDayOperation.CheckIfWeekend(tuesdayDate));

        }

        // test CheckIfMonthOfJuly method if date in month of july
        [Fact]
        public void CheckIfMonthOfJuly_ReturnTureIfDateInJuly()
        {
            noFeeDayOperation = new NoFeeDayOperation(dataFromJsonFile);

            DateOnly julayDate = new (2022, 7, 10);
            DateOnly augustDate = new (2022, 8, 1);
          
            Assert.True(noFeeDayOperation.CheckIfWeekend(julayDate));
            Assert.False(noFeeDayOperation.CheckIfWeekend(augustDate));

        }

    }
}
