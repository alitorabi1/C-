   M S B A M L   `   `   `  ����  ZooFull    ZooFull.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $��255.085��6   $	��525��6-   .��5      � .+�5   
   o� $
��Left=�6   $��27��6*   $	��Top=�66   $	��518��6N   .@�5      m� $
��File��6   .@�5      m� -   5        $��_Open...��5      6-   m� 5	      -   5        $��Save _As...��5	      60   m� 5
      -   5        $��E_xit��5
      6*   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgAnimals��5         
IsReadOnly .    SelectionMode$ Single=�68   $	��192��6O   $��	0,0,317,0q�6\   $��Bottom=�6o    � ContextMenu 5      �� 5      .@�5      m� -   5        $��Remove record��5      66   5      5      �� 5      -   5         ��Name$ label��5      $��Species��6'   $
��Left=�69   $��
216,45,0,0q�6T   $	��Top=�6h   $��69��6�   �� 5   
   -   5        $ label1��5      $
��Name��6    $
��Left=�6/   $��
216,86,0,0q�6J   $	��Top=�6^   $��69��6v   �� 5   
   -   5        $ label2��5      $	��Age��6    $
��Left=�6.   $��216,129,0,0q�6I   $	��Top=�6^   $��69��6v   �� 5   
   -	   5        $ label3��5      $��Weight��6    $
��Left=�61   $��216,173,0,0q�6L   $	��Top=�6a   $��69��6y   �� 5   
   -
   5         ��Name$ 	cbSpecies��5      $
��Left=�6&   $��
300,45,0,0q�6A   $	��Top=�6U   $��86��6m   .@�5      ��  �� 
IsSelected . $��10(�6-   .��6;   --Select option--6N   �� 5       .��6   Cat6    �� 5!      .��6   Rabbit6#   �� 5"      .��6   Tiger6"   �� 5#      .��6   	Dolphin6$   �� 5$      .��6   Lion6!   5%      �� 5&   
   -   5         ��Name$ tbName��5&      $
��Left=�6"   $��23��6=   $��
300,86,0,0q�6I   	 �� TextWrapping$
	 Wrap=�6]   $	��Top=�6q   $��86��6�   �� 5'   
   -   5        $ tbAge��5'      $
��Left=�6!   $��23��6<   $��300,129,0,0q�6H   $
	 Wrap=�6]   $	��Top=�6q   $��86��6�   �� 5(   
   -   5        $ tbWeight��5(      $
��Left=�6$   $��23��6?   $��300,173,0,0q�6K   $
	 Wrap=�6`   $	��Top=�6t   $��86��6�   �� 5)   
   -   5        
 ��Name$
 btAdd��5)      $	��Add��6    $
��Left=�6.   $��
421,45,0,0q�6I   $	��Top=�6]   $��75��6u   6�   �� 5*   
   -   5        $
 btUpdate��5*      $��Update��6#   $
��Left=�64   $��
421,86,0,0q�6O   $	��Top=�6c   $��75��6{   6�   �� 5+   
   -   5        $
 btDelete��5+      $��Delete��6#   $
��Left=�64   $��421,129,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5,   
   -   5        $
 btExit��5,      $
��Exit��6!   $
��Left=�60   $��421,173,0,0q�6K   $	��Top=�6`   $��75��6x   6�   5-      5.      