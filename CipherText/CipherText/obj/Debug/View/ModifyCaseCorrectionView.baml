   M S B A M L   `   `   `  ����E  ACipherText, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CipherText
CipherText  5   �   )    #CipherText.ModifyCaseCorrectionView   6	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6E   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6�   *localclr-namespace:CipherText     6�     � WindowStyle$  
ToolWindow=�6,    � Title$ Modify Casing Rules��6�   $	��340��6  $	��500��6  $	��340��6   � 	Resources 5       �� DataType.   (CipherText.CharacterCasingCheckViewModel � ColumnDefinitions �� Path �� Mode �� UpdateSourceTrigger �� NotifyOnValidationError	 �� ValidatesOnDataErrors
 �� ValidatesOnExceptions � ToolTip   gridButtonStyle  deleteImage��%�  (��       5      *, +)7   7  �� 6
   "  6   .R�5      �  5      �� 5      $	��100 �6'   �� 5      $	��100 �6'   �� 5	      $��50 �6'   .+�5      �� $��0��6   $��80��6*   ��65   �� $" CharacterCasingCheck.LookFor�$ TwoWay=�$ PropertyChanged=� . 	 . 
 . �� 5      $��1��6   $��80��6*   ��65   �� $&  CharacterCasingCheck.ReplaceWith�$ TwoWay=�$ PropertyChanged=� . 	 . 
 . �� 5      $��Center=�6   $��2��66   ��.  $' !Click to delete this casing rule.��6�   $��14��6�   $��14��6�   8��  ��6X   �� $' !DeleteCharacterCasingCheckCommand���6�   �� .��5      �� 8�� $��UniformToFill=�6B   5      5      5      5      .��5      � ���	#FF3A3A3A J� OpacityMask 5   
   �� 5       �� EndPoint$ 0.995,0.982&�6"    �� 
StartPoint$ 0.028,0.035&�69   .��5      �  � Color$ 	#FF000000��6    � Offset$ 0.129Q�61   � 5      $ 	#DDFFFFFF��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      .+�5%   
   �� 
������ $��Stretch=�6-   $	��Top=�6K   $��./../Fonts/#OCR A)�6c   $��18(�6�   $
��Bold"�6�   ���	#FFFFFFFF$��Modify Casing Rules��6�   $��7q�6�    J� Effect 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'   	   5)      �� 5+   
   $��1��6   $��11,0,0,0q�6!   
�������$;��5Please view 'How To' video before using this feature.��6K   �� 5-   
     editingFormBackgroundBrush#��[ 6   $��11,11,11,20q�6J   $��2��6_   
�������$��2q�6�    �� CornerRadius$ 7,0,7,7��6�    �� Padding$ 10q�6�   ._�5/      �  50      �� 51      $
��Auto �6$   �� 52      $��* �6$   �� 53      $
��Auto �6$   .+�56      �� $ 2q�6   ���	#FFB3B3B3$��1q�6<   $ 4,0,4,4��6P   ���	#FF000000._�57      �  58      �� 59      $	��100 �6/   �� 5:      $	��100 �6/   �� 5;      $��50 �6/   .+�5=      �� $��Look For��6$   �� 5>      $��Replace With��6$   $��1��68   �� 5?      $	��Del��6$   $��2��6/   $��Center=�6?   5@      5A      �� 5C      -   5         ��Name$&  svCharacterCasingCheckViewModels��5C   0   $��0,3,0,0q�6   $��1��6Z     FavsScrollViewer#��[ 6g   $��Visible=�6�   .��5D      �� ��.  ��6#   �� $$ CharacterCasingCheckViewModels� � FocusVisualStyle 6_   Z� 6{   5E      �� 5G      $��11,11,44,11q�6   |�.  $��2��6@   $��Right=�6M   ��.  $! Click to add a casing rule.��6�   $��18��6�   $��18��6�   #��[  6�   ��6{   �� $$ AddCharacterCasingCheckCommand�.��5H      ��   addImage#��[ 6   $��UniformToFill=�6?   5I      5J      5L      �� 5N   
   $��2��6     formAndButtonBarsBrush#��[ 6   $��	20,0,20,8q�6S   $��Bottom=�6f   $	 3.5q�6�   
���   �$��1q�6�   $ 7,0,7,7��6�   $��Stretch=�6�   ._�5O      �� $��Center=�6   $	��3.5q�66    �� Orientation$ 
Horizontal=�6C   .+�5P      �� $
��11,0q�6   $��12(�6*   �� 69    � ToolTip$&  Click to save changes and close.��6h    �� Command 6C   �� $ SaveCommand�.�6�   �� $
�Save��6�   6�   6�   �� 5Q      $
��11,0q�6   $��12(�6*   �� 69   $ Click to cancel.��6j    6C   �� $ CancelCommand�.�6�   �� $�Cancel��6�   6�   6�   �� 5R      $y�Visible=�6   ��.  |�.  $��1��6R   $��1��6]    �� IsCancel . ��6w   �� $ CancelCommand�5S      5T      5V      5X      