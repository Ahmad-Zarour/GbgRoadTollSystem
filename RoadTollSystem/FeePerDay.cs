namespace RoadTollSystem
{
    public class FeePerDay
    {
        //during one hour, starting from startTime and ending at endTime
        // cost to sum the toll fee
        public FeePerDay(decimal cost, TimeOnly startTime, TimeOnly endTime)
        {
            this.Cost = cost;
            this.StartTime = startTime;
            this.EndTime = endTime;       
        }

        public decimal Cost { get; }
        public TimeOnly StartTime { get; }
        public TimeOnly EndTime { get;  }


        




       

    }



}
