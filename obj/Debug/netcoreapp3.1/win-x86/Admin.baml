   M S B A M L   `   `   `  ����E  ARating_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Rating_App
Rating_App  5   	       Rating_App.Admin   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Rating_App     5   	     � WindowStyle$  ThreeDBorderWindow=�5       � WindowState$ 	Maximized=�5	   
   $
��1000��5
   	   $
��1000��5   	    � Title$ Admin��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      .+�5   
   �� $��0��6   $��0��6"   
�������.+�5      �� -   5        $��
btn_config��5         
button_tab#���   5      $��Cấu hình hệ thống��6:   
 � Tag$ Config.xaml��5   +   �� 5      -   5        $��btn_config_slide��5      #���   5      $ Rating.xaml��65   $��Danh sách đánh giá��6G   5      �� 5      -   5        $��btn_exit��5      #���   5      $��Thoát ứng dụng��65   6N   5       � 5   
   -   5          �Name$ panel��5   @   $��1��6     � NavigationUIVisibility$ Hidden=�6      � Source$ Config.xaml?�6O   5      5       