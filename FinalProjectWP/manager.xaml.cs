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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FinalProjectWP
{
    /// <summary>
    /// Interaction logic for manager.xaml
    /// </summary>
    public partial class manager : Window
    {
        public manager()
        {
            InitializeComponent();
            laboratory = new LaboratoryContext();
            listmember = laboratory.MemberInfo.FromSqlRaw("SELECT * FROM dbo.MemberInfo").ToList();
            table_member.ItemsSource = listmember;
            listeq = laboratory.Equipment.FromSqlRaw("SELECT * FROM dbo.Equipment").ToList();
            ListEquipment.ItemsSource = listeq;
            laboratory.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        private LaboratoryContext laboratory { get; set; }
        private List<MemberInfo> listmember { get; set; }
        private List<Equipment> listeq { get; set; }
        private void searchbtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < table_member.Items.Count-1; i++)
            {
                var a = (MemberInfo)table_member.Items[i];
                if (a.Name.Equals(searchbox.Text))
                {
                    table_member.SelectedIndex = i;
                    table_member.ScrollIntoView(table_member.SelectedItem);
                }
            }
        }
        private BitmapImage BitmapImage { get; set; }
        byte[] vs { get; set; }
        private void imagebtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                BitmapImage = new BitmapImage(new Uri(op.FileName));
                imagem.Source = BitmapImage;
                vs = File.ReadAllBytes(op.FileName);
            }
        }

        private void equtbn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ListEquipment.Items.Count - 1; i++)
            {
                var a = (Equipment)ListEquipment.Items[i];
                if (a.Name.Equals(searchbox_equ.Text))
                {
                    ListEquipment.SelectedIndex = i;
                    ListEquipment.ScrollIntoView(ListEquipment.SelectedItem);
                }
            }
        }

        private void Savem_Click(object sender, RoutedEventArgs e)
        {
            var name = new SqlParameter("@name", Namebox.Text);
            var pos= new SqlParameter("@pos", Posbox.SelectedItem.ToString().Remove(0, 38));
            var dep = new SqlParameter("@dep", Depbox.SelectedItem.ToString().Remove(0, 38));
            var by = new SqlParameter("@by",Convert.ToInt32( Birthbox.Text));
            var email= new SqlParameter("@email", Emailbox.Text);
            var phone = new SqlParameter("@phone", Phonebox.Text);
            var gd = new SqlParameter("@gd", Gendebox.Text);
             var slr = new SqlParameter("@slr",float.Parse( Salarybox.Text));
            var pp = new SqlParameter("@pp", vs);
            try
            {
                laboratory.Database.ExecuteSqlCommand("EXECUTE dbo.sp_AddMember @name,@pos,@dep,@by,@email,@phone,@gd,@slr,@pp"
                     , name, pos, dep, by, email, phone, gd, slr, pp);
                listmember = laboratory.MemberInfo.FromSqlRaw("SELECT * FROM dbo.MemberInfo").ToList();
                table_member.ItemsSource = listmember;
                table_member.Items.Refresh();
            }
            catch (Microsoft.Data.SqlClient.SqlException  a)
            {
                MessageBox.Show(a.Message, "error", MessageBoxButton.OK);
                return;
            }

        }
        private void equtbn_add_Click(object sender, RoutedEventArgs e)
        {
            var name = new SqlParameter("@name", searchbox_equ.Text);
            var q = new SqlParameter("@q",Convert.ToInt32( addequbox.Text));
            try
            {
                laboratory.Database.ExecuteSqlCommand("EXECUTE dbo.sp_AddEqmQuantity @name,@q"
                   , name, q);
                listeq = laboratory.Equipment.FromSqlRaw("SELECT * FROM dbo.Equipment").ToList();
                ListEquipment.ItemsSource = listeq;
                ListEquipment.Items.Refresh();
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                return;
            }


        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var a = table_member.SelectedItem as MemberInfo;
            var id = new SqlParameter("@id", a.Id);

            laboratory.Database.ExecuteSqlCommand("EXECUTE dbo.sp_DelMember @id",id);
            listmember = laboratory.MemberInfo.FromSqlRaw("SELECT * FROM dbo.MemberInfo").ToList();
            table_member.ItemsSource = listmember;
            table_member.Items.Refresh();
        }
    }
}
