   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.TaskItemWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$.  (Номер/название задачи��5   	   $	��600��6'   $	��800��64    � WindowState$ 	Maximized=�6@   ��5	      �� 5
   
    �� ImageSource$ Files/grad_1.jpg��6    j� Stretch$ UniformToFill=�64   .��5      � .+�5   
   Z� -   5         Z�Name$
 DocV��5      $��10,10,10,76q�6'   �� 5   
   -   5         ��Name$ BtnOk��5      $
��Ок��6      btnStyle#��[  6-   $��Right=�6O   $��	0,0,60,10q�6k   $��Bottom=�6~   $��20(�6�   $��40��6�   
���   ����	#FFA2CCAA6�   �� 5   
   -   5        $ BtnRight��5      $	��→��6   $y�Hidden=�6/   $��Right=�6C   $��	0,0,37,10q�6_   $��Bottom=�6r   $��22(�6�   $��33��6�   ��6�   Z� ��6�   Z� �� 5   
   -   5        $ BtnLeft��5      $	��←��6   $y�Hidden=�6.   $��Right=�6B   $��
0,0,100,10q�6^   $��Bottom=�6r   $��22(�6�   $��33��6�   ��6�   Z� ��6�   Z� �� 5   
   -   5        $ BtnQue��5      $��?��6   #��[  6-   $��Right=�6O   $��
0,0,199,10q�6k   $��Bottom=�6   $��20(�6�   $��40��6�   {�.  6�   �� 5   
   -   5         ��Name$ 	TxtBoxAns��5      $��Right=�6%   $��31��6A   $��
0,0,300,10q�6M    �� TextWrapping$
 Wrap=�6a   $��Bottom=�6u   $	��170��6�   $��20(�6�   �� 5   
   -   5         ��Name$ ComboAnswers��5      $
��Left=�6)   $��	10,0,0,10q�6D   $��Bottom=�6W   $	��296��6r   $��31��6~   $��20(�6�   {�.  6�   �� 5   
   -   5        $ FavBtn��5      $	��⍟��6!   $��Right=�6-   $��	0,0,245,0q�6I   $��Bottom=�6\   $��36(�6w   ���	#FF646464��6�   Z� ��6�   Z� 6�   �� 5   
   -	   5        $ SettBtn��5   %   $y�Hidden=�6   $	��✐��66   $��Right=�6B   $��
0,0,154,10q�6^   $��Bottom=�6r   $��22(�6�   ���	#FF646464��6�   Z� ��6�   Z� 6�   �� 5   
   -
   5        $ 
TxtBoxChat��5      $
 Wrap=�6&   $��Italic$�6:   	 �� TextAlignment$	 Right=�6M   $��236,0,43,46q�6c   $��Bottom=�6x   $��25��6�   �� 5   
   -   5        $ 	BtnOkChat��5      $�� Ок ��6$   #��[  63   
 J� RenderTransformOrigin$
 
1.053,0.52&�6a   $��	0,0,10,46q�6�   $��Right=�6�   $��Bottom=�6�   $��28��6�   $��25��6�   ���	#FFD4EBBF6�   �� 5   
   $H��BОтправить в чат сообщение по задаче:��6   $
��Left=�6?   $��7,0,0,45q�6Z   $��Bottom=�6l   5      5      