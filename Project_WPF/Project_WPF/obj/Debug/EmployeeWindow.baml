   M S B A M L   `   `   `  ����F  BProject_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project_WPFProject_WPF  5   	        Project_WPF.EmployeeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Project_WPF     5   	     � Title$  EmployeeWindow��5   	   $	��700��6    $
��1400��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $	��20* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $
��675* �6   �� 5      $
��118* �6   .+�5   
   �� $��1��6   $��2��6"   $��1��63   $��5.8,5,4.6,5.2q�6C   .+�5      �� $��30��6   �� 5      $��Поиск по:��6   �� 5      $#��табельный номер��6   �� 5      -   5         ��Name$
 tabN��5      
���   �6$   �� 5      $��Фамилия��6   �� 5      -   5        $ Famil��5      
���   �6%   �� 5      $��Цех��6   �� 5      -   5        $��cbDep��5      
���   �68   �� 5      $��30��6   �� 5      -   5         ��Name$ Clear��5      $��Очистить��6$   $��	10,0,10,0q�6K   5      o� 5!   
   $��0��6   $��2��6   $��25��60   $	��Top=�6<   .@�5"      m� $
��File��6   .@�5#      m� $��New Project��6   63   m� 5$      $��Open Project��6   .@�5%      m� $��WinForms��6   63   m� 5&      $	��WPF��6   6/   5'      �� 5(      m� 5)      $
��Exit��6   6,   5*      m� 5+      $
��Edit��6   6(   m� 5,      $
��View��6   6(   5-      &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ dGrid��5/      $��0��6"   $��1��62      CanUserAddRows .     AutoGenerateColumns .     RowHeaderWidth$ 50Q�50   C   ���	#FFFAFDE1
���   ���5/   V   �� 	   Columns	 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Таб. №��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
Tabel_id+  53      $
 Ф.И.О��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L    64   �� *FIO+   	CellStyle 54      �� 55      .�56      ��  �� Property �@��TextAlignment �� Value$
 Left=�6H   57      59        5:      $
 Должность��6%    68   �� *title+  5;      $ 
 Подразделение��6%    6<   �� *
department+  5<      $
 Вариант��6%    66   �� *NamberVariant+  5=      $
 Комиссия��6%    67   �� *NamberComission+5?      �� 5@   
   -   5        $ addEmpl��5@      $)��#Добавить работника��6"   $
��Left=�6?   $��	40,21,0,0q�6Z   $��2��6m   $	��Top=�6z   $	��150��6�   6�   �� 5A   
   -   5        $ delEmpl��5A      $'��!Удалить работника��6"   $
��Left=�6>   $��
241,21,0,0q�6Y   $��2��6m   $	��Top=�6z   $	��150��6�   6�   �� 5B   
   -   5        $ editEmpl��5B      $3��-Редактировать работника��6#   $
��Left=�6E   $��
462,21,0,0q�6`   $��2��6t   $	��Top=�6�   $	��150��6�   6�   5D      5E      