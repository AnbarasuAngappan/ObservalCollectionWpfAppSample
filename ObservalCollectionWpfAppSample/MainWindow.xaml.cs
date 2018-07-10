using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObservalCollectionWpfAppSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Details> details;
        //private ObservableCollection<MyClassEmpProperty> myClassEmpProperties;
        private EmpDetails empDetails;

        public MainWindow()
        {
            InitializeComponent();
            details = new ObservableCollection<Details>()
            {
                new Details() { Name = "John",Position = "Software Developer", Gender="Male",Age=25, Address = "India",City="Hyd",EmailID="John@yahoo.com",ContactNo = 9600688497 },
                new Details() { Name = "Marry",Position = "Testing Engineer", Gender="female",Age=28, Address = "India",City="Chennai",EmailID="Marry@gmail.com",ContactNo = 9159692124  }
                };
         //   lstNames.ItemsSource = details;
            dataGridStudent.ItemsSource = details;
        }


        #region Events

        //private void lstNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (lstNames.SelectedItem != null)
        //        {
        //            txtName.Text = (lstNames.SelectedItem as Details).Name;
        //            txtPosition.Text = (lstNames.SelectedItem as Details).Position;
        //            txtGender.Text = (lstNames.SelectedItem as Details).Gender;
        //            txtAge.Text = Convert.ToString((lstNames.SelectedItem as Details).Age);
        //            txtAddress.Text = (lstNames.SelectedItem as Details).Address;
        //            txtCity.Text = (lstNames.SelectedItem as Details).City;
        //            txtEmailID.Text = (lstNames.SelectedItem as Details).EmailID;
        //            txtContactNo.Text = Convert.ToString((lstNames.SelectedItem as Details).ContactNo);
        //        }
        //        else
        //            MessageBox.Show("No Item are slelected......");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}

        private void dataGridStudent_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void dataGridStudent_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void dataGridStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Details details;
            try
            {
                details = dataGridStudent.SelectedItem as Details;
                if (details != null)
                {
                    if ((details).Name.Length > 0)
                    {
                        txtName.Text = details.Name;//(dataGridStudent.SelectedItem as Details).Name;
                        txtPosition.Text = details.Position;//(dataGridStudent.SelectedItem as Details).Position;
                        txtGender.Text = details.Gender;//(dataGridStudent.SelectedItem as Details).Gender;
                        txtAge.Text = Convert.ToString((dataGridStudent.SelectedItem as Details).Age);
                        txtAddress.Text = details.Address;//(dataGridStudent.SelectedItem as Details).Address;
                        txtCity.Text = details.City;//(dataGridStudent.SelectedItem as Details).City;
                        txtEmailID.Text = details.EmailID;//(dataGridStudent.SelectedItem as Details).EmailID;
                        txtContactNo.Text = Convert.ToString((dataGridStudent.SelectedItem as Details).ContactNo);
                    }
                    else
                    {

                    }
                }
                else
                    MessageBox.Show("No Item are slelected......","Warining", MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                details = null;
            }

        }

        private void datagridbrowseitems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyClassEmpProperty myClassEmpProperty;
            try
            {
                myClassEmpProperty = datagridbrowseitems.SelectedItem as MyClassEmpProperty;
                if (myClassEmpProperty != null)//datagridbrowseitems.SelectedItem != null
                {
                    txtName.Text = (datagridbrowseitems.SelectedItem as MyClassEmpProperty).EmpName;
                    txtPosition.Text = (datagridbrowseitems.SelectedItem as MyClassEmpProperty).EmpPosition;
                    txtGender.Text = (datagridbrowseitems.SelectedItem as MyClassEmpProperty).EmpGender;
                    txtAge.Text = Convert.ToString((datagridbrowseitems.SelectedItem as MyClassEmpProperty).EmpAge);
                    txtAddress.Text = (datagridbrowseitems.SelectedItem as MyClassEmpProperty).EmpAddress;
                    txtCity.Text = (datagridbrowseitems.SelectedItem as MyClassEmpProperty).EmpCity;
                    txtEmailID.Text = (datagridbrowseitems.SelectedItem as MyClassEmpProperty).EmpEmailID;
                    txtContactNo.Text = Convert.ToString((datagridbrowseitems.SelectedItem as MyClassEmpProperty).EmpContactNo);
                }
                else
                    MessageBox.Show("No Item are slelected......", "Warining", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            //try
            //{
            //    if (txtName.Text != null && txtPosition.Text != null && txtGender.Text != null && txtAge != null
            //       && txtAddress != null && txtCity != null && txtEmailID.Text != null && txtContactNo.Text != null &&
            //       txtName.Text.Length > 0 && txtPosition.Text.Length > 0 && txtGender.Text.Length > 0 && txtAge.Text.Length > 0 &&
            //       txtAddress.Text.Length > 0 && txtCity.Text.Length > 0 && txtEmailID.Text.Length > 0 && txtContactNo.Text.Length > 0)
            //    {

            //        myClassEmpProperties.Add(new MyClassEmpProperty
            //        {
            //            EmpName = txtName.Text,
            //            EmpPosition = txtPosition.Text,
            //            EmpGender = txtGender.Text,
            //            EmpAge = txtAge.Text,
            //            EmpCity = txtCity.Text,
            //            EmpEmailID = txtEmailID.Text,
            //            EmpContactNo = txtContactNo.Text
            //        });               



            //        txtName.Text = null;
            //        txtPosition.Text = null;
            //        txtGender.Text = null;
            //        txtAge.Text = null;
            //        txtAddress.Text = null;
            //        txtCity.Text = null;
            //        txtEmailID.Text = null;
            //        txtContactNo.Text = null;
            //        txtAddress.Text = null;
            //    }
            //    else
            //        MessageBox.Show("Fields Should Not be empty....", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }

        }

        #endregion

        #region ClickEvents

        private void btnNames_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != null && txtPosition.Text != null && txtGender.Text != null && txtAge != null
                && txtAddress != null && txtCity != null && txtEmailID.Text != null && txtContactNo.Text != null &&
                txtName.Text.Length > 0 && txtPosition.Text.Length > 0 && txtGender.Text.Length > 0 && txtAge.Text.Length > 0 && 
                txtAddress.Text.Length > 0 && txtCity.Text.Length > 0 && txtEmailID.Text.Length > 0 && txtContactNo.Text.Length > 0)
            {
                details.Add(new Details { Name = txtName.Text,
                                            Position = txtPosition.Text,
                                            Gender = txtGender.Text,
                                            Age = Convert.ToInt32(txtAge.Text),
                                            Address = txtAddress.Text,
                                            City = txtCity.Text,
                                            EmailID = txtEmailID.Text,
                                            ContactNo = Convert.ToInt64(txtContactNo.Text) });
                txtName.Text = null;
                txtPosition.Text = null;
                txtGender.Text = null;
                txtAge.Text = null;
                txtAddress.Text = null;
                txtCity.Text = null;
                txtEmailID.Text = null;
                txtContactNo.Text = null;
                txtAddress.Text = null;
            }                
            else
                MessageBox.Show("Fields Should Not be empty....","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);        

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            file.Filter = "(*.xls)|*.xls";//|All files (*.*)|*.*
            fileExt = file.Filter;
            if (file.ShowDialog() == true)
            {
                filePath = file.FileName;                              
                if (fileExt.CompareTo("(*.xls)|*.xls") == 0 || fileExt.CompareTo("(*.xlsx)|*.xlsx") == 0)
                {
                    try
                    {
                        // DataTable dtExcel = new DataTable();
                        // dtExcel = ReadExcel(filePath, fileExt); //read excel file      
                        dataGridStudent.Visibility = Visibility.Collapsed;
                        empDetails = new EmpDetails(filePath);
                        datagridbrowseitems.ItemsSource = empDetails.ReadRecordFromEXCELAsync().Result;                       
                        datagridbrowseitems.Visibility = Visibility.Visible;
                        lblHeader.Content = "Showing XLS File Details...";
                        //dataGridStudent.HeadersVisibility = DataGridHeadersVisibility.None;
                        //datagridbrowseitems.ItemsSource = dtExcel.DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButton.OK, MessageBoxImage.Error); //custom messageBox to show error  
                }
            }
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
                    oleAdpt.FillSchema(dtexcel, SchemaType.Source);
                    oleAdpt.Fill(dtexcel);
                    //oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch
                {

                }
            }
            return dtexcel;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtName.Text = null;
                txtPosition.Text = null;
                txtGender.Text = null;
                txtAge.Text = null;
                txtAddress.Text = null;
                txtCity.Text = null;
                txtEmailID.Text = null;
                txtContactNo.Text = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        #endregion

        public class Details : INotifyPropertyChanged
        {
            private string name;
            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    if (this.name != value)
                    {
                        this.name = value;
                        this.NotifyPropertyChanged("Name");
                    }
                }
            }

            //public string Name { get; set; }
            public string Position { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string EmailID { get; set; }
            public long ContactNo { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }

        }

        
    }

}
