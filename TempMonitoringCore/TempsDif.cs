namespace TempMonitoring
{
    class TempsDif
    {
        public int factTemp;
        public int normTemp;
        public int tempDifferent;
        DateTime checkTime;

        public TempsDif (int factTemp, int normTemp, DateTime checkTime)
        {
            this.tempDifferent = tempDifferent;
            this.factTemp = factTemp;
            this.tempDifferent = factTemp - normTemp;
            this.checkTime = checkTime;
        }
    }
}


