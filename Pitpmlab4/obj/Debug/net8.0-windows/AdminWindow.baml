   M S B A M L   `   `   `  ����D  @Pitpmlab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Pitpmlab4	Pitpmlab4  5   	       Pitpmlab4.AdminWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   )localclr-namespace:Pitpmlab4     5   	     � Title$  AdminWindow��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��4* �6   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��1��6   $��2��6-   $��Center=�6A   $��Center=�6e   $��30(�6�   $��
AdminPanel��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ProductList��5      $��1��6(   $��0��65   $��4��6E   $��Center=�6Y      AutoGenerateColumns$ False��6v      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6H   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+6H     5      $
 Name��6%   $		 100 6L   
 63   �� *Name+6L     5       $
 Cost��6%   $	 75 6L   
 63   �� *Cost+6L     5!      $ Image��6%   $		 250 6R   
 64   �� *	ImagePath+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5"      $	 80 6)      CellTemplate 5#      �� 5$      .R�5%      ��  ��Name$ b_Delete��6%   -   5        $��Удалить��5%   7   
�������6\   5&      5(        5*      $	 80 6)    5+      �� 5,      .R�5-      �� $ b_Edit��6%   -   5        $��Изменить��5-   5   
�������6[   5.      50      53      �� 55   
   -   5        $ b_AddProduct��55      $��1��6'   $��3��67   $��2��6D   $��Add new product��6X   6r   �� 57   
   -   5        $ b_Exit��57      $��1��6!   $��5��61   $��2��6>   $
��Exit��6R   $��20��6x   58      59      