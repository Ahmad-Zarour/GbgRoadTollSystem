namespace RoadTollSystem
{
    public class NoFeeDayOperation
    {
        public NoFeeDayOperation(IList<DateOnly> holydayData)
        {
            this.holydayData = holydayData;
        }

        private  IList<DateOnly> holydayData;
        readonly DateOnly monthOfJuly = new DateOnly(2022, 07, 01);


        // check the date if it's is a public holiday
        public bool CheckIfHoliday(DateOnly date)
        {
            return holydayData.Any(x => x == date);
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
