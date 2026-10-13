using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_24
{
    public class Book : IDataErrorInfo
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int Year { get; set; } = 2020;

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Title" && string.IsNullOrWhiteSpace(Title))
                    return "Название не может быть пустым";

                if (columnName == "Year")
                {
                    int currentYear = System.DateTime.Now.Year;
                    if (Year <= 0 || Year >= currentYear)
                        return $"Год должен быть числом > 0 и < {currentYear}";
                }

                return null;
            }
        }
    }
}