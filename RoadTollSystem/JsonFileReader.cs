namespace RoadTollSystem
{


    public static class JsonFileReader
    {
        // Get data from Json file for toll fee
        public static IList<FeePerDay> GetDayFeeDataFromJsonFile (string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentNullException
                    ("Something went wrong! please check the file path or if the file exists");

            }
            var jsonText = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            // using the TimeOnlyConverter class 
            options.Converters.Add(new TimeOnlyConverter());

            //var jsonData = JsonSerializer.Deserialize<IList<DateOnly>>(jsonString, options);

            var DataFromJson = JsonSerializer.Deserialize<List<FeePerDay>>(jsonText, options);
            if(DataFromJson == null)
                throw new ArgumentNullException
                   ("Something went wrong! please check the Json file content");
            else 
            return DataFromJson;

        }

        // Get data from Json file for holydays of the year
        public static IList<DateOnly> GetHolydaysDataFromJson(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentNullException
                    ("Something went wrong! please check the file path or if the file exists");

            }
            var jsonText = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            // using the DateOnlyConverter class to set the DateOnly format as "yyyy'-'MM'-'dd"
            options.Converters.Add(new DateOnlyConverter());
            var DataFromJson = System.Text.Json.JsonSerializer.Deserialize<IList<DateOnly>>(jsonText, options);

            if (DataFromJson == null)
                throw new ArgumentNullException
                   ("Something went wrong! please check the Json file content");
            return DataFromJson;

        }



        //basic methods to instantiate Json file for holydays of the year
        public static void CreateHolidayJsonFile()

        {
            IList<DateOnly> holidays = new List<DateOnly> {
                new DateOnly(2022,01,05),
                new DateOnly(2022,01,06),
                new DateOnly(2022,04,18),
                new DateOnly(2022,05,25),
                new DateOnly(2022,05,26),
                new DateOnly(2022,06,06),
                new DateOnly(2022,06,24),
                new DateOnly(2022,11,04),
                new DateOnly(2022,12,26)};
            /*Utöver lördag och söndag samt juli månad, så är följande dagar befriade från trängselskatt under 2022:
            14-15 april
            18 april
            25-26 maj
            6 juni
            5-6 januari
            24 juni
            4 november
            26 december*/

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new DateOnlyConverter());
            var jsonFormattedContent = System.Text.Json.JsonSerializer.Serialize(holidays, options);
            string filename = @"d:\\holydayData.json";
            File.WriteAllText(filename, jsonFormattedContent);

        }


        //basic methods to instantiate Json file for toll fee per day in spsific time
        public static void CreateFeePerDayJsonFile()
        {
            IList<FeePerDay> feePerDays = new List<FeePerDay> {
        new FeePerDay(9 ,new TimeOnly( 06,00,00, 000),new TimeOnly( 06,29,59,999)),
        new FeePerDay(16,new TimeOnly( 06,30,00, 000),new TimeOnly( 06,59,59,999)),
        new FeePerDay(22,new TimeOnly( 07,00,00, 000),new TimeOnly( 07,59,59,999)),
        new FeePerDay(16,new TimeOnly( 08,00,00, 000),new TimeOnly( 08,29,59,999)),
        new FeePerDay(9 ,new TimeOnly( 08,30,00,000),new TimeOnly( 14,59,59,999)),
        new FeePerDay(16,new TimeOnly( 15,00,00, 000),new TimeOnly( 15,29,59,999)),
        new FeePerDay(22,new TimeOnly( 15,30,00, 000),new TimeOnly( 16,59,59,999)),
        new FeePerDay(16,new TimeOnly( 17,30,00, 000),new TimeOnly( 17,59,59,999)),
        new FeePerDay(9 ,new TimeOnly( 18,00,00, 000),new TimeOnly( 18,29,59,999)),
        new FeePerDay(0 ,new TimeOnly( 18,30,00, 000),new TimeOnly( 05,59,59,999))};

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new TimeOnlyConverter());
            var jsonFormattedContent = System.Text.Json.JsonSerializer.Serialize(feePerDays, options);
            string filename = @"d:\\tollFeeData.json";
            File.WriteAllText(filename, jsonFormattedContent);

        }






    }
}
