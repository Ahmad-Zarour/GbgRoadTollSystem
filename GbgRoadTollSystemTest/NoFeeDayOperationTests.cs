using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadTollSystemTest
{
    public class NoFeeDayOperationTests
    {
        IList<DateOnly> dataFromJsonFile = JsonFileReader.GetHolydaysDataFromJson
                (Path.Combine(Directory.GetCurrentDirectory(), "holydayData.json"));
        NoFeeDayOperation? noFeeDayOperation;


        // test CheckIfHoliday method , return true if date is holiday day
        [Fact]
        public void CheckIfHoliday_ReturnTrueIFDateIsHoliday()
        {
            noFeeDayOperation = new NoFeeDayOperation(dataFromJsonFile);

            DateOnly nationalDayDate = new DateOnly(2022,6,6);
            DateOnly allHelgonaAftonDate = new DateOnly(2022,11,4);
            DateOnly WorkingDayDate = new DateOnly(2022,3,3);

            Assert.True(noFeeDayOperation.CheckIfHoliday(nationalDayDate));
            Assert.True(noFeeDayOperation.CheckIfHoliday(allHelgonaAftonDate));
            Assert.False(noFeeDayOperation.CheckIfHoliday(WorkingDayDate));

        }

        // test CheckIfWeekend method , return true if date is Weekend
        [Fact]
        public void CheckIfWeekend_ReturnTureForSaturdayAndSunday()
        {
            noFeeDayOperation = new NoFeeDayOperation(dataFromJsonFile);

            DateOnly saturdayDate = new DateOnly(2022, 4, 30);
            DateOnly sundayDate = new DateOnly(2022, 5, 1);
            DateOnly tuesdayDate = new DateOnly(2022, 9, 20);

            Assert.True(noFeeDayOperation.CheckIfWeekend(saturdayDate));
            Assert.True(noFeeDayOperation.CheckIfWeekend(sundayDate));
            Assert.False(noFeeDayOperation.CheckIfWeekend(tuesdayDate));

        }

        // test CheckIfMonthOfJuly method if date in month of july
        [Fact]
        public void CheckIfMonthOfJuly_ReturnTureIfDateInJuly()
        {
            noFeeDayOperation = new NoFeeDayOperation(dataFromJsonFile);

            DateOnly julayDate = new DateOnly(2022, 7, 10);
            DateOnly augustDate = new DateOnly(2022, 8, 1);
          
            Assert.True(noFeeDayOperation.CheckIfWeekend(julayDate));
            Assert.False(noFeeDayOperation.CheckIfWeekend(augustDate));

        }

    }
}
