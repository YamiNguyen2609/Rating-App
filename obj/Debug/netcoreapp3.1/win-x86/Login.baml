   M S B A M L   `   `   `  ����E  ARating_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Rating_App
Rating_App  5   	       Rating_App.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Rating_App     5   	   -   5        $��window��5   	     � WindowStyle$  ThreeDBorderWindow=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ Đăng nhập��5      $	��500��6   $	��500��6%   .��5      � -   5        $��panel��5      
������� � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $
��0.3* �6   �� 5      $��0.75* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      $��0.25* �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $��1* �6   .+�5   
   �� $��1��6   $��1��6!   $��2��61   $��Đăng nhập��6E   $��40(�6V   $
��Bold"�6d   
����·�$��Center=�6�   $��Center=�6�   �� 5   
   $��2��6   $��1��6"   $��Username��63   $��25(�6C   $��Stretch=�6Q   $��Center=�6o   �� 5   
   -   5        $��txt_username��5   L   $��2��6   $��2��6   $��30(�60   $��65��6?      textbox#���   6`   6�   �� 5    
   $��3��6   $��1��6!   $��Password��61   $��30(�6A   $��Center=�6O   G� 5!   
   -   5        $��txt_password��5!   _   $��3��6   $��25(�6$   $��2��62   $��65��6B    G� PasswordChar$ *��6N     passwordbox#���  6s   6�   �� 5"   
   -   5        $��	txt_error��5"   s   $��4��6   $��1��6"   $��2��62   $��30(�6G   
���  ��$��65��6g   6s   �� 5#   
   -   5        $��	btn_login��5#   w   $��5��6   $��1��6   $��2��6.   
����·�
�������$��80��6j    
 button#���  5$      $��Đăng nhập��6.   5%      5&      