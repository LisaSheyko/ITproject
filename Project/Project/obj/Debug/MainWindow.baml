   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5   	       Project.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Project     5   	     � Title$2  ,Добро пожаловать в FeelMath!��5      $	��600��6*   $	��800��67   $y�Visible=�6C   $	��350��5	   	   $	��525��6    � WindowState$ 	Maximized=�6(   ��5
      �� 5   
    �� ImageSource$ Files/grad_1.jpg��6    j� Stretch$ UniformToFill=�64   .��5      �  J� RenderTransformOrigin$ 0.5,0.5&�6   $��Center=�6+   $��Center=�6F   $	��305��6c   $��138,147,138,117q�6p   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Wrap=�6'   $����Введите логин и пароль либо зарегистрируйтесь в качестве нового ученика:��6;   $	��Top=�6�   $��14(�6�   $��
86,70,86,0q�6�   $��42��6�   $	��314��6�   $��Center=�6�   �� 5   
   -   5         ��Name$ txtBoxLogin��5       �� TextWrapping$
 Wrap=�6'   $	��Top=�6;   $	��202��6S   $��14(�6_   $��21��6m   $��152,143,153,0q�6�   �� 5   
   -   5        $ passwordBox��5      $
 Wrap=�6'   $	��Top=�6;   $	��202��6S   $��14(�6_   $��21��6m   $��152,196,153,0q�6�   $��Webdings)�6�   �� 5   
   -   5         ��Name$ label��5      $��Логин:
��6   $	��Top=�65   $��57��6M   $��152,117,298,0q�6X   $��26��6o   $ 0.456,-0.048&�6{   $
��Bold"�6�   �� 5   
   -   5        $ 
label_Copy��5      $��Пароль:
��6$   $	��Top=�6;   $��57��6S   $ 0.435,2.893&�6^   $��152,169,298,0q�6�   $��27��6�   $
��Bold"�6�   �� 5   
   -   5        	 ��Name$	 	enterButt��5      $��Вход��6$   $	��Top=�63   $��75��6K   $��152,222,280,0q�6k   ���	#FFB8EDCF6�   �� 5   
   -   5        $	 regButt��5      $��Регистрация��6"   $	��Top=�68   $��90��6P   $��264,222,153,0q�6[   ���	#FFCBF2D36�   �� 5   
   -   5        $ incorrectPassLabel��5      $��Center=�6,   $>��8Неправильный логин или пароль!��6P   $��Center=�6y   $��10,247,10,0q�6�   $	��Top=�6�   $��Segoe Print)�6�   $��48��6�   
���   �$
��Bold"�6  $	��496��6#  $y�Hidden=�6/  ��6�   Z� 6/  5      5      