   M S B A M L   `   `   `  ����E  AFamilyShow, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Microsoft.FamilyShowMicrosoft.FamilyShow  5      #    Microsoft.FamilyShow.TagCloud   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      4local"clr-namespace:Microsoft.FamilyShow     5      -   5        $��MainElement��5   ,     � 	Resources  5      3  -Microsoft.FamilyShow.CountToFontSizeConverter   CountToFontSizeConverter  TagsListBox �� 
TargetType �� Property �� Value �� ElementName �� Path �� 
TargetType ��Name K� IsItemsHost  TagCloudTemplate	 �� Padding
 �� Mode `� 	Converter �� RelativeSource �� AncestorType#   Microsoft.FamilyShow.TagCloud  TagCloudListBoxItem J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	      &	 z    7   &	 �      5   
   6)   �� 5
   
   " ��6$   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       � �� 6+   �� $ MainElement��$ ListBackgroundBrush��� 5       � �� 6,   �� $ MainElement��$ ListBorderBrush��� 5       � ��$
 Auto=�6K   �� 5       � ��$
 Auto=�6I   �� 5       � �� . 6>   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ Border��6%   #��z��65   #��z��6a   �� 5      $��1q�6+   |�.  #��z��6H   .��5   "   � $��2q�6,    . 67   5      5      5      5      5       �� 5"   
   .R�5#      �� $	 0,0,10,0q�6   $��Bottom=�5$   6   ��5#   +   �� $ MainElement��$ 
Foreground���5$      �� $
 Name�$
 Default=���5%      `� 5&      8   .1�5'      �� $
 OneWay=�6   $ 	ItemCount�6,   �� 5(       6   �� *FindAncestor+"  5)      5+      5,      �� 5.   
   " ��6,   .�5/      ��  �@J�SnapsToDevicePixels . 64   �� 50       �@�OverridesDefaultStyle . 66   �� 51       � �� 52      �� 53      " ��6&   .R�54      �  . .+�55      �� $ Border��6%   #��z��65   #��z��6_   #��z��6�   �� 56      #��z��6/   #��z��6r   57       58      P� 5;       �@��
IsSelected . . �5<   "   �� $ Border��6}    6?   �� $ MainElement��$ SelectedBrush� � ��6}   5=      P� 5>       � {� .  . �5?   "   ��  6?   �� $ MainElement��$ DisabledForegroundBrush� � ��5@      5B      5D      5F      5G      .��5I      �� -   5         ��Name$ TagCloudListBox��5I      #���  6'   #���  5J      $��Disabled=�67   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5K      #���  6*   $��Stretch=�6P   $��0,0,0,0q�5L   9   5N      5P      