   M S B A M L   `   `   `  ����V  RGestion_Clinica_Veterinaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Gestion_Clinica_Veterinaria.Views!Gestion_Clinica_Veterinaria.Views  5      =    7Gestion_Clinica_Veterinaria.Views.ConsultarConsultaView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Gestion_Clinica_Veterinaria.Views     5      .��5	      � .+�5   
   �� $��10,20,10,10q�6   .+�5      �   � ColumnDefinitions  5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      � $��5q�6   .+�5      �� -   5         ��Name$  PlaceholderNombreTextBlock��5       $��Buscar Cliente...��6D   
������� J� IsHitTestVisible$ False��5       $
��Left=�6:   �� 5      -   5         ��Name$ BuscarClienteTextBox��5      $	��200��6<   $��Right=�6p   $��0,0,40,0q�6�   5      � 5      $��5q�6   $��1��6"   .+�5      �� -   5        $ PlaceholderDniTextBlock��5       $��Buscar Animal...��6A   
�������$ False��5       $��5,0,0,0q�69   $
��Left=�6J   �� 5      -   5        $ BuscarMascotaTextBox��5      $	��200��6<   $��Right=�6p   $��0,0,40,0q�6�   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ ConsultasDataGrid��5         AutoGenerateColumns$ False��62      CanUserAddRows$ False��6N      
IsReadOnly$
 True��5       $��
10,20,0,20q�6+      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Animal��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Animal+6T     5#      $	 Cliente��6)   $
 * 6V    6:   �� *	Cliente+6V     5$      $	 TipoConsulta��6)   $
 * 6`    6?   �� *TipoConsulta+6`     5%      $	 Sintomas��6)   $
 2* 6X    6;   �� *
Sintomas+6X     5&      $	 Procedimiento��6)   $
 2* 6b    6@   �� *Procedimiento+6b     5'      $	 Fecha��6)   $
 * 6R    68   �� *Fecha+6R     5(      $	 Precio��6)   $
 * 6T    69   �� *Precio+6T   4  .System.Windows.Controls.DataGridTemplateColumn  5)      $	 Editar��6-   $
 * 6=      CellTemplate 5*      �� 5+      .R�5,   "   �� -   5        $��Editar��5,   )   
������
 � Tag 6U   �� 6e   5-      5/        50      $	 Eliminar��6-   $
 * 6?    51      �� 52      .R�53   "   �� -   5        $��Eliminar��53   )   
���  �� 6Y   �� 6i   54      56      58      59      5:      5;      