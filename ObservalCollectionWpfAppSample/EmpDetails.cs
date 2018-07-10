using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservalCollectionWpfAppSample
{
    class MyClassEmpProperty
    {
        public string EmpName
        { get; set; }
        public string EmpPosition
        { get; set; }
        public string EmpGender
        { get; set; }
        public string EmpAge
        { get; set; }
        public string EmpAddress
        { get; set; }
        public string EmpCity
        { get; set; }
        public string EmpEmailID
        { get; set; }
        public string EmpContactNo
        { get; set; }
    }

    class EmpDetails
    {
        OleDbConnection Conn;
        OleDbCommand Cmd;

        public EmpDetails(string filepath)
        {
            string ExcelFilePath = filepath;
            string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelFilePath + ";Extended Properties=Excel 12.0;Persist Security Info=True";
            Conn = new OleDbConnection(excelConnectionString);
        }

        public async Task<ObservableCollection<MyClassEmpProperty>> ReadRecordFromEXCELAsync()
        {
            ObservableCollection<MyClassEmpProperty> myClassEmpProperty = new ObservableCollection<MyClassEmpProperty>();
            await Conn.OpenAsync();
            Cmd = new OleDbCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from [Sheet1$]";
            var Reader = await Cmd.ExecuteReaderAsync();
            while (Reader.Read())
            {
                myClassEmpProperty.Add(new MyClassEmpProperty()
                {
                    EmpName = Reader["EmpName"].ToString(),
                    EmpPosition = Reader["EmpPosition"].ToString(),
                    EmpGender = Reader["EmpGender"].ToString(),
                    EmpAge = Reader["EmpAge"].ToString(),
                    EmpAddress = Reader["EmpAddress"].ToString(),
                    EmpCity = Reader["EmpCity"].ToString(),
                    EmpEmailID = Reader["EmpEmailID"].ToString(),
                    EmpContactNo = Reader["EmpContactNo"].ToString()
                });
            }
            Reader.Close();
            Conn.Close();
            return myClassEmpProperty;
        }
    }
}
