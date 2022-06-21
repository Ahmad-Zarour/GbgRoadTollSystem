namespace RoadTollSystem
{

    public class TollCalculator
    {

        public readonly VehicleRouls vehicleRouls = new ();
        public readonly NoFeeDayOperation noFeeDayOperation;
        public readonly FeePerDayOperation feePerDayOperation;


        public TollCalculator(IList<DateOnly> noFeeDayData, IList<FeePerDay> feePerDayData)
        {
            this.noFeeDayOperation = new NoFeeDayOperation(noFeeDayData);
            this.feePerDayOperation = new FeePerDayOperation(feePerDayData);
        }

        /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total toll fee for that day
         */

        // Calculate the total toll fee for one day
        public decimal GetTollFee(VehicleCategory vehicle, DateTime[] dates)
        {
            //checked first if the vehicle is toll-free or date is a weekend, a public holiday or in july and return 0 fee
            if (vehicleRouls.IsVehicleFeeFree(vehicle) ||
                noFeeDayOperation.CheckIfWeekend(DateOnly.FromDateTime(dates[0])) ||
                noFeeDayOperation.CheckIfDayBeforeHoliday(DateOnly.FromDateTime(dates[0]))|| 
                noFeeDayOperation.CheckIfHoliday(DateOnly.FromDateTime(dates[0]))|| 
                noFeeDayOperation.CheckIfMonthOfJuly(DateOnly.FromDateTime(dates[0])) )
            {
                return 0;
            }
            // if there is no entry return 0 fee
            else if (dates.Length == 0) return 0;
            //calculate the fee and return it , max fee is 60 kr per day
            else
            {
                //lists of time periods of an hour and its fee
                var entryInOneHour = feePerDayOperation.SortGateEntryInOneHour(new List<DateTime>(dates), TimeSpan.FromHours(1));
                // get total fee
            var totalFee = entryInOneHour.Aggregate<DateTime[], decimal>
                    (0,(present, set) => present + feePerDayOperation.SumTotalFee(set));
                 
            return totalFee > 60 ? 60 : totalFee; // 60kr max fee per day
            }
        }

    }
}