   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Project.registration   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$8  2Регистрация нового ученика��5	   	   $	��260��5
   	   $	��450��6   $	��260��6(    � WindowState$ 	Maximized=�69   ��5      �� 5   
    �� ImageSource$ Files/grad_1.jpg��6    j� Stretch$ UniformToFill=�64   .��5      � $	��Top=�6   $��0,0,0,-1q�6#   $	��230��65   .+�5   
   �� -   5         ��Name$ label��5      $��Введите ФИО:��6   $
��Left=�66   $��	10,10,0,0q�6Q   $	��Top=�6d   �� 5   
   -   5        $ label1��5      $&�� Придумайте логин:��6    $
��Left=�6<   $��	10,38,0,0q�6W   $	��Top=�6j   �� 5   
   -   5        $ label2��5      $��И пароль:��6    $
��Left=�64   $	��Top=�6O   $��	10,69,0,0q�6g    J� RenderTransformOrigin$ 0.121,-0.038&�6z   �� 5   
   -   5        $ label3��5      $+��%Выберите свой класс:��6    $
��Left=�6?   $��
10,124,0,0q�6Z   $	��Top=�6n   �� 5   
   -   5         ��Name$ nameBox��5      $��23��6#   $��130,10,10,0q�6/    �� TextWrapping$
 Wrap=�6D   $	��Top=�6X   6p   �� 5   
   -   5        $ logBox��5      $��23��6"   $��130,41,10,0q�6.   $
 Wrap=�6C   $	��Top=�6W   6o   �� 5   
   -   5        $ passBox1��5      $��23��6$   $��130,72,10,0q�60   $
 Wrap=�6E   $	��Top=�6Y   6q   �� 5   
   -   5         ��Name$ ClassNum��5      $
��Left=�6%   $��170,128,0,0q�6@   $	��Top=�6U   $��46��6m   6x   �� 5   
   -	   5        	 ��Name$	 button��5         btnStyle#��[  6!   $*��$Зарегистрироваться��6C   $��334,161,308,0q�6`   $	��Top=�6w   $	��118��6�   $��Center=�6�   
���   ����	#FFB4E4CA$��24��6�   �� 5   
   -
   5        $ incorrectPassLabel��5      $)��#Заполните все поля!��6,   $��Center=�6J   $��324,184,296,0q�6g   $	��Top=�6~   $��Segoe Print)�6�   �� 5   
   -   5        $ 	ClassLett��5      $
��Left=�6&   $��221,128,0,0q�6A   $	��Top=�6V   $��46��6n   $ 	1.391,0.5&�6y   6�   �� 5   
   -   5        $ 	HelpLabel��5      $2��,Подсказка (опционально):��6#   $
��Left=�6F   $	��Top=�6a   $��	10,97,0,0q�6y   $ 0.121,-0.038&�6�   �� 5   
   -   5        $ passBoxHelp��5      $��23��6'   $��170,100,10,0q�63   $
 Wrap=�6I   $	��Top=�6]   5      5      