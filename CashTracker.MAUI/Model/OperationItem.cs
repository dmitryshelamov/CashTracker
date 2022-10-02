using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTracker.MAUI.Model
{
    public class OperationItem
    {
        public int Line { get; set; }
        public DateTime OperationDate { get; set; }
        public string CardNumber { get; set; }
        public decimal OperationAmount { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }
        public string MCC { get; set; }
        public string Description { get; set; }

    }
}
