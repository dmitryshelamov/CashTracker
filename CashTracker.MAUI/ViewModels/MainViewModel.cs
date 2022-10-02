using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CashTracker.Core;
using CashTracker.MAUI.Model;



namespace CashTracker.MAUI.ViewModels
{
    public class MainViewModel
    {
        readonly IList<OperationItem> source;
        public string ProfileDetails { get; set; } = "Back-End Developer";

        public decimal Balance { get; set; } = 0;

        // public List<OperationItem> Operations = new List<OperationItem>()
        // {
        //     new OperationItem
        //     {
        //         FirstName = "FirstName",
        //         LastName = "LastName"
        //     }
        // };

        public List<OperationItem> Operations { get; private set; }



        public MainViewModel()
        {
            source = new List<OperationItem>();
            var data = new TinkoffCsvReader().Read();
            var line = 1;
            foreach (var model in data)
            {
                source.Add(new OperationItem()
                {
                    Line = line,
                    CardNumber = model.CardNumber,
                    Category = model.Category,
                    Currency = model.Currency,
                    Description = model.Description,
                    MCC = model.MCC,
                    OperationAmount = model.OperationAmount,
                    OperationDate = model.OperationDate
                });
                line++;
            }

            Balance = source.Sum(x => x.OperationAmount);

            // for (int i = 0; i < 10000; i++)
            // {
            //     source.Add(new OperationItem()
            //     {
            //         Line = line,
            //         CardNumber = data[1].CardNumber,
            //         Category = data[1].Category,
            //         Currency = data[1].Currency,
            //         Description = data[1].Description,
            //         MCC = data[1].MCC,
            //         OperationAmount = data[1].OperationAmount,
            //         OperationDate = data[1].OperationDate
            //     });
            //     line++;
            // }


            Operations = new List<OperationItem>(source);
        }
    }
}
