namespace TempMonitoring
{
    public class Product
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

        public override string ToString()
        {
            return $"Продукт:{prodName}. Максимальная температура{maxTempVal}. " +
                $"Минимальная температура{minTempVal}. Время максимальной температура{maxTempValTime}" +
                $"Время максимальной температура{minTempValTime}";
        }
    }
}


