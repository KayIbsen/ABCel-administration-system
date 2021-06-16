using ABCel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCel.Entities.Classes
{
    public class Stock_Singleton
    {
        // Encapsulation
        private static Stock_Singleton _instance;
        // Safe iteration (reduced possibilities)
        private IEnumerable<StockMaterialModel> _materials;
       

        public static Stock_Singleton getInstance
        {
            // Lazy loading
            get
            {
                if (_instance == null)
                {
                    _instance = new Stock_Singleton();
                }
                return _instance;
            }
        }

        public IEnumerable<StockMaterialModel> GetStockMaterials()
        {
            RefreshStockMaterials();
            return _materials;
        }

        public void removeStockMaterial(string materialID, int quantity)
        {
            if (_materials == null)
            {
                RefreshStockMaterials();
            }
            lock (_materials)
            {
                //Upload the whole list
                List<StockMaterialModel> tempList = DAL.DataAccess.StockMaterials_DeserializeFromJSON();
                //Get the matching material
                StockMaterialModel tempMaterial = tempList.Find(mat => mat.ID == materialID);
                //Remove the quantity from the material
                tempMaterial.Quantity -= quantity;
                //Download the updated list
                DAL.DataAccess.StockMaterials_SerializeToJSON(tempList);

                RefreshStockMaterials();
            }
        }

        public void addStockMaterial(string materialID, int quantity)
        {
            if (_materials == null)
            {
                RefreshStockMaterials();
            }
            // Thread safety
            lock (_materials)
            {
                //Upload the whole list
                List<StockMaterialModel> tempList = DAL.DataAccess.StockMaterials_DeserializeFromJSON();
                //Get the matching material
                StockMaterialModel tempMaterial = tempList.Find(mat => mat.ID == materialID);
                //Remove the quantity from the material
                tempMaterial.Quantity += quantity;
                //Download the updated list
                DAL.DataAccess.StockMaterials_SerializeToJSON(tempList);

                RefreshStockMaterials();
            }
        }

        public double getStockMaterialPrice(string materialID)
        {
            //Upload the whole list
            List<StockMaterialModel> tempList = DAL.DataAccess.StockMaterials_DeserializeFromJSON();
            //Get the matching material
            StockMaterialModel tempMaterial = tempList.Find(mat => mat.ID == materialID);
            //return the price
            return tempMaterial.Price;
        }

        private void RefreshStockMaterials()
        {
            //Upload the whole list
            List<StockMaterialModel> tempList = DAL.DataAccess.StockMaterials_DeserializeFromJSON();
            //updated list
            List<StockMaterialModel> newList = new List<StockMaterialModel>();
            //add all items to new list where Spec isn't "labor material"
            foreach (StockMaterialModel mat in tempList)
            {
                if (mat.Spec != "labor")
                {
                    newList.Add(mat);
                }
            }
            _materials = newList;
        }

    }
}
