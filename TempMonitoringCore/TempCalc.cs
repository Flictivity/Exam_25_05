namespace TempMonitoring
{
    public class TempCalc
    {
        public Product prod;
        public DateTime date;
        int[] temps;
        int timeInterval;
        private DateTime ckeckTime;
        public List<TempsDif> diffs = new List<TempsDif>();
        public List<TempsDif> currentDiffs = new List<TempsDif>();

        public TempCalc(DateTime date, int[] temps, int intervalTime)
        {
            this.date = date;
            ckeckTime = this.date;
            this.temps = temps;
            timeInterval = intervalTime;
        }
        public void Calculate()
        {
            if (temps.Length < 18 && temps.Length > 54)
            {
                throw new Exception("Temps data not correct format");
            }
            int maxWaitTime = 0;
            int minWaitTime = 0;
            foreach (int temperature in temps)
            {
                if (temperature >= prod.minTempVal
                        && temperature <= prod.maxTempVal)
                {
                    if (maxWaitTime > prod.maxTempValTime ||
                        minWaitTime > prod.minTempValTime)
                    {
                        diffs.AddRange(currentDiffs.ToArray());
                    }

                    currentDiffs.Clear();
                    maxWaitTime = 0;
                    minWaitTime = 0;
                    continue;
                }
                else if (temperature > prod.maxTempVal)
                {
                    maxWaitTime += timeInterval;
                    minWaitTime = 0;
                    currentDiffs.Add(new TempsDif(temperature, prod.maxTempVal, ckeckTime));
                }
                else
                {
                    minWaitTime += timeInterval;
                    maxWaitTime = 0;
                    currentDiffs.Add(new TempsDif(temperature, prod.minTempVal, ckeckTime));
                }
            }
        }
        public void Load(string loadPath)
        {
            string line;
            using (var sR = new StreamReader(loadPath))
            {
                try
                {
                    date = DateTime.Parse(sR.ReadLine());
                    temps = Array.ConvertAll<string, int>(sR.ReadLine().Split(), int.Parse);
                }
                catch (Exception ex)
                {
                }
            }
        }
        public void Save(string loadPath)
        {
            using(var sW = new StreamWriter(loadPath))
            {
                sW.WriteLine(date);
                sW.WriteLine(prod);
                foreach(var t in diffs)
                {
                    sW.WriteLine(t);
                }
            }
        }
    }
}

