   M S B A M L   `   `   `  ����  PeopleDB    PeopleDB.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��365��6   $	��568��6)    � 
ResizeMode$ NoResize=�65   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgPerson��5         AutoGenerateColumns .  $
��Left=�6A   $	��308��6\   $��	10,10,0,0q�6i   $	��Top=�6|   $	��316��6�      
IsReadOnly .    Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6!      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *Id+6D     5	      $ First and Last Name��6%   	   
IsReadOnly	 . $ 5* 6m    6T   �� *Name+6m     5
      $	 Age��6%   $ 1* 6J    62   �� *Age+6J   5      �� 5   
   $��Id��6   $
��Left=�6   $��
348,30,0,0q�68   $	��Top=�6L   
 J� RenderTransformOrigin$
 0.132,-0.269&�6d   $��42��6�   �� 5   
   $
��Name��6   $
��Left=�6   $��
348,78,0,0q�6:   $	��Top=�6N   $
 
0.5,-0.385&�6f   �� 5   
   $	��Age��6   $
��Left=�6   $��352,126,0,0q�69   $	��Top=�6N   �� 5   
   -   5         ��Name$
 lbId��5      $�� ��6   $
��Left=�6)   $��
433,30,0,0q�6D   $	��Top=�6X   $	��109��6p   �� 5   
   -   5         ��Name$ tbName��5      $
��Left=�6"   $��23��6=   $��
433,78,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��109��6�   �� 5   
   -   5        $ tbAge��5      $
��Left=�6!   $��23��6<   $��433,126,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��109��6�   �� 5   
   -   5         ��Name$ btAdd��5      $	��Add��6    $
��Left=�6.   $��352,181,0,0q�6I   $	��Top=�6^   $	��190��6v   6�   �� 5   
   -   5        $ btUpdate��5      $��Update��6#   $
��Left=�64   $��352,235,0,0q�6O   $	��Top=�6d   $	��190��6|   6�   �� 5   
   -   5        $ btDelete��5      $��Delete��6#   $
��Left=�64   $��352,286,0,0q�6O   $	��Top=�6d   $	��190��6|   6�   5      5      