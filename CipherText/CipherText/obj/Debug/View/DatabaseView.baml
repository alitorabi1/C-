   M S B A M L   `   `   `  ����E  ACipherText, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CipherText
CipherText  5   d       CipherText.DatabaseView   6   "localclr-namespace:CipherText  6d   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6�   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6�   -   5          >�Name$  databaseView��5   7   -  'System.Windows.Input.KeyboardNavigation   TabNavigation$ Cycle=�6    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      Color$ 	#FF545454��6      ShadowDepth$ 5Q�6-    � 	Resources 5      .   (CipherText.CardTitleDataTemplateSelector !  cardTitleDataTemplateSelector   booleanToVisibilityConverter��%:   &	        &	        5   
   6.   �� 5   
   6'   5
      .��5      � .+�5   
   ��   databaseViewOuterBorder#��[ 6   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      ��   filterTextBorderStyle#��[ 6    �� CornerRadius$ 4,0,4,4��6H   ._�5      ]� .+�5      �� $��Right=�6�   $��X��6�     filterButtonStyle#��[ 6�   ��6!   ��  �� Path$ ResetFilterTextCommand�y�6Q   �� $ FilterButtonVisibility���6�   Z� �� 5      -   5        	 �� 	UndoLimit$	 4��5   ?   $
��Left=�6�     filterTextStyle#��[ 6�   ��6M   �� $ 
FilterText�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   5      5      �� 5      $��7,7,7,0q�6    �� Padding$ 2q�6*   $��1��66   ���	#FFB3B3B3$��1q�6Z   $ 4,0,4,4��6n   ���	#FF000000._�5      � $��0,0,18,0q�6    � ColumnDefinitions 5      �� 5       $��* �6/   $	��150��69   �� 5!      $	��100 �6/   �� 5"      $��40 �6/   �� 5#      $��40 �6/   .+�5%      �� $��Title��6$   �� 5&      $��Category��6$   $��1��64   �� 5'      $
��User��6$   $��2��60   $��Center=�6@   �� 5(      $	��Pwd��6$   $��3��6/   $��Center=�6?   5)      5*      �� 5,      $ Cycle=�6     FavsScrollViewer#��[ 6H   $��7,2,7,7q�6r   $��2��6�   $��Visible=�6�   .��5.      �� -   5        $��7,0,0,0q�5.   #   ��.  ��6e   �� $  CardViewModelSearchResults� � FocusVisualStyle 6�   Z� ��5/      �� 50      .R�51   "   ��  ��Name$ bd��6c   -   5         � ToolTip$ Double click to edit.��51   )   $��0,0,0,1q�6I   $	��0,2q�6o   |�.   searchResultItemStyle#��[ 6�   ._�52   &   �  53   *   �� 54   .   $��* �6?   $	��150��6I   �� 55   .   $	��100 �6?   �� 56   .   $��40 �6?   �� 57   .   $��40 �6?   .+�5:   *   �� |�.  
�������#��[  6v   ��6b   �� 6v   �� 5<   *   
�������$��1��6o   ��6G   �� $ Card.CardTypeName�6o   �� 5>   *    � Cursor$
 Hand��61   |�.  $��2��6    gridButtonStyle#��[ 6$  $! Copy user name to clipboard��6M  y�6Q   �� $ HasUserName� �� 	Converter# [ ��6�   �� $ CopyToClipboardCommand���6�   �� $ PrimaryUserName�.��5?   .   ��  	 	userImage#��[	 64   $��14��6X   $��14��6d   5@   +   �� 5A   *   $
 Hand��61   |�.  $��3��6  #��[ 6$  $  Copy password to clipboard��6M  y�6Q   �� $ HasPassword�# [ ��6�   �� $ CopyToClipboardCommand���6�   �� $ PrimaryPassword�.��5B   .   ��  
 keyImage#��[
 64   $��14��6W   $��14��6c   5C   +   5E   '   5F   #    �� Triggers 5G   "   P� 5H   &    P� Property �@J�IsMouseOver P� Value . . �5J   *   ��  �� 
TargetName$ bd��61    �� Property � �� �� Value �	#30A9A9A96W   �� 5K   *   $ bd��61    � ��
 �   �6X   5L   '   5N      5P      5Q      5R      5S      �� 5T   
     formAndButtonBarsBrush#��[ 6   $
��20,2q�6F   $ 5,1,5,1q�6T   
���   �$��1q�6z   $ 7,0,7,7��6�   $	��Top=�6�   $��Stretch=�6�   ._�5U      �� $��7q�6   $
��Bold"�6#   
�������$	��Top=�6m   $
��Left=�6�   ��6H   �� $ ViewingMessage�6�   5V      5W      5X      