   M S B A M L   `   `   `  ����E  ACipherText, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CipherText
CipherText  5   �        CipherText.FieldEditorView   6   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6(   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6j   *localclr-namespace:CipherText     6�     � 	Resources  5      #   CipherText.FieldTypeConverter   fieldTypeConverter   booleanToVisibilityConverter��%:   &	        &	        5      6   �� 5      6#   5      .��5      �� $	��3.5q�6   ��5	      �� 5
       �� 
TargetType" ��6    �� Triggers 5   
   �� 5       �� Binding 6   ��  �� Path$ IsFieledInEditMode� �� Value True6D   .a�5      ��  �� Property �@��Padding �� Value$ 0,3.5, 0, 0q�6(   �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   �� 5       �@��CornerRadius$ 7,0,7,7��6-   5      5   	   ._�5      �  � ColumnDefinitions 5      �� 5   
   $	��125 �6   �� 5   
   $��* �6   $	��100��6%   �� 5   
   $��23 �6   �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5    
   $
��Auto �6   	 � RowDefinitions	 5#      �� 5$   
   $
��Auto �6   �� 5%   
   $
��Auto �6   .+�5(      �� -   5        
 ��Name$
 
tbFieldTag��5(       � Cursor$
 Hand��6&   $��Center=�64   $��Stretch=�6O   $
��Wrap=�6m   $��10,0,0,0q�6�   ��6�   �� $ CardField.FieldTag��� 5*      -   5         ��Name$ txtFieldTag��5*   "   $��10,0,0,0q�6    �� 	MaxLength$	 100��5+   G   y�5*   7   �� $ InSchemaEditingMode� �� 	Converter# [ ��5+   W   �� $ CardField.FieldTag� �� StringFormat$
 {0:}�� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ 	LostFocus=� �� NotifyOnValidationError .  �� ValidatesOnDataErrors .  �� ValidatesOnExceptions . .��52   .   ��53   
   �� 54       �� BasedOn# [B��6   " ��6>    55      �� 56       6   �� $ CardField.FieldTag� 	Change Me6H   .a�57      ��  � ��
 �  ��67   58      5:      .��5;      5<   	   �� 5>      -   5        $ txtFieldData��5>   "   $��10,0,0,0q�6   $��1��68    6H   �� $ CardField.MaximumLength���6{   �� $ CardField.FieldData�$
 {0:}��$ TwoWay=�$ 	LostFocus=� .  .  . �� 5G      ��.   � ToolTip$% Click to generate new password.��6R   $��2��6|   $��16��6�   $��16��6�     gridButtonStyle#��[ 6  ��6!   �� $ GeneratePasswordCommand�y�6�   �� $ CardField.FieldType�# [  .��5H   
   ��   keyImage#��[ 6   $��UniformToFill=�63   5I   	   �� 5K      -   5        $ txtFieldSortOrder��5K      $
��10,0q�6+   ��.  $��3��6�   $ 3��6�   $��50��6�   y�6K   �� $ InSchemaEditingMode�# [ ��6�   �� $ CardField.FieldSortOrder�$ TwoWay=�$ 	LostFocus=� .  .  . �� 5M      $	��7,0q�6   ��.  $ Click to edit this field.��6X   $��4��6|   $��14��6�   $��14��6�   #��[ 6  ��6.   �� $ EditFieldCommand�y�6�   �� $ InSchemaEditingMode�# [ .��5N   
   ��   	editImage#��[ 6   $��UniformToFill=�64   5O   	   �� 5Q      $	��7,0q�6   ��.  $( "Click to contract this edit field.��6`   $��4��6�   $��16��6�   $��16��6�     editOkButtonStyle#��[ 6  ��6.   �� $ ContractEditFieldCommand�y�6�   �� $ IsFieledInEditMode�# [ 6  �� 5S      $	��7,0q�6   ��.  $/ )Click to remove this field from the form.��6Z   $��5��6�   $��14��6�   $��14��6�   #��[ 6  ��6.   �� $ RemoveFieldCommand�y�6�   �� $ InSchemaEditingMode�# [ .��5T   
   ��   deleteImage#��[ 6   $��UniformToFill=�66   5U   	   � 5W      $��11,7,0,7q�6u   $��1��6�   $��0��6�   $��6��6�   y�6   �� $ IsFieledInEditMode�# [  5X   
   �� 5Y      $
��Auto �6   �� 5Z      $
��Auto �6   �� 5[      $
��Auto �6   �� 5\      $
��Auto �6   �� 5]      $	��140 �6   �� 5^      $
��Auto �6   �� 5_      $	��115 �6   �� 5`      $��* �6   .+�5b   
   �� $��0��6   $��Max Len��6$   $��Center=�63   �� 5c   
   -   5        $ txtMaximumLength��5c      $��1��6,   $��Center=�6<   $��10,0,0,0q�6W   $ 3��6i   $��50��6w   ��6�   �� $ CardField.MaximumLength�$ TwoWay=�$ 	LostFocus=� .  .  . �� 5d   
   $��2��6   $��Is Required��6#   $��Center=�69   $��11,0,0,0q�6T    d� 	IsChecked 6f   �� $ CardField.IsRequired�$ PropertyChanged=� .  .  . �� 5e   
   $��3��6   $��11,0,0,0q�6$   $
��Type��66   $��Center=�6B   �� 5f   
   $��4��6   $��7,0,0,0q�6#    �� SelectedValuePath$ Value��6�    �� DisplayMemberPath$ DisplayName��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   ��64   �� $ AvailableFieldTypes� �� SelectedValue 6e   �� $ CardField.FieldType�6�   �� 5g   
   $��5��6   $��11,0,0,0q�6$   $
��Case��66   $��Center=�6B   �� 5h   
   $��6��6   $��7,0,0,0q�6#   $ Value��6�   $ DisplayName��6�   $
 TrueY�6�   ��64   �� $ AvailableFieldCases� 6e   �� $ CardField.FieldCase�6�   5j   	   �� 5m      -   5        $��2��5m      $��6��6�   
�������
���   �$��1q�6   �� CornerRadius$ 7,0,7,7��6!  y�6L   �� $ IsMarkedForDelete�# [  �� NotifyOnTargetUpdated . ._�5n   
   �  5o      �� 5p      $��* �6   �� 5q      $
��Auto �6   .+�5s      ��  �� Orientation$ 
Horizontal=�6   $��Center=�60   $��Center=�6K   .+�5t      �� 
���   �$
��Bold"�6+   $��0,0,7,0q�6f   ��6=   �� $ CardField.FieldTag�6f   �� 5u      
���   �$
��Bold"�6+   $��will be removed on Save��6=   $��Center=�6\   $��Center=�6w   $��NoWrap=�6�   $��CharacterEllipsis=�6�   5v      �� 5w      $��0,0,8,0q�6   $��1��6$   $��Right=�64   ��.  $1 +Click to restore deleted field to the form.��6�   $��14��6�   $��14��6�   #��[ 6�   ��6b   �� $ RestoreFieldCommand�.��5x      ��   addImage#��[ 6   $��UniformToFill=�67   5y      5z      5|   	   5}      5~      5�      