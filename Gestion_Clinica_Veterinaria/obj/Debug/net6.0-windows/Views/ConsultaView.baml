   M S B A M L   `   `   `  ����V  RGestion_Clinica_Veterinaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Gestion_Clinica_Veterinaria.ViewModels&Gestion_Clinica_Veterinaria.ViewModels  5      U/clr-namespace:Gestion_Clinica_Veterinaria.Views!Gestion_Clinica_Veterinaria.Views  5      4    .Gestion_Clinica_Veterinaria.Views.ConsultaView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      E
viewmodels4clr-namespace:Gestion_Clinica_Veterinaria.ViewModels  5      ;local/clr-namespace:Gestion_Clinica_Veterinaria.Views  5        � DataContext  5      >   8Gestion_Clinica_Veterinaria.ViewModels.ConsultaViewModel  5   
    � 	Resources 5       �� DataTypeG   AGestion_Clinica_Veterinaria.ViewModels.ConsultarConsultaViewModel=   7Gestion_Clinica_Veterinaria.Views.ConsultarConsultaViewC   =Gestion_Clinica_Veterinaria.ViewModels.CrearConsultaViewModel9   3Gestion_Clinica_Veterinaria.Views.CrearConsultaView��%�   (��       5      *, +)(�� 2     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� CornerRadius$ 	10,0,0,10��6   ��5       �� 5!       �� 
StartPoint$	 0,0&�6&    �� EndPoint$ 1,0.7&�67   .��5"      �    secondaryBackColor1 � Color# [  6#    � Offset$ 0Q�6P   � 5#        secondaryBackColor2# [ 6#   $ 1Q�6P   5$      ._�5'      � 	 � ColumnDefinitions	 5(      �� 5)      $��* �6'   �� 5*      $��* �6'   �� 5+      $��* �6'   �� 5,      $��* �6'   .+�5/      �� $��0��6   
 �� Orientation$
 
Horizontal=�6.   $��Center=�6G   .+�50      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ 
KitMedical=�6#   $��20��65   $��20��6@    
 color9   
Foreground# [ 6L   $��	35,0,10,0q�6q   �� 51      $��	CONSULTAS��6    $��17(�61     titleColor2#��[ 6?   $��
Montserrat)�6i   $��Medium"�6�   $��Center=�6�   52      	� 54        
menuButton#��[ 6    
 color6
 � Tag# [ 55      $��2��57      $��25��58       d� 	IsChecked$
 TrueY�59      $��-5,5,0,5q�5:      ��56      �� *ConsultarComand+.��5<      �� $
 
Horizontal=�6!   .+�5=        $ AddressCard=�6'     menuButtonIcon#��[ 6:   �� 5>      $��	CONSULTAR��6$     menuButtonText#��[ 65   5?      5@      	� 5B      #��[ 6   # [ 5C      $��3��5E      $��25��5F      $��-5,5,0,5q�5G      ��5D      �� *CrearComand+.��5I      �� $
 
Horizontal=�6!   .+�5J        $ Certificate=�6'   #��[ 6:   �� 5K      $��CREAR��6$   #��[ 61   5L      5M      5N      5O      �� 5Q   
   $��1��5R      $��2q�5S      ��5Q      �� *CurrentChildView+5S      5T      5U      