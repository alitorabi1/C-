   M S B A M L   `   `   `  ����E  AFamilyShow, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Microsoft.FamilyShowMicrosoft.FamilyShow  5      *    $Microsoft.FamilyShow.SharedBirthdays   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      4local"clr-namespace:Microsoft.FamilyShow     5        � 	Resources  5         GroupedListBox �� 
TargetType �� Property �� Value  MainBackgroundBrush  SolidBorderBrush  GroupedListBoxItem �� 
TargetType J� SnapsToDevicePixels ��Name �� Triggers P� Property	 P� Value # FamilyEditListViewSelectedBrush
 �� 
TargetName  DisabledForegroundBrush  GroupedListControlTemplate K� IsItemsHost  HeaderTemplate # SharedBirthdaysGroupHeaderColor �� Path 	 ItemDataTemplate 
 	FontColor��%}  &	        &	     &	 9    &	 w    &		 �    �� 5      " ��6#   .�5      ��  �@J�SnapsToDevicePixels . 6.   �� 5	       � ��# �  6%   �� 5
       � ��# �  6&   �� 5       � ��$
 Auto=�6E   �� 5       � ��$
 Auto=�6C   �� 5       � �� . 68   5      �� 5      " ��6'   .�5      ��  �@J�SnapsToDevicePixels . 6.   �� 5       �@�OverridesDefaultStyle . 60   �� 5       � �� 5   
   �� 5      " ��6   .R�5      �  . .+�5      �� $ Border��6   #��z��6'   #��z��6Q   #��z��6}   �� 5      #��z��6!   #��z��6d   5       5      P� 5       �@��
IsSelected	 . . �5      �� # �  6/   $
 Border��6i    � ��5      P� 5!       � {�	 .  . �5"      �� # �  6/    � ��5#      5%      5'   	   5(      �� 5*      " ��69   .R�5+      �  . 6   5,      �� 5.      .R�5/      �� #���  6   $��0,10,0,0q�6Q   ��6d   �� $
 Name�50      �� 52      .R�53      �� #��� 
 6   $��Medium"�6;   $��20,0,0,0q�6O   ��6a   �� $
 Name�54      55      .��57      ]� .+�58      �� -   5         ��Name$ GroupedItemsControl��58      $	��Top=�59      $��0,0,0,0q�5;      #��[ 5<      #��[	 5=      $��Disabled=�5>      $
��Auto=�5?      $	��Top=�5@      ��5:      Z�  �� 
GroupStyle 5B      (  "System.Windows.Controls.GroupStyle  5C   
      HeaderTemplate# [ 6   5E      5F      5G      