   M S B A M L   `   `   `  ����V  RGestion_Clinica_Veterinaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Gestion_Clinica_Veterinaria.Views!Gestion_Clinica_Veterinaria.Views  5      :    4Gestion_Clinica_Veterinaria.Views.EditarConsultaView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Gestion_Clinica_Veterinaria.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6%   .+�5      �� $��Selecciona un Animal��6   
�������$��5,0,15,5q�6F   &   System.Windows.Controls.DataGrid  5      -   5          Name$ AnimalesDataGrid��5         AutoGenerateColumns$ False��61      CanUserAddRows$ False��6M      
IsReadOnly$
 True��5      $��
10,20,0,20q�6)      SelectionMode$ Single=�6=    �� SelectedItem 5      �� *SelectedAnimal+ �� Mode$ TwoWay=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Nombre��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	NomAnimal+6W     5      $

 Chip��6)   $ * 6P    67   �� *Chip+6P     5      $
 Cliente��6)   $ * 6V    6:   �� *	Cliente+6V     5      $

 Raza��6)   $ * 6P    67   �� *Raza+6P     5      $
 Especie��6)   $ * 6V    6:   �� *	Especie+6V   5       5!      �� 5"   
   $��1��6   $��0��6%   .+�5#      �� $��Tipo de Consulta��6   $��
25,15,15,5q�61   $	��120��6E   �� 5$      -   5         ��Name$ TiposConsultaComboBox��5$       �� DisplayMemberPath$ NomTipoConsulta��5%       �� SelectedValuePath$ NomTipoConsulta��5&      $	��120��5'      $��	30,0,15,0q�5(      
���   � �� SelectedValue 5*      �� *TipoConsulta+$ TwoWay=�5+      �� 5-   
   $��0��6   $��1��6%   .+�5.      �� $��Sintomas��6   $��	5,15,15,5q�6)   $��88��6<   �� 5/      -   5         ��Name$ SintomasTextBox��5/      $��23��6/    �� TextWrapping$
 Wrap=�6;   $��	30,0,15,0q�6O   $	��240��6b   ��50      �� *
Sintomas+$ TwoWay=�51      �� 52   
   $��1��6   $��1��6%   .+�53      �� $��Procedimiento��6   $��	5,15,15,5q�6.   $
��Wrap=�6A   $��88��6U   �� 54      -   5        $ ProcedimientoTextBox��54      $��23��64   $
 Wrap=�6@   $��	30,0,15,0q�6T   $	��240��6g   ��55      �� *Procedimiento+$ TwoWay=�56      �� 57   
   $��0��6   $��2��6%   .+�58      �� $��Precio��6   $��	5,15,15,5q�6'   $
��Wrap=�6:   $��88��6N   �� 59      -   5        $ PrecioTextBox��59      $��23��6-   $
 Wrap=�69   $��	30,0,15,0q�6M   $	��120��6`   ��5:      �� *Precio+$ TwoWay=�5;      �� 5=   
   $��1��6   $��2��6%   .+�5>      �� -   5         ��Name$ GuardarButton��5>      $��GUARDAR CAMBIOS��6,   $	��120��6b    
  color9#��[  6n   $��0,40,0,0q�6�   5?      5@      5A      