using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using TTraxx.PokemonGOManager.Entities;

namespace TTraxx.PokemonGOManager.WPF.Converters
{
    public class PokemonImageURLToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return new BitmapImage(new Uri($"pack://application:,,,/Images/Pokedex/Big/{(string)value}"));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PokemonTypeToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.Color validcolor = System.Windows.Media.Colors.White;

            if (value != null && value.GetType() == typeof(Pokemon.enuTypes))
            {
                Pokemon.enuTypes enuValue = (Pokemon.enuTypes)value;

                switch (enuValue)
                {
                    case Pokemon.enuTypes.Normal:
                        validcolor = System.Windows.Media.Color.FromRgb(146, 146, 98);
                        break;
                    case Pokemon.enuTypes.Fire:
                        validcolor = System.Windows.Media.Color.FromRgb(230, 114, 31);
                        break;
                    case Pokemon.enuTypes.Water:
                        validcolor = System.Windows.Media.Color.FromRgb(76, 123, 237);
                        break;
                    case Pokemon.enuTypes.Electric:
                        validcolor = System.Windows.Media.Color.FromRgb(243, 200, 27);
                        break;
                    case Pokemon.enuTypes.Grass:
                        validcolor = System.Windows.Media.Color.FromRgb(103, 182, 64);
                        break;
                    case Pokemon.enuTypes.Ice:
                        validcolor = System.Windows.Media.Color.FromRgb(124, 205, 205);
                        break;
                    case Pokemon.enuTypes.Fighting:
                        validcolor = System.Windows.Media.Color.FromRgb(175, 44, 37);
                        break;
                    case Pokemon.enuTypes.Poison:
                        validcolor = System.Windows.Media.Color.FromRgb(143, 57, 143);
                        break;
                    case Pokemon.enuTypes.Ground:
                        validcolor = System.Windows.Media.Color.FromRgb(219, 181, 77);
                        break;
                    case Pokemon.enuTypes.Flying:
                        validcolor = System.Windows.Media.Color.FromRgb(146, 136, 216);
                        break;
                    case Pokemon.enuTypes.Psychic:
                        validcolor = System.Windows.Media.Color.FromRgb(247, 55, 113);
                        break;
                    case Pokemon.enuTypes.Bug:
                        validcolor = System.Windows.Media.Color.FromRgb(152, 166, 29);
                        break;
                    case Pokemon.enuTypes.Rock:
                        validcolor = System.Windows.Media.Color.FromRgb(162, 141, 49);
                        break;
                    case Pokemon.enuTypes.Ghost:
                        validcolor = System.Windows.Media.Color.FromRgb(98, 77, 133);
                        break;
                    case Pokemon.enuTypes.Dragon:
                        validcolor = System.Windows.Media.Color.FromRgb(93, 31, 243);
                        break;
                    case Pokemon.enuTypes.Dark:
                        validcolor = System.Windows.Media.Color.FromRgb(94, 73, 60);
                        break;
                    case Pokemon.enuTypes.Steel:
                        validcolor = System.Windows.Media.Color.FromRgb(164, 164, 195);
                        break;
                    case Pokemon.enuTypes.Fairy:
                        validcolor = System.Windows.Media.Color.FromRgb(228, 135, 228);
                        break;
                    default:
                        validcolor = System.Windows.Media.Colors.White;
                        break;
                }
            }

            return new System.Windows.Media.SolidColorBrush(validcolor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PokemonTypeToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.Color validcolor = System.Windows.Media.Colors.Black;

            if (value != null && value.GetType() == typeof(Pokemon.enuTypes))
            {
                Pokemon.enuTypes enuValue = (Pokemon.enuTypes)value;

                switch (enuValue)
                {
                    case Pokemon.enuTypes.Normal:
                        validcolor = System.Windows.Media.Colors.White;
                        break;
                    case Pokemon.enuTypes.Fire:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Water:
                        validcolor = System.Windows.Media.Colors.White;
                        break;
                    case Pokemon.enuTypes.Electric:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Grass:
                        validcolor = System.Windows.Media.Colors.White;
                        break;
                    case Pokemon.enuTypes.Ice:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Fighting:
                        validcolor = System.Windows.Media.Colors.White;
                        break;
                    case Pokemon.enuTypes.Poison:
                        validcolor = System.Windows.Media.Colors.White;
                        break;
                    case Pokemon.enuTypes.Ground:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Flying:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Psychic:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Bug:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Rock:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Ghost:
                        validcolor = System.Windows.Media.Colors.White;
                        break;
                    case Pokemon.enuTypes.Dragon:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Dark:
                        validcolor = System.Windows.Media.Colors.White;
                        break;
                    case Pokemon.enuTypes.Steel:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    case Pokemon.enuTypes.Fairy:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                    default:
                        validcolor = System.Windows.Media.Colors.White;
                        //validcolor = System.Windows.Media.Colors.Black;
                        break;
                }
            }

            return new System.Windows.Media.SolidColorBrush(validcolor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class PokemonGenderToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.Color validcolor = System.Windows.Media.Colors.Black;

            if (value != null && value.GetType() == typeof(char))
            {
                char enuValue = (char)value;

                switch (enuValue)
                {
                    case '♂':
                        validcolor = System.Windows.Media.Colors.Blue; //System.Windows.Media.Color.FromRgb(146, 146, 98);
                        break;
                    case '♀':
                        validcolor = System.Windows.Media.Colors.Pink; //System.Windows.Media.Color.FromRgb(230, 114, 31);
                        break;
                    default:
                        validcolor = System.Windows.Media.Colors.Black;
                        break;
                }
            }

            return new System.Windows.Media.SolidColorBrush(validcolor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PokemonIVToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.Color validcolor = System.Windows.Media.Colors.Black;

            if (value != null && value.GetType() == typeof(Pokemon))
            {
                Pokemon pokValue = (Pokemon)value;

                if (pokValue.MinIV == 100)
                {
                    validcolor = System.Windows.Media.Colors.Green;
                }
                else if (pokValue.MinIV > 82)
                {
                    validcolor = System.Windows.Media.Colors.LightGreen;
                }
                else if (pokValue.MinIV > 66)
                {
                    validcolor = System.Windows.Media.Colors.Yellow;
                }
                else if (pokValue.MinIV > 50)
                {
                    validcolor = System.Windows.Media.Colors.Orange;
                }
                else
                {
                    validcolor = System.Windows.Media.Colors.Red;
                }
            }

            return new System.Windows.Media.SolidColorBrush(validcolor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class ObjectIsNullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value != null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ObjectIsNullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) { return System.Windows.Visibility.Collapsed; }

            return System.Windows.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
