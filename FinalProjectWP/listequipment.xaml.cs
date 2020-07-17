using FinalProjectWP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
namespace FinalProjectWP
{
    /// <summary>
    /// Interaction logic for listequipment.xaml
    /// </summary>
    public partial class listequipment : Window
    {
        private LaboratoryContext Laboratory { get; set; }
        public listequipment()
        {

        }
        public listequipment(int id)
        {
            InitializeComponent();
            Laboratory = new LaboratoryContext();
            List<Supply> supply = Laboratory.Supply.Where(x => x.ExpId == id).ToList();
            List<Equipment> equipment = Laboratory.Equipment.ToList();
            for (int i = 0; i < supply.Count; i++)
            {
                for (int j = 0; i < equipment.Count; j++)
                    if (supply[i].EqmId == equipment[j].Id)
                    {
                        supply[i].Eqm = equipment[j];
                        equipment[j].Quantity -= supply[i].Quantity;
                        break;
                    }
            }
            ListEquipment.ItemsSource = supply;
        }
    }
}
