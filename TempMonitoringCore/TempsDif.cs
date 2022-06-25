namespace TempMonitoring
{
    public class TempsDif
    {
        public DateTime Time { get; set; }
        public int FactTemp { get; set; }
        public int NormTemp { get; set; }
        public int TempDifferent { get; set; }

        public TempsDif (int factTemp, int normTemp, DateTime checkTime)
        {
            this.FactTemp = factTemp;
            this.NormTemp = normTemp;
            this.TempDifferent = factTemp - normTemp;
            this.Time = checkTime;
        }
        public override string ToString()
        {
            return $"{Time.ToString()}. Fact temp {FactTemp}. Norm temp{NormTemp}. Temp different {TempDifferent}";
        }
    }
}


