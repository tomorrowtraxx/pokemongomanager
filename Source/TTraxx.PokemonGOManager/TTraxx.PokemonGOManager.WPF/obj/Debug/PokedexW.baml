   M S B A M L   `   `   `  ����V  RTTraxx.PokemonGOManager.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TTraxx.PokemonGOManager.WPFTTraxx.PokemonGOManager.WPF  5   	   _4clr-namespace:TTraxx.PokemonGOManager.WPF.Converters&TTraxx.PokemonGOManager.WPF.Converters  5   	   ]3clr-namespace:TTraxx.PokemonGOManager.WPF.Behaviors%TTraxx.PokemonGOManager.WPF.Behaviors  5   	   [2clr-namespace:TTraxx.PokemonGOManager.WPF.Controls$TTraxx.PokemonGOManager.WPF.Controls  5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
   	   *    $TTraxx.PokemonGOManager.WPF.PokedexW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:TTraxx.PokemonGOManager.WPF     5   	   J	localConv4clr-namespace:TTraxx.PokemonGOManager.WPF.Converters     5   	   J
localBehav3clr-namespace:TTraxx.PokemonGOManager.WPF.Behaviors     5   	   LlocalControls2clr-namespace:TTraxx.PokemonGOManager.WPF.Controls     5	   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5
   	     � Title$$  Pokemon GO Manager :: Pokédex��5   	   $	��768��5   	   $
��1366��6   $	��768��5   	   $
��1366��6    � UseLayoutRounding .  � 	Resources 5      L   FTTraxx.PokemonGOManager.WPF.Converters.PokemonImageURLToImageConverter #  PokemonImageURLToImageConverterK   ETTraxx.PokemonGOManager.WPF.Converters.ObjectIsNullToBooleanConverter " ObjectIsNullToBooleanConverterN   HTTraxx.PokemonGOManager.WPF.Converters.ObjectIsNullToVisibilityConverter % !ObjectIsNullToVisibilityConverterR   LTTraxx.PokemonGOManager.WPF.Converters.PokemonTypeToBackgroundColorConverter ) %PokemonTypeToBackgroundColorConverterR   LTTraxx.PokemonGOManager.WPF.Converters.PokemonTypeToForegroundColorConverter ) %PokemonTypeToForegroundColorConverterT   NTTraxx.PokemonGOManager.WPF.Converters.PokemonGenderToForegroundColorConverter + 'PokemonGenderToForegroundColorConverterP   JTTraxx.PokemonGOManager.WPF.Converters.PokemonIVToForegroundColorConverter ' #PokemonIVToForegroundColorConverter " PokedexNr_BackgroundColorBrush �� 
StartPoint �� EndPoint � Color � Offset + 'PokedexPokemonName_BackgroundColorBrush /	 +PokedexPokemonIVHeader_BackgroundColorBrush��%�  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	     &		 �      5   
   64     5   
   63     5   
   66     5   
   6:     5   
   6:     5   
   6<     5   
   68   �� 5   
   $ 0.5,0&�6E   $ 0.5,1&�6X   .��5      � $
 #777��6   $	 0.2Q�6(   � 5      $
 #555��6   $	 0.8Q�6(   5      �� 5   
   $ 0.5,0&�6N   $ 0.5,1&�6a   .��5      � $ 	#FFFDF1DF��6   $	 0.2Q�6-   � 5       $ 	#FFFFE0B2��6   $	 0.8Q�6-   5!      �� 5#   
   $ 0,0.5&�6R   $ 1,0.5&�6e   .��5$      � $ Transparent��6   $ 0Q�6/   � 5%      $
 #999��6   $	 0.5Q�6(   5&      5'      .��5(      � .+�5)   
   �� -   5         ��Name$ lstvwPokedex��5)      ��5*      �� 5+      .R�5,      A�  A� Columns$ 9��6"   5-      ��5/      �� 50      	 �� 
TargetType"	 ��6   .�51      �� 
 �� Property
 � �� �� Value$ Stretch=�6C   �� 52      
 � ��$ 4q�60   53      ��55      �� 56      .R�57      �� $��Stretch=�6   ���#000$��1q�6N    �� CornerRadius$ 6��6b   ._�58      �  � RowDefinitions 59      �� 5:   "   $
��Auto �60   �� 5;   "   �� 5<   "   $
��Auto �60   .+�5>      �� $��0��6%   $��Stretch=�62   ���#333$��0,0,0,1q�6c   ._�5?   "   �  � ColumnDefinitions 5@   &   �� 5A   *   �� 5B   *   $��40 �6;   .+�5D   &   �� $��0��60   $��Stretch=�6@    �� Padding$ 2q�5E   0    �� TextAlignment$ Center=�5F   0   #��[ 5G   0   ��5H   0   �� *Name+�� 5I   &   $��1��60   $��Stretch=�6@   $ 2q�5J   0   $ Center=�5K   0   #��[ 5L   0   ���#fff��5M   0   �� *	PokedexId+ �� StringFormat$ #{0:000}��5N   #   5O      8   2TTraxx.PokemonGOManager.WPF.Controls.GreyableImage  5P      $��1��6:   $
��Left=�6G   $��64��6b   $��64��6m   $��10q�5Q   <    �� BitmapScalingMode$
 Fant=�5R   <    J� SnapsToDevicePixels .    IsFullColor 5Q   H   �� *
IsActive+��5S   <   �� *
ImageUrl+ �� 	Converter# [   J� BitmapEffect 5T   "   F� 5U   &    F� ShadowDepth$ 3Q�6=    F� 	Direction$	 300Q�5V   =    F� Color$ Black��5W   =    F� Softness$ 3Q�5X   =    F� Opacity$	 0.5Q�5Y   =   ��5[   "   �� 5\   &   "	  6,    �� Triggers 5]   *   ^� 5^   .    ^� 
Conditions 5_   2   �� 5`   6    �� Binding 6@   �� *
IsActive+ �� Value True6]   �� 5a   6    6@   �� *HasBeenCaught+	 False6b   0�5c   2   �� 5d   6   
 �@J�Opacity$	 0.5Q�6P   5f   /   5h   '   5j      � 5k      $��1��6#   $��Right=�5l   #   $	��Top=�5m   #   $��5,5,10,5q�5n   #   y�5o   #   �� *IV+# [ .+�5p   "   ��   �� Orientation$  
Horizontal=�6-   .+�5q   &   �� $��Right=�60   $��Impact)�5r   ,   $��14(�6@   
�������$��CP��5t   ,   $��0,0,3,0q�5u   ,   �� 5v   &   $��Right=�60   $��Impact)�5w   ,   $��14(�6@   ���#444��5y   ,   �� *CP+5z   #   5{      � 5|      $��1��6#   $��Right=�5}   #   $	��Top=�5~   #   $��	5,20,10,5q�5   #   y�5�   #   �� *Gender+# [ .+�5�   "   �� $��Right=�6,   $��Impact)�5�   ,   $��14(�6@   $
��Bold"�5�   ,   ��5�   ,   �� *Gender+# [ ��5�   ,   �� *Gender+5�      � 5�      $��1��6#   $��Right=�5�   #   $	��Top=�5�   #   $��5,40,5,0q�5�   #   y�5�   #   �� *CP+# [ .+�5�   "   �� $��Right=�6)   $	��Top=�5�   )   $��20��5�   )   $��50��65   ! �� Padding$! 0,0,3,0q�5�   )   #��[	 5�   )   $ 0,2,2,0��5�   )   ._�5�   &   �� $��Right=�60   $	��Top=�5�   0   $ Right=�5�   0   $��Impact)�5�   0   $��16(�6D   
�������$��IV��5�   0   5�   #   �� 5�   "   $��Right=�6,   $	��Top=�5�   ,   $��0,16,0,0q�5�   ,   $ Right=�5�   0   $��Impact)�5�   0   $��28(�6D   ��5�   0   �� # [ ��5�   0   �� *IV+5�      � 5�      $��2��6#    5�   "   �� 5�   &   $��* �67   �� 5�   &   ��5�   *   �� 5�   .   "	 ��64   .�5�   2   �� 
 � ��$ * �6J    5�   2   �� 5�   6   " �� Binding" 6B   �� *SecundaryTypeId+# �� Value# 6f   Z� .a�5�   :   �� 
 � ��$ 0 �6R   5�   7   5�   /   5�   '   .+�5�   "   �� $��0��6)   $��Stretch=�69   ���#666$��0,1,0,0q�5�   <   ��5�   )   �� *PrimaryTypeId+# [ ._�5�   &   �� $��Stretch=�60   $ 2q�5�   0   $��10(�5�   0   $ Center=�5�   0   ��5�   0   �� *PrimaryTypeId+# [ ��5�   0   �� *PrimaryType+$ J� Effect$ 5�   *   3	  -System.Windows.Media.Effects.DropShadowEffect	  5�   .   % 	  ShadowDepth$% 1Q�6?   & 	  	Direction$	& 300Q�5�   ?   ' 	  Color$' Black��5�   ?   ( 	  Opacity$( 1Q�5�   ?   ) 	  
BlurRadius$) 3Q�5�   ?   5�   '   5�   #   �� 5�   "   $��1��6)   $��Stretch=�69   ���#666$��0,1,0,0q�5�   <   ��5�   )   �� *SecundaryTypeId+# [ y�5�   )   �� *SecundaryTypeId+# [ ._�5�   &   �� $��Stretch=�60   $ 2q�5�   0   $��10(�5�   0   $ Center=�5�   0   ��5�   0   �� *SecundaryTypeId+# [ ��5�   0   �� *SecundaryType+$ 5�   *   	  5�   .   $% 1Q�6?   $	& 300Q�5�   ?   $' Black��5�   ?   $( 1Q�5�   ?   $) 3Q�5�   ?   5�   '   5�   #   5�      .
  (System.Windows.Interactivity.Interaction* 
  	Behaviors* 5�      <   6TTraxx.PokemonGOManager.WPF.Behaviors.ClippingBehavior  5�   "   +   CornerRadius$+ 6��6>   5�      ��5�      �� 5�      "	 ��6$    5�   "   �� 5�   &   " 62   �� *
IsActive+	# False6O   .a�5�   *   �� 
 �@J�Opacity$	 0.5Q�6D   5�   '   �� 5�   &   " 62   �� *
IsActive+# True6O   .a�5�   *   �� 
 �@J�Opacity$ 1Q�6D   5�   '   5�      5�      5�      5�      5�      5�      