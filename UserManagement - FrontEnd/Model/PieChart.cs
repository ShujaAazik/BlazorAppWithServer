using System.Collections.Generic;

namespace UserManagement___FrontEnd
{
    public class PieChart : IChart
    {
        public string[] labels { get; set; }

        public IEnumerable<Dataset> datasets { get; set; }

        public PieChart(string[] Labels,IEnumerable<Dataset> Datasets)
        {
            datasets = Datasets;
            labels = Labels;
        }
    }
}
