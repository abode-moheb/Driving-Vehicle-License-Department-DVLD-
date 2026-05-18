using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BussinessLayer
{
    public class clsManageTestTypes
    {

        clsManageTestTypes(int TestID, string TestTitle, string TestDescription, int TestFees)
        {
            this.TestID = TestID;
            this.TestTitle = TestTitle;
            this.TestDescription = TestDescription;
            this.TestFees = TestFees;
        }


        public int TestID { set; get; }
        public string TestTitle { set; get; }
        public string TestDescription { set; get; }
        public int TestFees { set; get; }



        static public DataTable LoadTestTypesTable()
        {
            return clsManageTestTypesData.LoadTestTypesTable();
        }

        static public clsManageTestTypes FindTest(int TestID)
        {
            string TestTitle = "";
            string TestDescription = "";
            int TestFees = 0;

            if (clsManageTestTypesData.FindTest(TestID, ref TestTitle, ref TestDescription, ref TestFees))
            {
                return new clsManageTestTypes(TestID, TestTitle, TestDescription, TestFees);
            }
            else
                return null;
        } 

        bool _UpdateTestTypes()
        {
            return clsManageTestTypesData._UpdateTestTypes(this.TestID, this.TestTitle, this.TestDescription, this.TestFees);
        }

        public bool Save()
        {
            return _UpdateTestTypes();
        }

    }
}
