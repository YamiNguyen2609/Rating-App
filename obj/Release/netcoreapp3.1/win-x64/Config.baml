   M S B A M L   `   `   `  ���� E  ARating_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Rating_App
Rating_App      Rating_App.Config   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:Rating_App       N� Title$  Config�� N� 
Background
 �����.��� -   $��panel��   	container#���    � ColumnDefinitions �� $��0.01* ��� $��1* ��� $
��0.2* ��� $��0.01* � � RowDefinitions �� $��0.01* ��� $��0.08* ��� $��0.01* ��� �� $��0.01* �.+��� -    ��Name$	 btn��
�������$��50��$	��200��$��Right=�$��25(�$��2��$��1��$��
Thêm File�� 
 button#���  
����·�&   System.Windows.Controls.DataGrid  -   $��	list_item��   
IsReadOnly$
 True��   AutoGenerateColumns$ False��$��1��$��2��$��3��
�������$��0q�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 	   CanUserResize$
	 True��
   Header$
 	Tên file��   CellTemplate �� .R��� $��20, 0q�$��Center=�$��20(�����  �� Path$
 Path�  $ 1* $	 False��$
 Loại hình�� �� .R��� $��20, 0q�$��Center=�$��20(����� $
 Type�  $ 0.75* $	 False��$
  �� �� .R��  �� $
��0.1* ��� $��1* ��� $
��0.2* ��� $��1* ��� $
��0.1* � �� $
��0.1* ��� $��1* ��� $
��0.1* �.+��� $��
btn_update��-   $��1��$��1��$��Chỉnh sửa��#���  
����ح�
 � Tag �� $ Id��� $��
btn_remove��-   $��3��$��1��$
��Xóa��#���  
���z��� �� $ Id�