   M S B A M L   `   `   `  ����  
CipherText)    #CipherText.ChangePasswordDialogView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6d   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6�     � WindowStyle$  
ToolWindow=�6,    � SizeToContent$ WidthAndHeight=�6E    � Title$ Change Password��6�   .��5      � ���	#FF3A3A3A J� OpacityMask 5   
   �� 5       �� EndPoint$ 0.995,0.982&�6"    �� 
StartPoint$ 0.028,0.035&�69   .��5      �  � Color$ 	#FF000000��6    � Offset$ 0.129Q�61   � 5      $ 	#DDFFFFFF��6   $ 1Q�61   5	       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� 
������ $��Stretch=�6-   $	��Top=�6K   $��./../Fonts/#OCR A)�6c   $��18(�6�   $
��Bold"�6�   ���	#FFFFFFFF$��Change Password��6�   $��7q�6�   	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   	   5      �� 5   
   $	��100��6      editingFormBackgroundBrush#��[  6   $��11,11,11,25q�6W   $��1��6l   
�������$��2q�6�   
 �� CornerRadius$
 7,0,7,7��6�    �� Padding$ 10q�6�   ._�5      �  5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$    � ColumnDefinitions 5      �� 5      $	��110 �6'   �� 5       $��* �6'   .+�5#      �� $��0��6   $��0��6(   $��Current Password��65   �� 5$      $��0��6   $��1��6(   $��New Password��65   G� 5&      -   5         G�Name$ txtCurrentPassword��5&      $��1��6:   $��0��6J   $	��150��6W    G� 	MaxLength$ 30��6c   $
��Left=�6r   $	��Top=�6�   �� 5'      $��1��6a   $��1��6q   $	��150��6~    �� 	MaxLength$ 30��6�   $
��Left=�6�   $	��Top=�6�   ��6   ��  �� Path$ NewPassword� �� UpdateSourceTrigger$ PropertyChanged=�6�   5)      5+      �� 5-   
   $��1��6     formAndButtonBarsBrush#��[ 6   $��20,10q�6S   $��Bottom=�6b   $	 3.5q�6}   
���   �$��1q�6�   $
 7,0,7,7��6�   $��Stretch=�6�   ._�5.      �� $��Center=�6   $	��3.5q�66    �� Orientation$ 
Horizontal=�6C   .+�5/      �� $
��11,0q�6   $��12(�6*   �� 69    � ToolTip$&  Click to save changes and close.��6h    �� Command 6C   �� $ SaveCommand�.�6�   �� $
�Save��6�   6�   6�   �� 50      $
��11,0q�6   $��12(�6*   �� 69   $ Click to cancel.��6j    6C   �� $ CancelCommand�.�6�   �� $�Cancel��6�   6�   6�   �� 51      $y�Visible=�6   ��.  |�.  $��1��6R   $��1��6]    �� IsCancel . ��6w   �� $ CancelCommand�52      53      55      57      