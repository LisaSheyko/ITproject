   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Project.theoryWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$5  /Теоретический справочник��5	   	   $	��600��6*   $	��800��67    � WindowState$ 	Maximized=�6C   ��5
      �� 5   
    �� ImageSource$ Files/grad_1.jpg��6    j� Stretch$ UniformToFill=�64   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   R� -   5         R�Name$
 Tree��5      $��	10,37,5,5q�6!    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5         ��Name$ 	ComboElem��5      $��80,10,140,0q�6&   $	��Top=�6;   $
��Auto��6S   $��2��6`    �� 
IsEditable . 6t   �� 5   
   $��1��6   $��
10,37,10,5q�6%   
�������$
��Auto��6L   $
��Auto��6Z   .+�5      9� -   5        	 9�Name$	 exp_1��5      $'��!Заданные учителем��6&   
 9� 
IsExpanded
 . .��5      �� -   5         ��Name$ hwlst��5      5      9� 5      -   5        $	 exp_2��5      $*��$В процессе изучения��6&   .��5      �� 5      9� 5      -   5        $	 exp_3��5      $%��Остались вопросы��6&   .��5       �� -   5        $ quelst��5       5!      9� 5"      -   5        $	 exp_4��5"      $,��&Могут быть интересны��6&   .��5#      �� 5$      9� 5%      -	   5        $	 exp_5��5%      $��Последние��6&   .��5&      �� 5'      9� 5(      -
   5        $	 exp_6��5(      $��Избранные��6&   .��5)      �� -   5        $ favlst��5)      5*      �� 5+      -   5         ��Name$ AddBtn��5+   2   $)��#Добавить материалы��6      btnStyle#��[  6B   $��Center=�6d   $��Bottom=�6�   ���	#FFE3FCD46�   5,      �� 5-   
   -   5        $��1��5-      $��Right=�6!   $��	0,10,10,0q�6=   $	��Top=�6P   $	��125��6h   $��22��6t   $��Перейти��6�   ���	#FF51B0B66�   �� 5.   
   -   5        $ HomeBtn��5.      $
��🏠��6"   $
��Left=�6/   $��0,0,0,0q�6J   $	��Top=�6[   $��24(�6s   ���	#FF111111��6�   Z� ��6�   Z� 6�   5/      50      