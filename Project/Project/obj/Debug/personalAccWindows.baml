   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	        Project.personalAccWindows   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$!  Личный кабинет��5	   	   $	��600��6    $	��660��6-   $	��315��69   $	��660��6I    � WindowState$ 	Maximized=�6X   ��5
      �� 5   
    �� ImageSource$ Files/grad_1.jpg��6    j� Stretch$ UniformToFill=�64    � 	Resources 5      2  ,System.Windows.Controls.AlternationConverter   AlternationConverter��%   &	          5   
   6   5      .��5      � -   5         �Name$
 grid��5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 	theoryBtn��5      $5��/Теоретический справочник��6$     btnStyle#��[ 6G   $��	10,10,0,0q�6i   $	��179��6|   $��31��6�   $
��Left=�6�   $	��Top=�6�   $��0q�6�   ���	#FF7ED9D26�   �� 5   
   -   5        $ taskBtn��5      $��Задачи��6"   #��[ 63   $��
194,10,0,0q�6U   $	��117��6i   $��31��6u   $	��Top=�6�   $��1q�6�   $��0q�6�   $
��Left=�6�   ���	#FF45B3C46�   � 5   
   $��10,46,10,40q�6   .+�5      �� .��5      �� -   5         ��Name$ 	textBlock��5      $
��Wrap=�6/   
�������	 J� Opacity$		 0.3Q�6V   
 �� TextAlignment$
 Right=�6d   ��. 6z   5      5      �� 5   
   -   5         ��Name$ textBox��5       �� TextWrapping$
 Wrap=�6#   $��Italic$�67    �� TextAlignment$ Right=�6J   $��4,234,43,10q�6`   $��Bottom=�6u   $��25��6�   {�.  6�   �� 5   
   -   5        $ BtnOk��5      $�� Ок ��6    #��[ 6/    J� RenderTransformOrigin$ 
1.053,0.52&�6]   $��283,234,10,10q�6�   $��Right=�6�   $��Bottom=�6�   $��28��6�   $��25��6�   ���	#FFD4EBBF{�.  6  � 5   
   $��1��6   
�������.+�5      �� -   5         ��Name$ imgProgress��5      $��10,72,10,10q�6)   �� 5       -   5        $ txtBlockStat��5       $��10,72,10,10q�6.   $
��Wrap=�6C   �� 5!      -	   5         ��Name$ labClass��5!      $!��Выберите класс��6&   $��65,10,164,0q�6?   $	��Top=�6T   $��Center=�6l   �� 5"      -
   5         ��Name$ comboboxClassNum��5"      $��167,10,113,0q�61   $	��Top=�6G   $��26��6_   $��Center=�6k   $��46��6�   6�   �� 5#      -   5        $ comboboxClassLet��5#      $��218,10,62,0q�61   $	��Top=�6F   $��26��6^   $��Center=�6j   $��46��6�   6�   �� 5$      -   5        $ labChild��5$      $%��Выберите ученика��6&   $��10,41,204,0q�6A   $	��Top=�6V   �� 5%      -   5        $ comboboxDisciple��5%      $��127,41,10,0q�61   $	��Top=�6F   $��26��6^   6j   5&      5'      5(      