using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TTraxx.PokemonGOManager.Business;
using TTraxx.PokemonGOManager.Entities;

namespace TTraxx.PokemonGOManager.WPF
{
    /// <summary>
    /// Interaction logic for PokedexW.xaml
    /// </summary>
    public partial class PokedexW : Window
    {
        public List<Pokemon> PokemonList { get; set; }

        public PokedexW()
        {
            InitializeComponent();

            PokemonList = new PokemonBL().GetAvailablePokemon();
            lstvwPokedex.ItemsSource = PokemonList;
        }
    }
}
