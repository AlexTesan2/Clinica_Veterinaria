   M S B A M L   `   `   `  ����V  RGestion_Clinica_Veterinaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Gestion_Clinica_Veterinaria.Views!Gestion_Clinica_Veterinaria.Views  5   	   _4clr-namespace:Gestion_Clinica_Veterinaria.ViewModels&Gestion_Clinica_Veterinaria.ViewModels  5   	   ,    &Gestion_Clinica_Veterinaria.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Gestion_Clinica_Veterinaria.Views     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   E
viewmodels4clr-namespace:Gestion_Clinica_Veterinaria.ViewModels  5   	     � Title$  
MainWindow��5
   	   $	��700��6   $
��1200��6)    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      <   6Gestion_Clinica_Veterinaria.ViewModels.MainWindowModel  5   
    � 	Resources 5       �� DataType=   7Gestion_Clinica_Veterinaria.ViewModels.ClienteViewModel3   -Gestion_Clinica_Veterinaria.Views.ClienteView<   6Gestion_Clinica_Veterinaria.ViewModels.AnimalViewModel2   ,Gestion_Clinica_Veterinaria.Views.animalView>   8Gestion_Clinica_Veterinaria.ViewModels.ConsultaViewModel4   .Gestion_Clinica_Veterinaria.Views.ConsultaView��%�   (��       5      *, +)(�� 2     5      *, +)(�� d     5       *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5    
   "  6   .R�5!        5"      5$      .��5&      ��  �� CornerRadius$ 10��6   $��1q�5'      ��5)   
   �� 5*       �� 
StartPoint$	 0,0&�6"   	 �� EndPoint$		 1,1&�63   .��5+      �    winBorderColor1
 � Color#
 [  6    � Offset$ 0Q�6H   � 5,        winBorderColor2#
 [ 6   $	 0.5Q�6H   � 5-        winBorderColor3#
 [ 6   $ 1Q�6H   5.      ._�51   
   �  � ColumnDefinitions 52      �� 53      $	��250 �6#   �� 54      $��* �6#   .+�58      �� $��0��6   $ 	10,0,0,10��59      ��5:      �� 5;      $	 0,0&�6*   $	 1,0.7&�6;   .��5<      �   secondaryBackColor1#
 [ 6'   $ 0Q�6T   � 5=        secondaryBackColor2#
 [ 6'   $ 1Q�6T   5>      ._�5A      �� .+�5C      ��  �� Orientation$ 
Horizontal=�6!   $��50��5D   !   $��
15,25,0,40q�5E   !   .+�5F      �� $��55��6    $���zC:\Users\alext\Desktop\AGUSTIN_2º\AAD\Gestion_Clinica_Veterinaria\Gestion_Clinica_Veterinaria\Resources\Images\perro5.png��6,   $��53��6�    J� RenderTransformOrigin$ 0.483,0.304&�6�   $��
-10,-8,0,0q�6�   �� 5G      $��Clinica Veterinaria��6$     titleColor2#��[ 5H   $   $��20(�5I   $   $��
Montserrat)�5J   $   $��Medium"�5K   $   $��Center=�5L   $   $��3,0,0,0q�5M   $   5N      	� 5R        
menuButton#��[ 6"    
 color4
 � Tag# [ 5S   "   ��5T   "   �� *ShowClienteViewComand+.��5V      �� $ 
Horizontal=�6%   .+�5W      !  FontAwesome.Sharp.IconImage  �	  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]] 	  Icon$ 	UserGroup=�6+     menuButtonIcon#��[ 6<   �� 5X      $��Clientes��6(    	 menuButtonText#��[	 68   5Y      5Z      	� 5\      #��[ 6"    

 color6# [
 5]   "   ��5^   "   �� *ShowAnimalViewComand+.��5`      �� $ 
Horizontal=�6%   .+�5a        $	 Cat=�6+   #��[ 66   �� 5b      $��Animales��6(   #��[	 68   5c      5d      	� 5f      #��[ 6"    
 color9# [ 5g   "   ��5h   "   �� *ShowConsultaViewComand+.��5j      �� $ 
Horizontal=�6%   .+�5k        $ 
KitMedical=�6+   #��[ 6=   �� 5l      $��Consulta��6(   #��[	 68   5m      5n      5p      5q      �� 5u      $��1��6   $ 	0,10,10,0��5v      ��5w      �� 5x      $	 1,1&�6*   $		 0,0&�6;   .��5y      �   primaryBackColor1#
 [ 6'   $ 0Q�6R   � 5z        primaryBackColor2#
 [ 6'   $ 1Q�6R   5{      ._�5~      �  � RowDefinitions 5      �� 5�      $��25 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ pnlControlBar��5�   !   $��0��5�   !   $ 
Horizontal=�5�   !   $��RightToLeft=�5�   !   
������ $��0,0,5,0q�5�   !   .+�5�      �� -   5         ��Name$ btnClose��5�   !     controlButton#��[ 5�   !   # [ 5�   !   .��5�        $ Xmark=�6+   $��12��68     controlButtonIcon#��[ 6C   5�      �� 5�      -   5        $ btnMaximice��5�   !   #��[ 5�   !   # [
 5�   !   .��5�        $ Square=�6+   $��12��69   #��[ 6D   5�      �� 5�      -   5        $ btnMinimice��5�   !   #��[ 5�   !    
 color8# [ 5�   !   .��5�        $ WindowMinimize=�6+   $��12��6A   #��[ 6L   5�      5�      �� 5�      $��1��5�   %   $��20,10,20,25q�5�   %   ��5�   %   �� *CurretChildView+5�   %   5�      5�      5�      5�      5�      