using FinalProjectWP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FinalProjectWP
{
    /// <summary>
    /// Interaction logic for MemberGUI.xaml
    /// </summary>
    public partial class MemberGUI : Window
    {
        public MemberGUI()
        {
            InitializeComponent();
            laboratory = new LaboratoryContext();
            member = new MemberInfo();
            member = laboratory.MemberInfo.FromSqlRaw("EXECUTE dbo.sp_ShowPersonalInfo {0}", "Ch03").ToList()[0];
            member.LoginInfo = laboratory.LoginInfo.First(x => x.MemId == member.Id);
            position = laboratory.Position.ToList();
            //Ldepartments = new List<Department>();//laboratory.Department.ToList();
            //lab = laboratory.LabInfo.ToList()[0];
            member.Pos = position.First(x => x.Id == member.PosId);
            tabinfo.DataContext = member;
            memberpicture.DataContext = member;
            image_login.DataContext = member;
            membernamebox.DataContext = member;
            var labinfo = laboratory.LabInfo.FromSqlRaw("EXECUTE dbo.sp_ShowLabInfo").ToList();
            tablab.DataContext = labinfo;
            //participations = laboratory.Participation.ToList();
            //for (int i = 0; i < Ldepartments.Count(); i++)
            //{
            //    Ldepartments[i].MemberInfo = laboratory.MemberInfo.Where(x => x.Id == Ldepartments[i].LeaderId).ToList();
            //}
            var deptinfo = laboratory.Department.FromSqlRaw("EXECUTE dbo.sp_ShowDepInfo").ToList();
           
            labdepartment.ItemsSource = deptinfo;
            //participations = laboratory.Participation.ToList();
            //if (participations.Exists(x => x.MemId == member.Id))
           // {
                //Participation = participations.Where(x => x.MemId == member.Id).ToList();
                Lexperiments = new List<Experiment>();
                //for (int i = 0; i < Participation.Count; i++)
                //{
                //    Experiment a = laboratory.Experiment.First(x => x.Id == Participation[i].ExpId);
                //    Lexperiments.Add(a);

                //}
                Lexperiments = laboratory.Experiment.FromSqlRaw("EXECUTE dbo.sp_ShowExpInfo {0}", member.Id).ToList();
                project_experiments.ItemsSource = Lexperiments;
               
                var abc =laboratory.MemberInfo.FromSqlRaw("EXECUTE dbo.sp_ShowParticipantsInExp {0}", member.Id).ToList();
            //for (int i = 0; i < Lexperiments.Count(); i++)
            //{
            //    Lexperiments[i].Leader = laboratory.MemberInfo.First(x => x.Id == Lexperiments[i].LeaderId);
            //    Lexperiments[i].Participation = abc.Where(x => x.ExpId == Lexperiments[i].Id).ToList();
            //    Lexperiments[i].Finished = laboratory.Finished.First(x => x.ExpId == Lexperiments[i].Id);
            //    //Lexperiments[i].progress_time();
            //    for (int j = 0; j < Lexperiments[i].Participation.Count; j++)
            //    {
            //        Lexperiments[i].Participation.ElementAt(j).Mem = laboratory.MemberInfo.First(x => x.Id == Lexperiments[i].Participation.ElementAt(j).MemId);
            //    }
            //}
            int m = 0;
            for(int i=0;i<Lexperiments.Count();i++)
            {
                Lexperiments[i].Leader = laboratory.MemberInfo.First(x => x.Id == Lexperiments[i].LeaderId);
                Lexperiments[i].Finished = laboratory.Finished.First(x => x.ExpId == Lexperiments[i].Id);
                for (int j = 0; j < Lexperiments[i].Participants; j++)
                    {
                    Lexperiments[i].Participation.Add(new Participation());
                    Lexperiments[i].Participation.ElementAt(j).Mem = abc[m++];
                    }
            }
            //}
        }
        public MemberGUI(string id)
        {
            InitializeComponent();
            laboratory = new LaboratoryContext();
            member = new MemberInfo();
            member = laboratory.MemberInfo.FromSqlRaw("EXECUTE dbo.sp_ShowPersonalInfo {0}", id).ToList()[0];
            member.LoginInfo = laboratory.LoginInfo.First(x => x.MemId == member.Id);
            position = laboratory.Position.ToList();
            //Ldepartments = new List<Department>();//laboratory.Department.ToList();
            //lab = laboratory.LabInfo.ToList()[0];
            member.Pos = position.First(x => x.Id == member.PosId);
            tabinfo.DataContext = member;
            memberpicture.DataContext = member;
            image_login.DataContext = member;
            membernamebox.DataContext = member;
            var labinfo = laboratory.LabInfo.FromSqlRaw("EXECUTE dbo.sp_ShowLabInfo").ToList();
            tablab.DataContext = labinfo;
            //participations = laboratory.Participation.ToList();
            //for (int i = 0; i < Ldepartments.Count(); i++)
            //{
            //    Ldepartments[i].MemberInfo = laboratory.MemberInfo.Where(x => x.Id == Ldepartments[i].LeaderId).ToList();
            //}
            var deptinfo = laboratory.Department.FromSqlRaw("EXECUTE dbo.sp_ShowDepInfo").ToList();

            labdepartment.ItemsSource = deptinfo;
            //participations = laboratory.Participation.ToList();
            //if (participations.Exists(x => x.MemId == member.Id))
            // {
            //Participation = participations.Where(x => x.MemId == member.Id).ToList();
            Lexperiments = new List<Experiment>();
            //for (int i = 0; i < Participation.Count; i++)
            //{
            //    Experiment a = laboratory.Experiment.First(x => x.Id == Participation[i].ExpId);
            //    Lexperiments.Add(a);

            //}
            Lexperiments = laboratory.Experiment.FromSqlRaw("EXECUTE dbo.sp_ShowExpInfo {0}", member.Id).ToList();
            project_experiments.ItemsSource = Lexperiments;
            
            var abc = laboratory.MemberInfo.FromSqlRaw("EXECUTE dbo.sp_ShowParticipantsInExp {0}", member.Id).ToList();
            //for (int i = 0; i < Lexperiments.Count(); i++)
            //{
            //    Lexperiments[i].Leader = laboratory.MemberInfo.First(x => x.Id == Lexperiments[i].LeaderId);
            //    Lexperiments[i].Participation = abc.Where(x => x.ExpId == Lexperiments[i].Id).ToList();
            //    Lexperiments[i].Finished = laboratory.Finished.First(x => x.ExpId == Lexperiments[i].Id);
            //    //Lexperiments[i].progress_time();
            //    for (int j = 0; j < Lexperiments[i].Participation.Count; j++)
            //    {
            //        Lexperiments[i].Participation.ElementAt(j).Mem = laboratory.MemberInfo.First(x => x.Id == Lexperiments[i].Participation.ElementAt(j).MemId);
            //    }
            //}
            int m = 0;
            for (int i = 0; i < Lexperiments.Count(); i++)
            {
                Lexperiments[i].Leader = laboratory.MemberInfo.First(x => x.Id == Lexperiments[i].LeaderId);
                Lexperiments[i].Finished = laboratory.Finished.First(x => x.ExpId == Lexperiments[i].Id);
                for (int j = 0; j < Lexperiments[i].Participants; j++)
                {
                    Lexperiments[i].Participation.Add(new Models.Participation());
                    Lexperiments[i].Participation.ElementAt(j).Mem = abc[m++];
                }
            }
        }
        private MemberInfo member { get; set; }
        private List<Position> position { get; set; }
        private LaboratoryContext laboratory { get; set; }
        private Department department { get; set; }
        private Equipment equipment { get; set; }
        private List<Experiment> experiment { get; set; }
        private LabInfo lab { get; set; }
        private List<Department> Ldepartments { get; set; }
        private DataGridRow dataGridRow { get; set; }
        private DataGridDetailsPresenter presenter { get; set; }
        private DataTemplate myDataTemplate { get; set; }
        private List<Experiment> Lexperiments { get; set; }
        private List<Participation> participations { get; set; }
        private List<Participation> Participation { get; set; }


        private void closebtn_PreviewMouseDown(object sender, MouseButtonEventArgs bc)
        {
            for (int i = 0; i < Lexperiments.Count(); i++)
            {
                Lexperiments[i].Leader = laboratory.MemberInfo.First(x => x.Id == Lexperiments[i].LeaderId);
                Lexperiments[i].Finished = laboratory.Finished.First(x => x.ExpId == Lexperiments[i].Id);
                for (int j = 0; j < Lexperiments[i].Participants; j++)
                {
                    Lexperiments[i].Participation.Add(new Participation());
                    Lexperiments[i].Participation.Remove(Lexperiments[i].Participation.ElementAt(j));
                }
            }
            var id = new SqlParameter("@id", member.Id);
            var e = new SqlParameter("@e", member.Email);
            var p = new SqlParameter("@p", member.Phone);

            laboratory.Database.ExecuteSqlCommand("EXECUTE dbo.sp_EditEmailandPhone @id,@e,@p", id, e, p);
            //laboratory.SaveChanges();
            Login login = new Login();
            login.Show();
            SystemCommands.CloseWindow(this);
        }
        private void maximizebtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                SystemCommands.RestoreWindow(this);
            }
            else SystemCommands.MaximizeWindow(this);
        }

        private void minimizebtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try { this.DragMove(); }
            catch (System.InvalidOperationException)
            {
                return;
            }

        }

        private void detailbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            labdepartment.Visibility = Visibility.Visible;
            detailsclosebtn.Visibility = Visibility.Visible;
        }

        private void detailsclosebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            labdepartment.Visibility = Visibility.Hidden;
            detailsclosebtn.Visibility = Visibility.Hidden;


        }

        private void details_rowtemplate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dataGridRow = (DataGridRow)(labdepartment.ItemContainerGenerator.ContainerFromItem(labdepartment.SelectedItem));
            Department department = dataGridRow.Item as Department;
            presenter = FindVisualChild<DataGridDetailsPresenter>(dataGridRow);
            myDataTemplate = presenter.ContentTemplate;
            TextBlock myTextBlock = (TextBlock)myDataTemplate.FindName("close_template", presenter);
            myTextBlock.Visibility = Visibility.Visible;
            DataGrid dataGrid = (DataGrid)myDataTemplate.FindName("Deptinfo_in_lab", presenter);
            dataGrid.Visibility = Visibility.Visible;
            List<MemberInfo> memberInfo = new List<MemberInfo>();
            //memberInfo = laboratory.MemberInfo.Where(x => x.DepId == department.Id).ToList();
            var memberdeptinfo = laboratory.MemberInfo.FromSqlRaw("EXECUTE dbo.sp_ShowMemberInDep {0}", department.Id).ToList();
            dataGrid.ItemsSource = memberdeptinfo;

        }

        private void close_template_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dataGridRow = (DataGridRow)(labdepartment.ItemContainerGenerator.ContainerFromItem(labdepartment.SelectedItem));

            presenter = FindVisualChild<DataGridDetailsPresenter>(dataGridRow);
            myDataTemplate = presenter.ContentTemplate;
            TextBlock textBlock = (TextBlock)myDataTemplate.FindName("close_template", presenter);
            textBlock.Visibility = Visibility.Hidden;
            DataGrid dataGrid = (DataGrid)myDataTemplate.FindName("Deptinfo_in_lab", presenter);
            dataGrid.Visibility = Visibility.Hidden;
        }
        private childItem FindVisualChild<childItem>(DependencyObject obj)
    where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        private void project_experiments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        //This is the code which helps to show the data when the row is double clicked.
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        Experiment a = (Experiment)dgr.Item;
                        listequipment listequipment = new listequipment(a.Id);
                        listequipment.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void project_experiments_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        //dgr.DetailsVisibility = Visibility.Collapsed;
                        dgr.IsSelected = false;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void ChangeImangebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(op.FileName));
                image_login.Source = bitmapImage;
                memberbrush.ImageSource = bitmapImage;
                byte[] vs = File.ReadAllBytes(op.FileName);
                member.ProfilePic = vs;
                laboratory.SaveChanges();
            }
        }

        private void Save_password_Click(object sender, RoutedEventArgs e)
        {
            if (oldpass.Password != member.LoginInfo.Password)
            {
                MessageBox.Show("Old password incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                oldpass.Focus();
                return;
            }
            else if (confirmpass.Password != newpass.Password)
            {
                MessageBox.Show("Confirm password incorrrect", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                confirmpass.Focus();
                return;
            }
            else
            {
                MessageBox.Show("Password changed", "Success", MessageBoxButton.OK);
                var id = new SqlParameter("@id", member.Id);
                var p = new SqlParameter("@p", newpass.Password);

                laboratory.Database.ExecuteSqlCommand("EXECUTE dbo.sp_UpdatePassword @id,@p"
                    , id,p);
                var listeq = laboratory.Equipment.FromSqlRaw("SELECT * FROM dbo.Equipment").ToList();
                laboratory.SaveChanges();
            }
        }

        private void oldpass_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (oldpass.Password != "")
                oldpass.Password = "";
        }

        private void newpass_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (newpass.Password != "")
                newpass.Password = "";
        }

        private void confirmpass_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (confirmpass.Password != "")
                confirmpass.Password = "";
        }
    }
    public class DateToStringConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;
            int a = (DateTime.Now - dateTime).Days;
            return a;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    public class overdue : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value) > 100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class overdue_string : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value > 100)
            {

                return "overdue";
            }
            else return (value.ToString() + "%");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
