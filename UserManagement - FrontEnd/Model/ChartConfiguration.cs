namespace UserManagement___FrontEnd.Model
{
    public class ChartConfiguration
    {
        public string type { get; set; }

        public IChart data { get; set; }

        public ChartConfigOption options { get; set; }

        public ChartConfiguration(string Type, IChart Data)
        {
            type = Type;
            data = Data;    
        }
    }
}
