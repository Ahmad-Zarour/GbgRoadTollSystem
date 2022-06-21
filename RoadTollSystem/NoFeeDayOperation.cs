namespace RoadTollSystem
{
    //Skatt tas inte ut helgdag, dag före helgdag eller under juli månad.
    public class NoFeeDayOperation
    {
        public NoFeeDayOperation(IList<DateOnly> holidayData)
        {
            this.holidayData = holidayData;
        }

        private  IList<DateOnly> holidayData;
        readonly DateOnly monthOfJuly = new (2022, 07, 01);


        // check the date if it's  a public holiday
        public bool CheckIfHoliday(DateOnly date)
        {
            return holidayData.Any(x => x == date);
        }

        // check if the date is a day before the public holiday
        public bool CheckIfDayBeforeHoliday(DateOnly date)
        {
            return holidayData.Any(x => x == date.AddDays(1));
        }

        // check the date if it's a weekend, sat , sun 
        public bool CheckIfWeekend(DateOnly date)
        {
            return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
        }

        // Check if date in month of july . july is toll fee free
        public bool CheckIfMonthOfJuly(DateOnly date)
        {

            return date.Month.Equals(monthOfJuly.Month) ;
        }

    }
}
