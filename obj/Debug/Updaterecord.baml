   M S B A M L   `   `   `  ����F  BAT3-Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AT3_ProjectAT3_Project  5   	       AT3_Project.Updaterecord   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AT3_Project     5   	     � Title$  Updaterecord��5   	   $	��450��6   $	��800��6+   
����ح�.��5
      �  � ColumnDefinitions 5   
   �� 5      $��8 �6   �� 5      $
��158* �6   �� 5      $
��233* �6   �� 5      $��2 �6   �� 5      $��8 �6    � RowDefinitions 5   
   �� 5      $��8 �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��8 �6   .+�5   
   �� -   5         ��Name$ SelectedEmployeeId��5      $��employee__id��6,   $��1��6C   $��2��6S   $��Center=�6`   $
��Left=�6{   $��26��6�   �� 5   
   -   5        $ SalaryUpdate��5      $��
New Salary��6&   $��1��6;   $��3��6K   $��Center=�6X   $
��Left=�6s   $��26��6�   �� 5   
   -   5         ��Name$ EmployeeTextBox��5       �� TextWrapping$
 Wrap=�6+   $�� ��6?   $��2��6G   $��	2,10,7,10q�6W   $��2��6j    �� 
IsReadOnly .  6w   �� 5   
   -   5        $ SalaryTextBox��5      $
 Wrap=�6)   $�� ��6=   $��2��6E   $��	2,10,2,10q�6U   $��3��6h   �� 5   
   -   5         ��Name$ ButtonStackPanel��5      $��2��6/   $��4��6?    �� Orientation$ 
Horizontal=�6L   .+�5      �� -   5        	 ��Name$
	 Save��5      
�������
���   �$
��Save��6M   $��	0,4,0,3.8q�6\   $
��16,4q�6o   $	��150��6�   �� 5       -   5        $	 Clear��5       
�������
���   �$��Clear��6N   $��	0,4,0,3.8q�6_   $
��16,4q�6r   $	��150��6�   6�   �� 5!      -   5        $	 Close��5!      
�������
���   �$��Close��6N   $��	0,4,0,3.8q�6_   $
��16,4q�6r   $	��150��6�   6�   5"      5#      5$      