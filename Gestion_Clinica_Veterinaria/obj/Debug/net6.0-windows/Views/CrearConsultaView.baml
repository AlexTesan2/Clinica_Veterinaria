   M S B A M L   `   `   `  ����V  RGestion_Clinica_Veterinaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Gestion_Clinica_Veterinaria.Views!Gestion_Clinica_Veterinaria.Views  5      9    3Gestion_Clinica_Veterinaria.Views.CrearConsultaView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Gestion_Clinica_Veterinaria.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6%   .+�5      � $��15,10,15,-15q�6   .+�5      �� -   5         ��Name$  PlaceholderNombreTextBlock��5      $"��Nombre del Cliente o Animal ��6@   
������� J� IsHitTestVisible$ False��5      $
��Left=�6*   �� 5      -   5         ��Name$ BuscarNombreTextBox��5      $	��200��67   $��Right=�6k   $��0,0,0,0q�6�   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ AnimalesDataGrid��5         AutoGenerateColumns$ False��61      CanUserAddRows$ False��6M      
IsReadOnly$
 True��5      $��20,20,20,20q�6   	   SelectionMode$	 Single=�64   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	NomAnimal+6W     5       $
 Chip��6)   $ * 6P    67   �� *Chip+6P     5!      $ Cliente��6)   $ * 6V    6:   �� *	Cliente+6V     5"      $
 Raza��6)   $ * 6P    67   �� *Raza+6P     5#      $ Especie��6)   $ * 6V    6:   �� *	Especie+6V   5%      5&      �� 5'   
   $��1��6   $��0��6%   .+�5(      �� $��TIPO de CONSULTA��6   
�������$��
25,15,15,5q�6C   $	��120��6W   �� 5)      -   5         ��Name$ TiposConsultaComboBox��5)       �� DisplayMemberPath$ NomTipoConsulta��5*       �� SelectedValuePath$ NomTipoConsulta��5+      $	��120��5,      $��	30,0,15,0q�5-      
���   �5.      5/      �� 51   
   $��0��6   $��1��6%   .+�52      �� $��Sintomas��6   
�������$��	5,15,15,5q�6;   $��88��6N   �� 53      -   5        $ SintomasTextBox��53      $��23��6/    �� TextWrapping$
 Wrap=�6;   $��	30,0,15,0q�6O   $	��240��6b   54      �� 55   
   $��1��6   $��1��6%   .+�56      �� $��Procedimiento��6   
�������$��	5,15,15,5q�6@   $
��Wrap=�6S   $��88��6g   �� 57      -   5        $ ProcedimientoTextBox��57      $��23��64   $
 Wrap=�6@   $��	30,0,15,0q�6T   $	��240��6g   58      �� 59   
   $��0��6   $��2��6%   .+�5:      �� $��Precio��6   
�������$��	5,15,15,5q�69   $
��Wrap=�6L   $��88��6`   �� 5;      -   5        $ PrecioTextBox��5;      $��23��6-   $
 Wrap=�69   $��	30,0,15,0q�6M   $	��120��6`   5<      �� 5>   
   $��1��6   $��2��6%   .+�5?      �� -   5         ��Name$ GuardarButton��5?      $��GUARDAR CONSULTA��6,   $	��120��6c    
  color9#��[  6o   $��0,40,0,0q�6�   5@      5A      5B      