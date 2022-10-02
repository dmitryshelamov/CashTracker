using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTracker.Core
{
    public class TinkoffCsvModel
    {
        public DateTime OperationDate { get; set; }
        public string CardNumber { get; set; }
        public decimal OperationAmount { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }
        public string MCC { get; set; }
        public string Description { get; set; }
    }
}
