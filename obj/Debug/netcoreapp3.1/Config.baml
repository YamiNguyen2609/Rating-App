   M S B A M L   `   `   `  ����E  ARating_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Rating_App
Rating_App  5          Rating_App.Config   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Rating_App     5        N� Title$  Config��5       N� 
Background
 �����.��5
      � -   5        $��panel��5
   /      	container#���   6    � ColumnDefinitions 5   
   �� 5      $��0.01* �6   �� 5      $��1* �6   �� 5      $
��0.2* �6   �� 5      $��0.01* �6    � RowDefinitions 5   
   �� 5      $��0.01* �6   �� 5      $��0.08* �6   �� 5      $��0.01* �6   �� 5      �� 5      $��0.01* �6   .+�5   
   �� -   5         ��Name$	 btn��5      
�������$��50��61   $	��200��6=   $��Right=�6I   $��25(�6e   $��2��6t   $��1��6�   $��
Thêm File��6�    
 button#���  6�   
����·�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	list_item��5   r      
IsReadOnly$
 True��6      AutoGenerateColumns$ False��6%   $��1��6A   $��2��6Q   $��3��6e   
�������$��0q�6�      Columns 5%      4  .System.Windows.Controls.DataGridTemplateColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6)   	   CanUserResize$
	 True��64   
   Header$
 	Tên file��6I      CellTemplate 5'      �� 5(      .R�5)      �� $��20, 0q�6(   $��Center=�67   $��20(�6R   ��6`   ��  �� Path$
 Path�5*      5,        5-      $ 1* 6)   $	 False��64   $
 Loại hình��6J    5.      �� 5/      .R�50      �� $��20, 0q�6(   $��Center=�67   $��20(�6R   ��6`   �� $
 Type�51      53        54      $ 0.75* 6)   $	 False��67   $
  ��6M    55      �� 56      .R�57      �  58   "   �� 59   &   $
��0.1* �67   �� 5:   &   $��1* �67   �� 5;   &   $
��0.2* �67   �� 5<   &   $��1* �67   �� 5=   &   $
��0.1* �67    5?   "   �� 5@   &   $
��0.1* �64   �� 5A   &   $��1* �64   �� 5B   &   $
��0.1* �64   .+�5D   "   �� $��
btn_update��6F   -   5        $��1��5D   )   $��1��69   $��Chỉnh sửa��6�   #���  6�   
����ح�
 � Tag 6q   �� $ Id�6�   �� 5E   "   $��
btn_remove��6F   -   5        $��3��5E   )   $��1��69   $
��Xóa��6�   #���  6�   
���z��� 6q   �� $ Id�6�   5F      5G      5I      5L      5M      5N      