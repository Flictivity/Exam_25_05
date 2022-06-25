namespace TempMonitoring
{
    class Product
    {
        public string prodName;
        public int maxTempVal;
        public int maxTempValTime;
        public int minTempVal;
        public int minTempValTime;

        public Product(string prosuctName, int maxTempVal,
            int maxTempValTime, int minTempVal, int minTempValTime)
        {
            this.prodName = prosuctName;
            this.maxTempVal = maxTempVal;
            this.maxTempValTime = maxTempValTime;
            this.minTempVal = minTempVal;
            this.minTempValTime = minTempValTime;
        }
        public Product(string prosuctName, int maxTempVal, int maxTempValTime)
        {
            this.prodName = prosuctName;
            this.maxTempVal = maxTempVal;
            this.maxTempValTime = maxTempValTime;
            this.minTempVal = int.MinValue;
            this.minTempValTime = int.MaxValue;
        }
    }
    class TempCalc
    {
        public Product prod;
        private DateTime date;
        int[] temps;
        int timeInterval;
        private DateTime resTime;
        public TempCalc(DateTime date, int[] temps, int intervalTime)
        {
            this.date = date;
            this.temps = temps;
            timeInterval = intervalTime;
        }
        public void Calculate()
        {
            if (temps.Length < 18 && temps.Length > 54)
            {
                throw new Exception("Temps data not correct format");
            }

            foreach (var temperature in temps)
            {
                resTime.AddMinutes(timeInterval);
                int maxTime = 0;
                int minTime = 0;

                if (temperature >= prod.minTempVal
                        && temperature <= prod.maxTempVal)
                {
                    maxTime = 0;
                    minTime = 0;
                    continue;
                }
                else if (temperature > prod.maxTempVal)
                {
                    maxTime += timeInterval;
                    minTime = 0;
                }
                else
                {
                    minTime += timeInterval;
                    maxTime = 0;
                }


                if (maxTime > prod.maxTemperatureTime)
                {
                    violations.Add(new TemperatureViolation(interimDate,
                        new Temperature(temperature), shipProduct.maxTemperature));
                    continue;
                }

                if (minTime > shipProduct.minTemperatureTime)
                {
                    violations.Add(new TemperatureViolation(interimDate,
                        new Temperature(temperature), shipProduct.minTemperature));
                }
            }
        }

}


