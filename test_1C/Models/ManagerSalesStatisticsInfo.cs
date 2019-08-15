using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_1C.Models
{

    public class ManagerSalesStatisticsInfo
    {
        /// <summary>
        /// Период
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// Измерение1 - Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Измерение2 - ФИО менеджера
        /// </summary>
        public string manager { get; set; }

        /// <summary>
        /// Измерение3 - ?
        /// </summary>
        public string Measurement3 { get; set; }

        /// <summary>
        /// % выполнения плана по компании
        /// </summary>
        public string Companyplan { get; set; }

        /// <summary>
        /// % выполнения плана по валовой прибыли
        /// </summary>
        public string Grossplan { get; set; }

        /// <summary>
        /// % выполнения плана по компании (ТОП 10+1)
        /// </summary>
        public string Companyplantop { get; set; }

        /// <summary>
        /// % выполнения плана по компании (ТОП 10+1)
        /// </summary>
        public string Grossplantop { get; set; }

        /// <summary>
        /// % выполнения плана по компании (на дату)
        /// </summary>
        public string Companyplandate { get; set; }

        /// <summary>
        /// % выполнения плана по валовой прибыли (на дату)
        /// </summary>
        public string Grossplandate { get; set; }

        /// <summary>
        /// : % выполнения плана по компании10+1 (на дату)
        /// </summary>
        public string Companyplandatetop { get; set; }

        /// <summary>
        /// % выполнения плана по валовой прибыли10+1 (на дату)
        /// </summary>
        public string Grossplandatetop { get; set; }
      


        public ManagerSalesStatisticsInfo(Dictionary<string, string> rowData)
        {
            Period = rowData.ValueOrDefault("Период");
            City = rowData.ValueOrDefault("Измерение1");
            manager = rowData.ValueOrDefault("Измерение2");
            Measurement3 = rowData.ValueOrDefault("Измерение3");

            Companyplan = rowData.ValueOrDefault("Ресурс1");
            Grossplan = rowData.ValueOrDefault("Ресурс2");
            Companyplantop = rowData.ValueOrDefault("Ресурс3");
            Grossplantop = rowData.ValueOrDefault("Ресурс4");
            Companyplandate = rowData.ValueOrDefault("Ресурс5");
            Grossplandate = rowData.ValueOrDefault("Ресурс6");
            Companyplandatetop = rowData.ValueOrDefault("Ресурс7");
            Grossplandatetop = rowData.ValueOrDefault("Ресурс8");
        }
    }
}