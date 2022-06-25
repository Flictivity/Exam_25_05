namespace TempMonitoring
{
    class TempCalc
    {
        public Product prod;
        private DateTime date;
        int[] temps;
        int timeInterval;
        private DateTime ckeckTime;
        List<TempsDif> diffs;

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

            foreach (int temperature in temps)
            {
                ckeckTime.AddMinutes(timeInterval);
                int maxWaitTime = 0;
                int minWaitTime = 0;

                if (temperature > prod.maxTempVal)
                {
                    maxWaitTime += timeInterval;
                    minWaitTime = 0;
                }
                else if (temperature >= prod.minTempVal
                        && temperature <= prod.maxTempVal)
                {
                    maxWaitTime = 0;
                    minWaitTime = 0;
                    continue;
                }
                else
                {
                    maxWaitTime = 0;
                    minWaitTime += timeInterval;
                }

                if (maxWaitTime > prod.maxTempVal)
                {
                    diffs.Add(new TempsDif(temperature, prod.maxTempVal, ckeckTime));
                    continue;
                }

                if (minWaitTime > prod.minTempVal)
                {
                    diffs.Add(new TempsDif(temperature, prod.minTempVal, ckeckTime));
                }
            }
        }
    }
}


