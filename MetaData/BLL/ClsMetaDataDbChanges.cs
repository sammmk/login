﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace MetaData.BLL
{
    public class ClsMetaDataDbChanges
    {
        private CommonControls.Classes.dbConnection CONN;
        private CommonControls.Classes.ClsCommonMethods COMMON;
        private CommonControls.Classes.ClsCommonMethods COM_METHODS;

        public ClsMetaDataDbChanges()
        {
            CONN = new CommonControls.Classes.dbConnection();
            COMMON = new CommonControls.Classes.ClsCommonMethods();
            COM_METHODS = new CommonControls.Classes.ClsCommonMethods();
        }

        public int getMaxItemId()
        {
            int maxItemId = 1;

            try
            {
                string querry = "SELECT MAX(itemId) from tbl_item;";
                maxItemId = CONN.getMaxId(querry);

                //create ItemId for the first time   
                if (maxItemId <= 1)
                {
                    //maxId += 40000;
                    string querry2 = "SELECT prefixValue FROM tbl_prefix WHERE prefixName = 'itemId';";
                    maxItemId = CONN.getPrefix(querry2);
                    int tmp = Convert.ToInt32(string.Concat(maxItemId.ToString(), "0000")) + 1;
                    maxItemId = tmp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return maxItemId;
        }

        public int getMaxDealerId()
        {
            int maxDealerId = 1;

            try
            {
                string querry = "SELECT MAX(dealerId) from tbl_dealers;";
                maxDealerId = CONN.getMaxId(querry);

                //create Dealer Id for the first time
                if(maxDealerId <= 1)
                {
                    string querry2 = "SELECT prefixValue FROM tbl_prefix WHERE prefixName = 'dealerId';";
                    maxDealerId = CONN.getMaxId(querry2);
                    int tmp = Convert.ToInt32(string.Concat((maxDealerId - 1).ToString(), "0000")) + 1;
                    maxDealerId = tmp;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return maxDealerId;
        }

        public int getMaxDestinationId()
        {
            int maxDestId = 1;

            try
            {
                string querry = "SELECT MAX(destinationId) from tbl_destinations;";
                maxDestId = CONN.getMaxId(querry);

                //create Destination Id for the first time
                if (maxDestId <= 1)
                {
                    string querry2 = "SELECT prefixValue FROM tbl_prefix WHERE prefixName = 'destinationId';";
                    maxDestId = CONN.getMaxId(querry2);
                    int tmp = Convert.ToInt32(string.Concat((maxDestId - 1).ToString(), "0000")) + 1;
                    maxDestId = tmp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return maxDestId;
        }
        
        public int getMaxAssetId()
        {
            int maxAssetId = 1;

            try
            {
                string querry = "SELECT MAX(assetId) from tbl_assets;";
                maxAssetId = CONN.getMaxId(querry);

                //create Asset Id for the first time
                if (maxAssetId <= 1)
                {
                    string querry2 = "SELECT prefixValue FROM tbl_prefix WHERE prefixName = 'assetId';";
                    maxAssetId = CONN.getMaxId(querry2);
                    int tmp = Convert.ToInt32(string.Concat((maxAssetId - 1).ToString(), "0000")) + 1;
                    maxAssetId = tmp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return maxAssetId;
        }

        public int getMaxTaxId()
        {
            int maxTaxId = 1;

            try
            {
                string querry = "SELECT MAX(taxId) from tbl_tax;";
                maxTaxId = CONN.getMaxId(querry);

                //create Tax Id for the first time
                if (maxTaxId <= 1)
                {
                    string querry2 = "SELECT prefixValue FROM tbl_prefix WHERE prefixName = 'taxId';";
                    maxTaxId = CONN.getMaxId(querry2);
                    int tmp = Convert.ToInt32(string.Concat((maxTaxId - 1).ToString(), "0000")) + 1;
                    maxTaxId = tmp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return maxTaxId;
        }

        public int getMaxUnitId()
        {
            int maxUnitId = 1;

            try
            {
                string querry = "SELECT MAX(unitId) from tbl_units;";
                maxUnitId = CONN.getMaxId(querry);

                //create Unit Id for the first time
                if (maxUnitId <= 1)
                {
                    string querry2 = "SELECT prefixValue FROM tbl_prefix WHERE prefixName = 'unitId';";
                    maxUnitId = CONN.getMaxId(querry2);
                    int tmp = Convert.ToInt32(string.Concat((maxUnitId - 1).ToString(), "0000")) + 1;
                    maxUnitId = tmp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return maxUnitId;
        }

        public DataTable getItemTypeList()
        {
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_itemtype;";

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                dt = null;
                throw ex;
            }

            return dt;
        }

        public bool deleteItem(int itemId)
        {
            bool ret = false;
            string q = string.Empty;

            try
            {
                q = "UPDATE tbl_item SET deleteFlg = '1' WHERE itemId = '" + itemId + "';";
                ret = CONN.update(q);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        public bool deleteDealer(int dealerId)
        {
            bool ret = false;
            string q = string.Empty;

            try
            {
                q = "UPDATE tbl_dealers SET deleteFlg = '1' WHERE itemId = '" + dealerId + "';";
                ret = CONN.update(q);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        public bool deleteDestination(int destId)
        {
            bool ret = false;
            string q = string.Empty;

            try
            {
                q = "UPDATE tbl_destinations SET deleteFlg = '1' WHERE destinationId = '" + destId + "';";
                ret = CONN.update(q);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        public bool deleteAsset(int assetId)
        {
            bool ret = false;
            string q = string.Empty;

            try
            {
                q = "UPDATE tbl_assets SET deleteFlg = '1' WHERE assetId = '" + assetId + "';";
                ret = CONN.update(q);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        public bool deleteTax(int taxId)
        {
            bool ret = false;
            string q = string.Empty;

            try
            {
                q = "UPDATE tbl_tax SET deleteFlg = '1' WHERE taxId = '" + taxId + "';";
                ret = CONN.update(q);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        public bool deleteUnit(int unitId)
        {
            bool ret = false;
            string q = string.Empty;

            try
            {
                q = "UPDATE tbl_units SET deleteFlg = '1' WHERE unitId = '" + unitId + "';";
                ret = CONN.update(q);
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        public bool insertData_item(ClsItemData itemData)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += "INSERT INTO tbl_item (itemId, itemCode, itemName, altName, itemTypeId, stockUnitId, shopUnitId) VALUES (";
                querry += "'" + itemData._itemId + "',";
                querry += "'" + itemData._itemCode + "',";
                querry += "'" + itemData._itemName + "',";
                querry += "'" + itemData._altName + "',";
                querry += "'" + itemData._itemTypeId + "',";
                querry += "'" + itemData._stockUnitId + "',";
                querry += "'" + itemData._shopUnitId + "'";
                querry += ");";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool updateData_item(ClsItemData itemData)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += "UPDATE tbl_item SET ";
                querry += "itemName = '" + itemData._itemName + "', ";
                querry += "altName = '" + itemData._altName + "', ";
                querry += "itemTypeId = '" + itemData._itemTypeId + "', ";
                querry += "stockUnitId = '" + itemData._stockUnitId + "', ";
                querry += "shopUnitId = '" + itemData._shopUnitId + "' ";
                querry += "WHERE itemId = '" + itemData._itemId + "';";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool insertData_dealer(ClsDealerData dealer)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += "INSERT INTO tbl_dealers (dealerId, dealerName, companyName, address, phoneNo, mobile) VALUES (";
                querry += "'" +dealer._dealerId + "',";
                querry += "'" + dealer._dealerName + "',";
                querry += "'" + dealer._companyName + "',";
                querry += "'" + dealer._address + "',";
                querry += "'" + dealer._phoneNo + "',";
                querry += "'" + dealer._mobile + "'";
                querry += ");";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool insertData_destination(ClsDestinationData destination)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += @"INSERT INTO tbl_destinations 
                             (destinationId, destinationName, ownerName, address, phoneNo, mobile) VALUES (";
                querry += "'" + destination._destId + "',";
                querry += "'" + destination._destName + "',";
                querry += "'" + destination._ownerName + "',";
                querry += "'" + destination._address + "',";
                querry += "'" + destination._phoneNo + "',";
                querry += "'" + destination._mobile + "'";
                querry += ");";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool insertData_asset(ClsAssetData asset)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += @"INSERT INTO tbl_assets 
                             (assetId, assetName, value, description, quantity, totalValue) VALUES (";
                querry += "'" + asset._assetId + "',";
                querry += "'" + asset._assetName + "',";
                querry += "'" + asset._value + "',";
                querry += "'" + asset._descrption + "',";
                querry += "'" + asset._quantity + "',";
                querry += "'" + asset._totalValue + "'";
                querry += ");";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool insertData_tax(ClsTaxData tax)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += @"INSERT INTO tbl_tax 
                             (taxId, description, taxPercentage, symbol, effective_from, effective_to) VALUES (";
                querry += "'" + tax._taxId + "',";
                querry += "'" + tax._description + "',";
                querry += "'" + tax._taxPercentage + "',";
                querry += "'" + tax._symbol + "',";
                querry += "'" + tax._effectFrom + "',";
                querry += "'" + tax._effectTo + "'";
                querry += ");";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool insertData_unit(ClsUnitData unit)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += @"INSERT INTO tbl_units 
                             (unitId, description, symbol) VALUES (";
                querry += "'" + unit._unitId + "',";
                querry += "'" + unit._description + "',";
                querry += "'" + unit._symbol + "'";
                querry += ");";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool updateData_dealer(ClsDealerData dealer)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += "UPDATE tbl_dealers SET ";
                querry += "dealerName = '" + dealer._dealerName + "', ";
                querry += "companyName = '"+dealer._companyName + "', ";
                querry += "address = '" + dealer._address + "',";
                querry += "phoneNo ='" + dealer._phoneNo + "', ";
                querry += "mobile ='" + dealer._mobile + "' ";
                querry += "WHERE dealerId = '" + dealer._dealerId + "'";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool updateData_destination(ClsDestinationData destination)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += "UPDATE tbl_destinations SET ";
                querry += "destinationName = '" + destination._destName + "', ";
                querry += "ownerName = '" + destination._ownerName + "', ";
                querry += "address = '" + destination._address + "',";
                querry += "phoneNo ='" + destination._phoneNo + "', ";
                querry += "mobile ='" + destination._mobile + "' ";
                querry += "WHERE destinationId = '" + destination._destId + "'";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool updateData_asset(ClsAssetData asset)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += "UPDATE tbl_assets SET ";
                querry += "assetName = '" + asset._assetName + "', ";
                querry += "value = '" + asset._value + "', ";
                querry += "description = '" + asset._descrption + "',";
                querry += "quantity ='" + asset._quantity + "', ";
                querry += "totalValue ='" + asset._totalValue + "' ";
                querry += "WHERE assetId = '" + asset._assetId + "';";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool updateData_tax(ClsTaxData tax)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += "UPDATE tbl_tax SET ";
                querry += "description = '" + tax._description + "', ";
                querry += "symbol = '" + tax._symbol + "', ";
                querry += "taxPercentage = '" + tax._taxPercentage + "', ";
                querry += "effective_from = '" + tax._effectFrom + "',";
                querry += "effective_to ='" + tax._effectTo + "'";
                querry += "WHERE taxId = '" + tax._taxId + "';";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public bool updateData_unit(ClsUnitData unit)
        {
            bool isOK = false;
            string querry = string.Empty;

            try
            {
                querry += "UPDATE tbl_units SET ";
                querry += "description = '" + unit._description + "', ";
                querry += "symbol = '" + unit._symbol + "' ";
                querry += "WHERE unitId = '" + unit._unitId + "';";

                isOK = CONN.update(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isOK;
        }

        public int getMaxItemTypeID()
        {
            int maxItemTypeID = 1;

            try
            {
                string querry = "SELECT MAX(typeId) from tbl_itemtype;";
                maxItemTypeID = CONN.getMaxId(querry);

                //create ItemTypeID for the first time    
                if (maxItemTypeID <= 1)
                {
                    //maxUserId += 30000;
                    string querry2 = "SELECT prefixValue FROM tbl_prefix WHERE prefixName = 'itemTypeId';";
                    maxItemTypeID = CONN.getPrefix(querry2);
                    int tmp = Convert.ToInt32(string.Concat(maxItemTypeID.ToString(), "0000")) + 1;
                    maxItemTypeID = tmp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return maxItemTypeID;
        }

        public bool insertData_itemType(int typeId, string typeName)
        {
            bool ret = false;
            string itemType = string.Empty;

            try
            {
                itemType = "INSERT INTO tbl_itemtype (typeId, itemType) VALUES (";
                itemType += "'" + typeId + "',";
                itemType += "'" + typeName;
                itemType += "');";

                ret = CONN.update(itemType);
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        public bool updateData_itemType(int typeId, string typeName)
        {
            bool ret = false;
            string itemType = string.Empty;

            try
            {
                itemType = "UPDATE tbl_itemtype SET ";
                itemType += "itemType = '" + typeName + "' ";
                itemType += "WHERE typeId = '" + typeId + "';";

                ret = CONN.update(itemType);
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        public DataTable getItemTypeDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_itemtype;";

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getDealerDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_dealers WHERE deleteFlg != '1';";

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getDestinationDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_destinations WHERE deleteFlg != '1';";

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getAssetDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_assets WHERE deleteFlg != '1';";

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getUnitDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_units WHERE deleteFlg != '1';";

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public ClsItemTypeData getSingleItemTypeData(int itemTypeId)
        {
            ClsItemTypeData itemTypeData = new ClsItemTypeData();
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_itemtype WHERE typeId = '" + itemTypeId + "';";

                dt = CONN.getDataTable(querry);

                if (dt.Rows.Count > 0)
                {
                    itemTypeData._itemTypeId = Convert.ToInt32(dt.Rows[0]["typeId"]);
                    itemTypeData._itemTypeName = dt.Rows[0]["itemType"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemTypeData;
        }

        public ClsDealerData getSingleDealerData(int dealerId)
        {
            ClsDealerData dealer = new ClsDealerData();
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_dealers WHERE dealerId = '" + dealerId + "';";
                dt = CONN.getDataTable(querry);

                if (dt.Rows.Count > 0)
                {
                    dealer._dealerId = Convert.ToInt32(dt.Rows[0]["dealerId"]);
                    dealer._dealerName = dt.Rows[0]["dealerName"].ToString();
                    dealer._companyName = dt.Rows[0]["companyName"].ToString();
                    dealer._address = dt.Rows[0]["address"].ToString();
                    dealer._phoneNo = dt.Rows[0]["phoneNo"].ToString();
                    dealer._mobile = dt.Rows[0]["mobile"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dealer;
        }

        public ClsDestinationData getSingleDestinationData(int destId)
        {
            ClsDestinationData destination = new ClsDestinationData();
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_destinations WHERE destinationId = '" + destId + "';";
                dt = CONN.getDataTable(querry);

                if (dt.Rows.Count > 0)
                {
                    destination._destId = Convert.ToInt32(dt.Rows[0]["destinationId"]);
                    destination._destName = dt.Rows[0]["destinationName"].ToString();
                    destination._ownerName = dt.Rows[0]["ownerName"].ToString();
                    destination._address = dt.Rows[0]["address"].ToString();
                    destination._phoneNo = dt.Rows[0]["phoneNo"].ToString();
                    destination._mobile = dt.Rows[0]["mobile"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return destination;
        }

        public ClsAssetData getSingleAssetData(int assetId)
        {
            ClsAssetData asset = new ClsAssetData();
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_assets WHERE assetId = '" + assetId + "';";
                dt = CONN.getDataTable(querry);

                if (dt.Rows.Count > 0)
                {
                    asset._assetId = Convert.ToInt32(dt.Rows[0]["assetId"]);
                    asset._assetName = dt.Rows[0]["assetName"].ToString();
                    asset._value = Convert.ToDouble(dt.Rows[0]["value"].ToString());
                    asset._descrption = dt.Rows[0]["description"].ToString();
                    asset._quantity = Convert.ToDouble(dt.Rows[0]["quantity"].ToString());
                    asset._totalValue = Convert.ToDouble(dt.Rows[0]["totalValue"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return asset;
        }

        public ClsUnitData getSingleUnitData(int unitId)
        {
            ClsUnitData unit = new ClsUnitData();
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_units WHERE unitId = '" + unitId + "';";
                dt = CONN.getDataTable(querry);

                if (dt.Rows.Count > 0)
                {
                    unit._unitId = Convert.ToInt32(dt.Rows[0]["unitId"]);
                    unit._description = dt.Rows[0]["description"].ToString();
                    unit._symbol = dt.Rows[0]["symbol"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return unit;
        }

        public DataTable getItemDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                string querry = @"SELECT * FROM vw_item;";

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable getTaxDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                string querry = @"SELECT * FROM tbl_tax;";

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public ClsItemData getSingleItemData(int itemId)
        {
            ClsItemData itemData = new ClsItemData();

            try
            {
                string querry = @"SELECT * FROM vw_item WHERE itemId = '" + itemId + "'; ";

                DataTable dt = new DataTable();

                dt = CONN.getDataTable(querry);

                if (dt.Rows.Count > 0)
                {
                    itemData._itemId = Convert.ToInt32(dt.Rows[0]["itemId"].ToString());
                    itemData._itemCode = dt.Rows[0]["itemCode"].ToString();
                    itemData._itemName = dt.Rows[0]["itemName"].ToString();
                    itemData._altName = dt.Rows[0]["altName"].ToString();
                    itemData._itemTypeId = Convert.ToInt32(dt.Rows[0]["itemTypeId"].ToString());
                    itemData._itemTypeName = dt.Rows[0]["itemType"].ToString();
                    itemData._stockUnitId = Convert.ToInt32(dt.Rows[0]["stockUnitId"].ToString());
                    itemData._stockUnitName = dt.Rows[0]["stockUnit"].ToString();
                    itemData._shopUnitId = Convert.ToInt32(dt.Rows[0]["shopUnitId"].ToString());
                    itemData._shopUnitName = dt.Rows[0]["shopUnit"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return itemData;
        }

        public ClsTaxData getSingleTaxData(int taxId)
        {
            ClsTaxData taxData = new ClsTaxData();

            try
            {
                string querry = @"SELECT * FROM tbl_tax WHERE taxId = '" + taxId + "'; ";

                DataTable dt = new DataTable();

                dt = CONN.getDataTable(querry);

                if (dt.Rows.Count > 0)
                {
                    taxData._taxId = Convert.ToInt32(dt.Rows[0]["taxId"].ToString());
                    taxData._description = dt.Rows[0]["description"].ToString();
                    taxData._symbol = dt.Rows[0]["symbol"].ToString();
                    taxData._taxPercentage = Convert.ToDouble(dt.Rows[0]["taxPercentage"]);
                    taxData._effectFrom = Convert.ToDateTime(dt.Rows[0]["effective_from"]);
                    taxData._effectTo = Convert.ToDateTime(dt.Rows[0]["effective_to"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return taxData;
        }

        public DataTable getDealerWhileSearching(int type, string str)
        {
            DataTable dt = new DataTable();
            string querry = string.Empty;
            try
            {
                if (type == 2)
                {
                    querry = "SELECT * FROM tbl_dealers WHERE dealerName LIKE '" + str + "%' AND deleteFlg != '1'";
                }
                else if (type == 3)
                {
                    querry = "SELECT * FROM tbl_dealers WHERE companyName LIKE '" + str + "%' AND deleteFlg != '1'";
                }
                else
                {
                    querry = "SELECT * FROM tbl_dealers WHERE deleteFlg != '1';";
                }

                dt = CONN.getDataTable(querry);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getDestinationWhileSearching(int type, string str)
        {
            DataTable dt = new DataTable();
            string querry = string.Empty;
            try
            {
                if (type == 2)
                {
                    querry = "SELECT * FROM tbl_destinations WHERE destinationName LIKE '" + str + "%' AND deleteFlg != '1'";
                }
                else if (type == 3)
                {
                    querry = "SELECT * FROM tbl_destinations WHERE ownerName LIKE '" + str + "%' AND deleteFlg != '1'";
                }
                else
                {
                    querry = "SELECT * FROM tbl_destinations WHERE deleteFlg != '1';";
                }

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getAssetWhileSearching(int type, string str)
        {
            DataTable dt = new DataTable();
            string querry = string.Empty;
            try
            {
                if (type == 2)
                {
                    querry = "SELECT * FROM tbl_assets WHERE assetName LIKE '" + str + "%' AND deleteFlg != '1'";
                }                
                else
                {
                    querry = "SELECT * FROM tbl_assets WHERE deleteFlg != '1';";
                }

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getUnitWhileSearching(int type, string str)
        {

            DataTable dt = new DataTable();
            string querry = string.Empty;
            try
            {
                if (type == 2)
                {
                    querry = "SELECT * FROM tbl_units WHERE description LIKE '" + str + "%' AND deleteFlg != '1'";
                }
                else
                {
                    querry = "SELECT * FROM tbl_units WHERE deleteFlg != '1';";
                }

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public DataTable getItemWhileSearching(int type, string str)
        {
            DataTable dt = new DataTable();
            string querry = string.Empty;
            try
            {
                if (type == 2)
                {
                    querry = @"SELECT * FROM vw_item WHERE itemCode LIKE '" + str + "%' AND deleteFlg != '1'";
                    
                }
                else if (type == 3)
                {
                    querry = @"SELECT * FROM vw_item WHERE itemName LIKE '" + str + "%' AND deleteFlg != '1'";
                }
                else
                {
                    querry = @"SELECT * FROM vw_item WHERE deleteFlg != '1'";
                }

                dt = CONN.getDataTable(querry);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public bool isItemCodeExists(string code)
        {
            bool isExists = false;
            int cnt = 0;

            try
            {
                string querry = "SSELECT COUNT(*) FROM tbl_item WHERE itemCode = '" + code + "';";
                cnt = CONN.getPrefix(querry);

                if(cnt > 0)
                {
                    isExists = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return isExists;
        }
    }
}
