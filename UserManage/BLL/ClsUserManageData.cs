﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManage.BLL
{
    public class ClsUserManageData
    {
        public int _userId { get; set; }
        public string _userName { get; set; }
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public string _idNumber { get; set; }
        public string _email { get; set; }
        public string _userRole { get; set; }
        public string _phoneNo { get; set; }
        public string _address { get; set; }
        public DateTime _dob { get; set; }
        public int _roleId { get; set; }
    }

}
