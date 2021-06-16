using ABCel.Entities.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCel.DAL
{
    public static class DataAccess
    {

        private static readonly string WorkordersPath = @"C:\Users\kayib\Desktop\ABCel\ABCel\DB\Workorders.json.txt";

        private static readonly string WorkOrderMaterialsPath = @"C:\Users\kayib\Desktop\ABCel\ABCel\DB\WorkOrderMaterials.json.txt";

        private static readonly string StockMaterialsPath = @"C:\Users\kayib\Desktop\ABCel\ABCel\DB\StockMaterials.json.txt";

        private static readonly string WorkOrderLaborsPath = @"C:\Users\kayib\Desktop\ABCel\ABCel\DB\WorkOrderLabors.json.txt";


        // Work Orders --------------------------------------------------------------------------------------------
        public static List<WorkOrderModel> WorkOrders_DeserializeFromJSON()
        {
            string serilized = File.ReadAllText(WorkordersPath);
            return JsonConvert.DeserializeObject<List<WorkOrderModel>>(serilized);
        }

        public static void WorkOrders_SerializeToJSON(List<WorkOrderModel> workOrders)
        {
            string serilized = JsonConvert.SerializeObject(workOrders, Formatting.Indented);
            File.WriteAllText(WorkordersPath, serilized);
        }

        // Work Order Materials ------------------------------------------------------------------------------------
        public static List<WorkOrderMaterialModel> WorkOrderMaterials_DeserializeFromJSON()
        {
            string serilized = File.ReadAllText(WorkOrderMaterialsPath);
            return JsonConvert.DeserializeObject<List<WorkOrderMaterialModel>>(serilized);
        }

        public static void WorkOrderMaterials_SerializeToJSON(List<WorkOrderMaterialModel> workOrderMaterials)
        {
            string serilized = JsonConvert.SerializeObject(workOrderMaterials, Formatting.Indented);
            File.WriteAllText(WorkOrderMaterialsPath, serilized);
        }

        // Stock Materials ----------------------------------------------------------------------------------------

        public static List<StockMaterialModel> StockMaterials_DeserializeFromJSON()
        {
            string serilized = File.ReadAllText(StockMaterialsPath);
            return JsonConvert.DeserializeObject<List<StockMaterialModel>>(serilized);
        }

        public static void StockMaterials_SerializeToJSON(List<StockMaterialModel> stockMaterials)
        {
            string serilized = JsonConvert.SerializeObject(stockMaterials, Formatting.Indented);
            File.WriteAllText(StockMaterialsPath, serilized);
        }


        // Work Order Labors --------------------------------------------------------------------------------------

        public static List<WorkOrderLaborModel> WorkOrderLabors_DeserializeFromJSON()
        {
            string serilized = File.ReadAllText(WorkOrderLaborsPath);
            return JsonConvert.DeserializeObject<List<WorkOrderLaborModel>>(serilized);
        }

        public static void WorkOrderLabors_SerializeToJSON(List<WorkOrderLaborModel> workOrderLabors)
        {
            string serilized = JsonConvert.SerializeObject(workOrderLabors, Formatting.Indented);
            File.WriteAllText(WorkOrderLaborsPath, serilized);
        }

    }
}
