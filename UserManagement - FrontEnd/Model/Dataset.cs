using System.Collections.Generic;

namespace UserManagement___FrontEnd
{
    public class Dataset
    {
        public string? label { get; set; }

        public IEnumerable<int> data { get; set; } 

        public string[] backgroundColor { get; set; } = new string[] { "rgb(255, 0, 0)", "rgb(0, 0, 255)", "rgb(0, 255, 0)", "rgb(255,255,0)", "rgb(150,75,0)", "rgb(255,165,0)", "rgb(255,192,203)" };

        public int hoverOffset { get; set; } = 4;

        public Dataset(string? Label, IEnumerable<int> Data)
        {
            label = Label;

            data = Data;
        }
    }
}
