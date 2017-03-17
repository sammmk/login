﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UserManage.BLL
{
    public class ClsUserManageDbChanges
    {
        private CommonControls.Classes.dbConnection CONN;
        private CommonControls.Classes.ClsCommonMethods COMMON;

        public ClsUserManageDbChanges()
        {
            CONN = new CommonControls.Classes.dbConnection();
            COMMON = new CommonControls.Classes.ClsCommonMethods();
        }

        public int getMaxUserID()
        {
            int maxUserId = 0;

            try
            {
                string querry = "SELECT MAX(userId) from tbl_login;";
                maxUserId = getMaxId(querry);

                //1000 for company Id or something like that : add only for the first value   
                if (maxUserId <= 1)
                    maxUserId += 1000;
            }
            catch (Exception e)
            {
                throw e;
            }

            return maxUserId;
        }

        public int getMaxUserRoleId()
        {
            int maxRoleId = 0;

            try
            {
                string querry = "SELECT MAX(userRoleId) from tbl_userrole;";
                maxRoleId = getMaxId(querry);                
            }
            catch (Exception e)
            {
                throw e;
            }

            return maxRoleId;
        }

        private int getMaxId(string querry)
        {
            int ret = 0;
            int temp = ret;

            try
            {
                if (CONN.openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(querry, CONN.CONNECTION);
                    temp = Convert.ToInt16(cmd.ExecuteScalar());

                    CONN.closeConnection();

                    if(temp <= 0)
                    {
                        ret = 0;
                    }
                    else
                    {
                        ret = temp + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public DataTable getUserRoleList()
        {
            DataTable dt = new DataTable();

            try
            {
                if (CONN.openConnection())
                {
                    string querry = "SELECT * FROM tbl_userrole;";
                    MySqlCommand cmd = new MySqlCommand(querry, CONN.CONNECTION);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);

                    CONN.closeConnection();
                }
            }
            catch (Exception ex)
            {
                dt = null;
                throw ex;
            }

            return dt;
        }

        public bool InsertData_userDetail(ClsUserManageData UserData)
        {
            bool ret = false;
            string insertToUserDetail = string.Empty;
            string insertToLogin = string.Empty;

            try
            {
                //create querry for tbl_userdetail
                insertToUserDetail = "INSERT INTO tbl_userdetail ( userId, userName, firstName, lastName, dob, NIC, address, email, roleId, phoneNo ) VALUES ( ";
                insertToUserDetail += "'" + UserData._userId + "',";
                insertToUserDetail += "'" + UserData._userName + "',";
                insertToUserDetail += "'" + UserData._firstName + "',";
                insertToUserDetail += "'" + UserData._lastName + "',";
                insertToUserDetail += "'" + UserData._dob + "',";
                insertToUserDetail += "'" + UserData._idNumber + "',";
                insertToUserDetail += "'" + UserData._address + "',";
                insertToUserDetail += "'" + UserData._email + "',";
                insertToUserDetail += "'" + UserData._roleId + "',";
                insertToUserDetail += "'" + UserData._phoneNo;
                insertToUserDetail += "');";

                //create querry for tbl_login
                insertToLogin = "INSERT INTO tbl_login ( userName, passWord, userId, roleId ) VALUES ( ";
                insertToLogin += "'" + UserData._userName + "',";
                insertToLogin += "'" + COMMON.EncodePassword(UserData._userName) + "',";
                insertToLogin += "'" + UserData._userId + "',";
                insertToLogin += "'" + UserData._userId;
                insertToLogin += "');";

                if(update(insertToUserDetail))
                {
                    if (update(insertToLogin))
                    {
                        ret = true;
                    }
                }
            }
            catch(Exception e)
            {
                ret = false;
                throw e;
            }
            return ret;
        }

        public bool updateData_userDetail(ClsUserManageData UserData)
        {
            bool ret = false;

            try
            {
                string updateUserDetail = string.Empty;

                updateUserDetail = "UPDATE tbl_userdetail SET ";
                updateUserDetail += "firstName = '" + UserData._firstName + "',";
                updateUserDetail += "lastName = '" + UserData._lastName + "',";
                updateUserDetail += "dob = '" + UserData._dob + "',";
                updateUserDetail += "NIC = '" + UserData._idNumber + "',";
                updateUserDetail += "address ='" + UserData._address + "',";//, , 
                updateUserDetail += "email = '" + UserData._email + "',";
                updateUserDetail += "roleId = '" + UserData._roleId+ "',";
                updateUserDetail += "phoneNo = '" + UserData._phoneNo + "'";
                updateUserDetail += "WHERE userId = '" + UserData._userId + "';";

                ret = update(updateUserDetail);

                //if (CONN.openConnection() == true)
                //{
                //    MySqlCommand cmd = new MySqlCommand(updateUserDetail, CONN.CONNECTION);
                //    cmd.ExecuteNonQuery();

                //    CONN.closeConnection();

                //    ret = true;
                //}
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public bool insertData_userRole(int roleId, string role)
        {
            bool ret = false;
            string userRole = string.Empty;

            try
            {
                userRole = "INSERT INTO tbl_userrole (userRoleName, userRoleId) VALUES (";
                userRole += "'" + userRole + "',";
                userRole += "'" + roleId;
                userRole += "');";

                ret = update(userRole);
            }
            catch(Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        //private bool Insert(string insertQuerry)
        //{
        //    bool ret = false;

        //    try
        //    {
        //        if (CONN.openConnection() == true)
        //        {
        //            MySqlCommand cmd = new MySqlCommand(insertQuerry, CONN.CONNECTION);
        //            cmd.ExecuteNonQuery();

        //            CONN.closeConnection();

        //            ret = true;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        ret = false;
        //        throw ex;
        //    }
        //    return ret;
        //}

        public DataTable getUserDetails()
        {
            DataTable dt = new DataTable();

            try
            {
                string querry = "SELECT * FROM tbl_userdetail WHERE deleteFlg != 1;";

                if(CONN.openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(querry, CONN.CONNECTION);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dt);

                    CONN.closeConnection();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public ClsUserManageData getSingleUserData(int userId)
        {
            ClsUserManageData userData = new ClsUserManageData();

            try
            {
                string querry = "SELECT * FROM tbl_userdetail WHERE userId = '" + userId + "';";

                if (CONN.openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(querry, CONN.CONNECTION);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    //cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    userData._userId = Convert.ToInt16(dt.Rows[0]["userId"].ToString());
                    userData._userName = dt.Rows[0]["userName"].ToString();
                    userData._firstName = dt.Rows[0]["firstName"].ToString();
                    userData._lastName = dt.Rows[0]["lastName"].ToString();
                    userData._dob = Convert.ToDateTime(dt.Rows[0]["dob"].ToString());
                    userData._idNumber = dt.Rows[0]["NIC"].ToString();
                    userData._address = dt.Rows[0]["address"].ToString();
                    userData._email = dt.Rows[0]["email"].ToString();
                    userData._roleId = Convert.ToInt16(dt.Rows[0]["roleId"].ToString());
                    userData._phoneNo = dt.Rows[0]["phoneNo"].ToString();

                    CONN.closeConnection();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return userData;
        }

        public bool deleteUser(int userId)
        {
            bool ret = false;
            string q = string.Empty;
            string qq = string.Empty;

            try
            {
                q = "UPDATE tbl_userdetail SET deleteFlg = '1' WHERE userId = '" + userId + "';";
                ret = update(q);

                qq = "UPDATE tbl_login SET deleteFlg = '1' WHERE userId = '" + userId + "';";
                ret = update(qq);
            }
            catch(Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }

        public bool update(string querry)
        {
            bool ret = false;

            try
            {
                if(CONN.openConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(querry, CONN.CONNECTION);
                    cmd.ExecuteNonQuery();

                    CONN.closeConnection();
                    ret = true;
                }
            }
            catch(Exception ex)
            {
                ret = false;
                throw ex;
            }
            return ret;
        }
    }
}
