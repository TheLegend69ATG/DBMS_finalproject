   M S B A M L   `   `   `  ����I  EFinalProjectWP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FinalProjectWPFinalProjectWP  5   	   "    FinalProjectWP.listequipment   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:FinalProjectWP     5   	     � WindowState$  	Maximized=�5   	    � Title$ 	Equipment��5	   	   $	��450��6   $	��800��6(   .��5
      &   System.Windows.Controls.DataGrid  -   5          Name$ ListEquipment��5
      $��Comic Sans MS)�6&   $��32(�6A      AutoGenerateColumns$ False��6O      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6k      
IsReadOnly$
 True��6~   $��Stretch=�6�   $��Stretch=�6�   $	��Top=�6�      	RowHeight$	 374Q�5         ColumnHeaderStyle 5   
   �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5      �� 	 �� Property	 � ��
 �� Value$
 Stretch=�68   �� 5      	 � ��$
 Center=�6?   5         Columns 5   
   4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Image��6%      Width$ 2* 64      CellTemplate 5      �� 5      .R�5      �� $
��Fill=�6=   ��6    �� *	Eqm.Image+6=   5      5      0  *System.Windows.Controls.DataGridTextColumn  5      $
 Name��6!   $ 1* 6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
Eqm.Name+  5      $ Description��6%   $ 3* 6:    5      �� 5      .R�5       �� $��Visible=�6(   $
��True��6N   .��5!      �� $
��Wrap=�6I   ��6(   �� *Eqm.Description+6I   5"      5#      5%        5&      $ Quantity��6!   $ 2* 63    6>   �� *
Quantity+5)      5*      