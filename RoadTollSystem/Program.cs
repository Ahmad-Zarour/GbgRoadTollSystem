
Console.WriteLine("Hello, World!");


//RoadTollSystem.JsonToCSConverter.CreateFeePerDayJsonFile();
//RoadTollSystem.JsonToCSConverter.CreateHolidayJsonFile();
//string filename = @"d:\\holy.json";


//var result = RoadTollSystem.JsonToCSConverter.GetHolydaysDataFromJson(filename);
//foreach (var item in result)
//{
//    Console.Write(item.Day);
//    Console.Write("/");
//    Console.Write(item.Month);
//    Console.Write("/");

//    Console.WriteLine(item.Year);
//}

//string filename2 = @"d:\\feePerDays.json";


//var result2 = RoadTollSystem.JsonToCSConverter.GetDayFeeDataFromJsonFile(filename2);
//foreach (var item in result2) 
//{
//    Console.WriteLine(item.Cost);
//    Console.WriteLine(item.startTime);
//    Console.WriteLine(item.endTime);
//}

//string filename = @"d:\\tollFeeData.json";
//var filename = Path.Combine(Directory.GetCurrentDirectory(), "tollFeeData.json");
//Console.WriteLine(filename);
//var result = RoadTollSystem.JsonFileReader.GetDayFeeDataFromJsonFile(filename);
////var x = new RoadTollSystem.FeePerDayOperation(result);
////var timeNow = TimeOnly.FromDateTime(DateTime.Now);
////var nswer = x.GetFeeInCertainTime(timeNow);
////Console.WriteLine("The cost is "+nswer);


//////

//string filename2 = @"d:\\holydayData.json";
//var result2 = RoadTollSystem.JsonFileReader.GetHolydaysDataFromJson(filename2);
////var x2 = new RoadTollSystem.NoFeeDayOperation(result2);
////var daytoday = new  DateOnly(year:2022,month:6,day:7);
////Console.WriteLine(x2.CheckIfHoliday(daytoday));
////Console.WriteLine(x2.CheckIfWeekend(daytoday));


//var test = new TollCalculator(result2, result);
//var traffic = new List<DateTime>
//        {
//            new DateTime(2022, 6, 10, 6, 0, 25),
//            new DateTime(2022, 6, 10, 9, 15, 25),
//        //    new DateTime(2022, 4, 8, 11, 25, 5),
//        //    new DateTime(2022, 4, 8, 14, 20, 0),
//        //    new DateTime(2022, 4, 8, 20, 25, 0),
//        //    new DateTime(2022, 4, 8, 22, 25, 0),
//        //    new DateTime(2022, 4, 8, 23, 40, 0),
//        };

var traffic2 = new List<DateOnly>
        {
            new DateOnly(2022, 6, 10),
            new DateOnly(2022, 6, 10),
        //    new DateTime(2022, 4, 8, 11, 25, 5),
        //    new DateTime(2022, 4, 8, 14, 20, 0),
        //    new DateTime(2022, 4, 8, 20, 25, 0),
        //    new DateTime(2022, 4, 8, 22, 25, 0),
        //    new DateTime(2022, 4, 8, 23, 40, 0),
        };

NoFeeDayOperation xdf = new NoFeeDayOperation(traffic2);
//var res = xdf.CheckIfJuly(new DateOnly(2022,07,10));
//Console.WriteLine(res);
//var answer = test.GetTollFee(VehicleCategory.Car,traffic.ToArray());
//Console.WriteLine("The answer : "+answer);

//var sty = Path.Combine(Directory.GetCurrentDirectory(), "tollFeeData.json");
//var y = Directory.GetCurrentDirectory();
//var yyy = Environment.CurrentDirectory;

//Console.WriteLine(sty);
//Console.WriteLine(y);
//Console.WriteLine(yyy);


//JsonFileReader.CreateFeePerDayJsonFile();


