   M S B A M L   `   `   `  ���� E  ARating_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Rating_App
Rating_App      Rating_App.Rating   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:Rating_App     -     N� Title$  Rating�� N� 
Background
 �����.��� -   $��panel��   	container#���    � ColumnDefinitions �� $��0.01* ��� $
��0.2* ��� $��0.01* ��� $
��0.2* ��� $��0.01* ��� $��1* ��� $
��0.2* ��� $��0.01* � � RowDefinitions �� $��0.01* ��� $��0.08* ��� $��0.01* ��� �� $��0.01* �.+�(� $��1��$��1��$��50��$	��200��.��(  "System.Windows.Controls.DatePicker  -   $��	date_from��(� $��3��$��1��$��50��$	��200��.��  -   $��date_end���� -    ��Name$	 btn��
�������$��50��$	��200��$��25(�$��5��$
��Left=�$��1��$��Xuất báo cáo�� 
 button#���  
����·�&   System.Windows.Controls.DataGrid  -   $��	list_item��   
IsReadOnly$
 True��$	��310��$	��Top=�   AutoGenerateColumns$ False��$��1��$��3��$��5��
�������$��0q�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 	   CanUserResize$
	 True��
   Header$
 Bộ phận��   CellTemplate �� .R��� $��10,20q�$��Center=�$��Center=�$��20(�����  �� Path$
 Type�  $ 0.75* $	 False��$
 Lượt thích�� �� .R��� $��10,20q�$��Center=�$��Center=�$��20(����� $
 Like�  $ 1* $	 False��$
 Lượt không thích�� �� .R��� $��10,20q�$��Center=�$��Center=�$��20(����� $ DisLike�