namespace RoadTollSystem
{
    // to calculate the fee between a specific time period
    public class FeePerDayOperation
    {
        public FeePerDayOperation(IList<FeePerDay> feePerDayData)
        {
            this.feePerDayData = feePerDayData;
        }

        private  IList<FeePerDay> feePerDayData;


        // GetFeeInCertainTime return the toll fee of certain period 
        public double? GetFeeInCertainTime(TimeOnly timeOfDay)
        {
            var currentFee = feePerDayData.FirstOrDefault(x => timeOfDay.IsBetween(x.StartTime, x.EndTime));
            return (currentFee?.Cost);
        }

        // Method to return list of time period of an hour time span and its fee

        public  IEnumerable<DateTime[]> SortGateEntryInOneHour(List<DateTime> dates, TimeSpan span)
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
        public double SumTotalFee(DateTime[] dateTimes)
        {
            return dateTimes.Select(dateTime => GetFeeInCertainTime(TimeOnly.FromDateTime(dateTime)))
            .Aggregate(0.0, (present, cost) => present < cost ? cost.Value : present);
        }

    }
}
