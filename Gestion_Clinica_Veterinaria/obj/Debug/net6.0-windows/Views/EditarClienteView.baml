   M S B A M L   `   `   `  ����V  RGestion_Clinica_Veterinaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Gestion_Clinica_Veterinaria.Views!Gestion_Clinica_Veterinaria.Views  5      9    3Gestion_Clinica_Veterinaria.Views.EditarClienteView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Gestion_Clinica_Veterinaria.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6%   .+�5      �� $��Nombre��6   $��	5,15,15,5q�6&   $��88��69   6F   �� 5      -   5         ��Name$ NombreTextBox��5      $��23��6-    �� TextWrapping$
 Wrap=�69   $��	30,0,15,0q�6M   $	��120��6`   5      �� 5   
   $��1��6   $��0��6%   .+�5      �� $	��DNI��6   $��	5,15,15,5q�6#   $��88��66   �� 5      -   5        $ 
DNITextBox��5      $��23��6*   $��	30,0,15,0q�66   $
 Wrap=�6I   $	��120��6]   5      �� 5   
   $��2��6   $��0��6%   .+�5       �� $��Email��6   $��	5,15,15,5q�6%   $��88��68   �� 5!      -   5        $ EmailTextBox��5!      $��23��6,   $
 Wrap=�68   $��	30,0,15,0q�6L   $	��120��6_   5"      �� 5$   
   $��0��6   $��1��6%   .+�5%      �� $��	Telefono1��6   $��	5,15,15,5q�6*   $��88��6=   �� 5&      -   5        $ Telefono1TextBox��5&      $��23��60   $
 Wrap=�6<   $��	30,0,15,0q�6P   $	��120��6c   5'      �� 5(   
   $��1��6   $��1��6%   .+�5)      �� $��	Telefono2��6   $��	5,15,15,5q�6*   $
��Wrap=�6=   $��88��6Q   �� 5*      -   5        $ Telefono2TextBox��5*      $��23��60   $
 Wrap=�6<   $��	30,0,15,0q�6P   $	��120��6c   5+      �� 5,   
   $��2��6   $��1��6%   .+�5-      �� $��CodigoPostal��6   $��	5,15,15,5q�6,   $
��Wrap=�6?   $��88��6S   �� 5.      -   5        $ CodigoPostalTextBox��5.      $��23��63   $
 Wrap=�6?   $��	30,0,15,0q�6S   $	��120��6f   5/      �� 51   
   $��0��6   $��2��6%   .+�52      �� $��	Provincia��6   $��	5,15,15,5q�6)   $��88��6<   �� 53      -   5         ��Name$ ProvinciaComboBox��53       �� DisplayMemberPath$ NomProvincia��54       �� SelectedValuePath$ NomProvincia��55      $	��120��56      $��	30,0,15,0q�57      
���   �58      59      �� 5;   
   $��1��6   $��2��6%   .+�5<      �� $��Ciudad��6   $��	5,15,15,5q�6&   $��88��69   �� 5=      -   5        $ CiudadTextBox��5=      $��23��6-   $
 Wrap=�69   $��	30,0,15,0q�6M   $	��120��6`   5>      �� 5?   
   $��2��6   $��2��6%   .+�5@      �� $��	Direccion��6   $��	5,15,15,5q�6)   $��88��6<   �� 5A      -	   5        $ DireccionTextBox��5A      $��23��60   $
 Wrap=�6<   $��	30,0,15,0q�6P   $	��120��6c   5B      �� 5E   
   $��1��6   $��3��6%   .+�5F      �� -
   5         ��Name$ GuardarButton��5F      $��GUARDAR CLIENTE��6,   $	��120��6b    
  color9#��[  6n   5G      5H      5I      