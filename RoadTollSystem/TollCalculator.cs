namespace RoadTollSystem
{

    public class TollCalculator
    {

        /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total toll fee for that day
         */
        public readonly VehicleRouls vehicleRouls = new();
        public readonly NoFeeDayOperation noFeeDayOperation;
        public  FeePerDayOperation feePerDayOperation;


        public TollCalculator(IList<DateOnly> noFeeDayData, IList<FeePerDay> feePerDayData)
        {
            this.noFeeDayOperation = new NoFeeDayOperation(noFeeDayData);
            this.feePerDayOperation = new FeePerDayOperation(feePerDayData);
        }


        // Calculate the total toll fee for one day
        public double GetTollFee(VehicleCategory vehicle, DateTime[] dates)
        {
            //checked first if the vehicle is toll-free or date is a weekend, a public holiday or in july and return 0 fee
            if (vehicleRouls.IsVehicleFeeFree(vehicle) ||
                noFeeDayOperation.CheckIfWeekend(DateOnly.FromDateTime(dates[0])) ||
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
            var totalFee = entryInOneHour.Aggregate<DateTime[]?, double>
                    (0,(present, set) => present + feePerDayOperation.SumTotalFee(set));
                 
            return totalFee > 60 ? 60 : totalFee;
            }
        }

        // Method to return list of time period of an hour time span and its fee
        private static IEnumerable<DateTime[]> SortGateEntryInOneHour2(List<DateTime> dates, TimeSpan span)
        {
            var data = new List<DateTime[]>();

            while (dates.Count != 0)
            {
                var sum = dates.FindAll(x => Math.Abs
                (dates.First().Ticks - x.Ticks) <= span.Ticks);
                data.Add(sum.ToArray());
                dates.RemoveAll(d => sum.Contains(d));
            }

            return data.ToArray();
        }

        //Method to sum  all toll fee cost for one Day
        public double SumTotalFee2(DateTime[] dateTimes)
        {
            return dateTimes.Select(dateTime => feePerDayOperation
            .GetFeeInCertainTime(TimeOnly.FromDateTime(dateTime)))
            .Aggregate(0.0, (present, cost) => present < cost ? cost.Value : present);    
        }





        //private bool IsTollFreeVehicle(VehicleCategory vehicle)
        //{
        //    //////
        //   // if (vehicle == null) return false;

        //    String vehicleType = "";//vehicle.VehicleCategory();
        //    return vehicleType.Equals(VehicleCategory.EmergencyVehicle.ToString()) ||
        //           vehicleType.Equals(VehicleCategory.Bus.ToString()) ||
        //           vehicleType.Equals(VehicleCategory.DiplomatVehicle.ToString()) ||
        //           vehicleType.Equals(VehicleCategory.Motorcycles.ToString()) ||
        //           vehicleType.Equals(VehicleCategory.MilitaryVehicle.ToString()) ||
        //           vehicleType.Equals(VehicleCategory.Car.ToString());
        //}

        //public int GetTollFee(DateTime date, VehicleCategory vehicle)
        //{
        //    if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        //    int hour = date.Hour;
        //    int minute = date.Minute;

        //    if (hour == 6 && minute >= 0 && minute <= 29) return 8;
        //    else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
        //    else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
        //    else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
        //    else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
        //    else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
        //    else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
        //    else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
        //    else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
        //    else return 0;
        //}

        //private Boolean IsTollFreeDate(DateTime date)
        //{
        //    int year = date.Year;
        //    int month = date.Month;
        //    int day = date.Day;

        //    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        //    if (year == 2013)
        //    {
        //        if (month == 1 && day == 1 ||
        //            month == 3 && (day == 28 || day == 29) ||
        //            month == 4 && (day == 1 || day == 30) ||
        //            month == 5 && (day == 1 || day == 8 || day == 9) ||
        //            month == 6 && (day == 5 || day == 6 || day == 21) ||
        //            month == 7 ||
        //            month == 11 && day == 1 ||
        //            month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}



    }
}