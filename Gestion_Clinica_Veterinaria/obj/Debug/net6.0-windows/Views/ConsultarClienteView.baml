   M S B A M L   `   `   `  ����V  RGestion_Clinica_Veterinaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Gestion_Clinica_Veterinaria.Views!Gestion_Clinica_Veterinaria.Views  5      <    6Gestion_Clinica_Veterinaria.Views.ConsultarClienteView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Gestion_Clinica_Veterinaria.Views     5      .��5	      � .+�5   
   �� $��10,20,10,10q�6   .+�5      �   � ColumnDefinitions  5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      � $��5q�6   .+�5      �� -   5         ��Name$  PlaceholderNombreTextBlock��5       $��Buscar por nombre...��6D   
������� J� IsHitTestVisible$ False��5       $
��Left=�6:   �� 5      -   5         ��Name$ BuscarNombreTextBox��5      $	��200��6;   $��Right=�6o   $��0,0,40,0q�6�   5      � 5      $��5q�6   $��1��6"   .+�5      �� -   5        $ PlaceholderDniTextBlock��5       $��Buscar por DNI...��6A   
�������$ False��5       $��5,0,0,0q�69   $
��Left=�6J   �� 5      -   5        $ BuscarDniTextBox��5      $	��200��68   $��Right=�6l   $��0,0,40,0q�6�   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ ClientesDataGrid��5         AutoGenerateColumns$ False��61      CanUserAddRows$ False��6M      
IsReadOnly$
 True��5       $��
10,20,0,20q�6+      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Nombre��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
NomCliente+6X     5#      $		 DNI��6)   $
 * 6N    66   �� *DNI+6N     5$      $	 Email��6)   $
 * 6R    68   �� *Email+6R     5%      $	 	Telefono1��6)   $
 * 6Z    6<   �� *	Telefono1+6Z     5&      $	 	Telefono2��6)   $
 * 6Z    6<   �� *	Telefono2+6Z     5'      $	 	Provincia��6)   $
 * 6Z    6<   �� *	Provincia+6Z     5(      $	 Ciudad��6)   $
 * 6T    69   �� *Ciudad+6T     5)      $	 	Direccion��6)   $
 * 6Z    6<   �� *	Direccion+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5*      $	 Editar��6-   $
 * 6=      CellTemplate 5+      �� 5,      .R�5-   "   �� -   5        $��Editar��5-   )   
������
 � Tag 6U   �� 6e   5.      50        51      $	 Eliminar��6-   $
 * 6?    52      �� 53      .R�54   "   �� -   5        $��Eliminar��54   )   
���  �� 6Y   �� 6i   55      57      59      5:      5;      5<      