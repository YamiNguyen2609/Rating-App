   M S B A M L   `   `   `  ����E  ARating_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Rating_App
Rating_App  5          Rating_App.Rating   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Rating_App     5      -   5          N� Title$  Rating��5	       N� 
Background
 �����.��5      � -   5        $��panel��5   /      	container#���   6    � ColumnDefinitions 5   
   �� 5      $��0.01* �6   �� 5      $
��0.2* �6   �� 5      $��0.01* �6   �� 5      $
��0.2* �6   �� 5      $��0.01* �6   �� 5      $��1* �6   �� 5      $
��0.2* �6   �� 5      $��0.01* �6    � RowDefinitions 5   
   �� 5      $��0.01* �6   �� 5      $��0.08* �6   �� 5      $��0.01* �6   �� 5      �� 5      $��0.01* �6   .+�5   
   (� $��1��6   $��1��6"   $��50��6/   $	��200��6;   .��5      (  "System.Windows.Controls.DatePicker  -   5        $��	date_from��5      6,   5      (� 5    
   $��3��6   $��1��6"   $��50��6/   $	��200��6;   .��5!        -   5        $��date_end��5!      6)   5"      �� 5#   
   -   5         ��Name$	 btn��5#      
�������$��50��62   $	��200��6>   $��25(�6\   $��5��6j   $
��Left=�6z   $��1��6�   $��Xuất báo cáo��6�    
 button#���  6�   
����·�6�   &   System.Windows.Controls.DataGrid  5$   
   -   5        $��	list_item��5$   r      
IsReadOnly$
 True��6      AutoGenerateColumns$ False��6%   $��1��6A   $��3��6Q   $��5��6^   
�������$��0q�6�      Columns 5%      4  .System.Windows.Controls.DataGridTemplateColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6)   	   CanUserResize$
	 True��64   
   Header$
 Bộ phận��6I      CellTemplate 5'      �� 5(      .R�5)      �� $��10,20q�6(   $��Center=�67   $��20(�6R   ��6`   ��  �� Path$
 Type�5*      5,        5-      $ 0.75* 6)   $	 False��67   $
 Đánh giá��6M    5.      �� 5/      .R�50      �� $��10,20q�6(   $��Center=�67   $��20(�6R   ��6`   �� $ State�51      53        54      $ 1* 6)   $	 False��64   $
 Thời gian��6J    55      �� 56      .R�57      �� $��10,20q�6(   $��Center=�67   $��20(�6R   ��6`   �� $ CreateAt�58      5:      5<      5=      5>      