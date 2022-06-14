namespace RoadTollSystem
{
    public class FeePerDay
    {
        //during one hour, starting from startTime and ending at endTime
        // cost to sum the toll fee
        public FeePerDay(double cost, TimeOnly startTime, TimeOnly endTime)
        {
            this.Cost = cost;
            this.StartTime = startTime;
            this.EndTime = endTime;       
        }

        public double Cost { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }


        




       

    }



}
