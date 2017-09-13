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
using TTraxx.PokemonGOManager;
using TTraxx.PokemonGOManager.Business;

namespace TTraxx.PokemonGOManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnScrapePokedex_Click(object sender, RoutedEventArgs e)
        {
            if (new PokeScraper.PokeScraper().ScrapePokedex()) { MessageBox.Show("Pokédex Succesfully Scraped!"); } else { MessageBox.Show("Pokédex Scraping Failed!"); }
        }

        private void btnLoadPokédex_Click(object sender, RoutedEventArgs e)
        {
            var pokedexWindow = new PokedexW();
            pokedexWindow.Show();
        }

        private void btnScrapeSprites_Click(object sender, RoutedEventArgs e)
        {
            var urls = (new PokeScraper.PokeScraper().LoadSprites(new PokemonBL().GetAvailablePokemon()));
        }

        private void btnScrapePokemon_Click(object sender, RoutedEventArgs e)
        {
            if (new PokeScraper.PokeScraper().ScrapeCurrentPokemon()) { MessageBox.Show("Pokémon Succesfully Scraped!"); } else { MessageBox.Show("Pokémon Scraping Failed!"); }
        }
    }
}
