   M S B A M L   `   `   `  ����E  ACipherText, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CipherText
CipherText  5   �   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics 6  *    $CipherText.ApplicationMainWindowView   6	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6-   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6o   *localclr-namespace:CipherText     6�   Mdiagnostics5clr-namespace:System.Diagnostics;assembly=WindowsBase     6  @d2http://schemas.microsoft.com/expression/blend/2008     6}  Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�     applicationBackgroundBrush#��[  6�     � Title$  Cipher Text��6P  $	��750��6d  $	��800��6q   � 	Resources 5       �� DataType)   #CipherText.CardTypeCommandViewModel$   CipherText.CardTypeCommandView   booleanToVisibilityConverter  OnMouseEnterStackPanel	 W� To g� Duration �� 
TargetName �� TargetProperty  OnMouseLeaveStackPanel��%~  (��       5      *, +)&	 .     &	 A     &	 �     �� 6
   "  6   .R�5        5      �� 5   
   6'   �� 5
   
   .��5      W� $ 1X�6   $ 00:00:00.001D�6%   $ 
stackPanel��6=   $ (UIElement.Opacity)�6`   5      �� 5   
   .��5      W� $	 .45X�6   $ 00:00:00.001D�6'   $ 
stackPanel��6?   $ (UIElement.Opacity)�6b   5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ Mouse.MouseEnter��6   	 :� 
SourceName$	 
stackPanel��66   .[�5      �� #��[ 6   5      :� 5   
   $ Mouse.MouseLeave��6   $	 
stackPanel��66   .[�5      �� #��[ 6   5      .��5      � ���	#FF3A3A3A
 J� OpacityMask
 5    
   �� 5!       �� EndPoint$ 0.995,0.982&�6"    �� 
StartPoint$ 0.735,0.151&�69   .��5"      �  � Color$ 	#FF000000��6    � Offset$ 0.129Q�61   � 5#      $ 	#BBFFFFFF��6   $ 1Q�61   5$       � ColumnDefinitions 5&   
   �� 5'      $	��250 �6   �� 5(      $��10 �6   �� 5)      $��* �6   .+�5,   
      CipherText.XAMLShield  $��3��6    J� Opacity$ 0.065Q�6/   $
��Left=�6?   $	��Top=�6Z    � LayoutTransform 5-      V� 5.      .~�5/      ��  �� ScaleX$ 2Q�6%    �� ScaleY$ 2Q�60   �� 50       �� AngleX$ 0Q�6$    �� AngleY$	 -15Q�6/   51      53      �� 55   
   $��0,49,0,0q�6   $��0q�6;   $
��Auto=�6O      alternatingListViewItemStyle#��[ 6    �� AlternationCount$ 2��6�   ��6%   Z� ��6�   ��  �� Path$ CardTypeCommands� 56       �� Color��%�   (��       57   "   * SystemColors.HighlightBrushKey+)(�� %     58   "   *SystemColors.ControlBrushKey+)�� 57      $ Transparent��6T   �� 58      $ Transparent��6R   59      5:      �� 5=   
   ���	#70000000$��0,0,0,0q�6�   $��3��6�   y�6   �� $ EditingRecord� �� 	Converter# [ 6�   �� 5>   
   ���	#FF000000$��Stretch=�67   $	��Top=�6U   $��15��6m   $��	-10,0,0,0q�6y   $��1��6�   $��2��6�   ��6%   Z�  J� Effect 5?      3  -System.Windows.Media.Effects.DropShadowEffect  5@         Color$ 	#FF545454��6#      ShadowDepth$ 7Q�65   5B      F� 5C   
   ���	#FF000000 �� Stretch$
 Fill=�6    $��Stretch=�6A   $��	-10,0,0,0q�6_   $	��Top=�6r   $��45.365��6�   �����        �        b����NA<Z׿b����NA<Z׿Sb����NA<Z׿ ����@ 2�@D� Ӛ5�X�����p�DL6�P,I�'��e��e��hQb΢��    A��	��6/   Z�  5D        5E      $ 	#FF545454��6#   $ 7Q�65   5G      F� 5H   
   ���	#FF000000$
 Fill=�6    $��Stretch=�6A   $��0,-0.365,-0.955,0q�6_   $	��Top=�6z   $��45.365��6�   �����        �        b����NA<Z׿b����NA<Z׿Sb����NA<Z׿ ����@ 2�@D� Ӛ5�X�����p�DL6�P,I�'��e��e��hQb΢��    A��	��6/   Z� 6�   �� 5J   
   
������ $
��Left=�6-   $	��Top=�6H   $��./../Fonts/#OCR A)�6`   $��32(�6   $
��Bold"�6�   ���	#FFFFFFFF$��Cipher Text��6�   $
��Wrap=�6�   $��5,5,0,0q�6�    5K        5L   	   $ 	#FFAFAFAF��6   $ 4Q�6,      
BlurRadius$ 5Q�6<   5N      �� 5O   
   ���	#FF000000$��Stretch=�67   $	��Top=�6U   $��15��6m   $��1��6y   $��2��6�   ��6%   Z� 6�   �� 5Q   
   -   5         ��Name$ 
stackPanel��5Q   �   ���	#00000000$��2��6,     �� Orientation$  
Horizontal=�6<   $��Right=�6U   $��0,3,10,0q�6q   $	��Top=�6�   $
 0.45Q�6�   .+�5R      �� $��0,0,18,0q�6   $��Arial)�6*   $��Center=�6=   �� 5S      -   5        ! ��Name$! hlOnTop��5S   :   $��10(�6K   .�6Y   .�5T      �� -   5        " ��Name$" tbOnTop��5T   (   5U      5V      �� 5X      $��0,0,18,0q�6   $��Arial)�6*   $��Center=�6=   �� 5Y      -   5        $��10(�5Y   C   .�6Q   Change Password6b   5Z      �� 5\      $��Arial)�6   $��Center=�6+   �� 5]      -   5        $��10(�5]   C   # � ToolTip$;# 5View Silverlight 'How to' help video for Cipher Text.��6Q   .�6�   'How To' Video6�   5^      �� 5_      $��	18,0,18,0q�6   $��Arial)�6+   $��Center=�6>   �� 5`      -   5        $��10(�5`   K   $0# *View Code Project article for Cipher Text.��6Y   .�6�   Code Project Article6�   5a      �� 5b      $��Arial)�6   $��Center=�6+   �� 5c      -   5        $��10(�5c   =   $# Visit Karl's blog.��6K   .�6h   Karl's Blog6u   5d      5e      � 5g   
   $��2��6   $��0,25,7,7q�6   .+�5h         CipherText.DatabaseView  $ � DataContext$ 6!   �� $ DataBaseViewModel�   CipherText.DataEditorView  5j      $ 6#   �� $ DataEditorViewModel�5k      5m      5o      