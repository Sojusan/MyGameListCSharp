   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MyGameList.WindowsMyGameList.Windows  5   	   *    $MyGameList.Windows.EditAccountWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MyGameList.Windows     5   	     � Title$  
MyGameList��5   	   $	��600��6   $	��800��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   .��5	      � .+�5
   
   �� ���	#FF0FB200$
��Left=�6%   $��70��6@   ���	#FF0FB200$	��Top=�6_   $	��794��6w   �� 5   
   $
��Left=�6   $��
279,19,0,0q�6/   $
��Wrap=�6C   $��Account Information��6W   $	��Top=�6r   $
��Bold"�6�   $��24(�6�   
�������6�   �� 5   
   $
��Left=�6   $��
71,222,0,0q�6/   $
��Wrap=�6C   $��Nickname��6W   $	��Top=�6g   $��16(�6   �� 5   
   -   5         ��Name$ NicknameTextBox��5      $
��Left=�6+   $��21��6F   $��159,225,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��205��6�   ���	#FF0FB2006�   �� 5   
   $
��Left=�6   $��
90,272,0,0q�6/   $
��Wrap=�6C   $��Gender��6W   $	��Top=�6e   $��16(�6}   �� 5   
   -   5         ��Name$ GenderComboBox��5      $
��Left=�6+   $��159,272,0,0q�6F   $	��Top=�6[   $	��120��6s   .@�5      �� $
��Male��6   �� 5      $��Female��6   5      �� 5   
   $
��Left=�6   $��
344,95,0,0q�6/   $
��Wrap=�6C   $��Preview��6W   $	��Top=�6f   $��16(�6~   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��225��6T   $��
412,95,0,0q�6a   $	��Top=�6u   $	��350��6�   ._�5      �� -   5         ��Name$ AvatarImage��5      $
��Fill=�6)   5      �� 5   
   $
��Left=�6   $��495,340,0,0q�6/   $
��Wrap=�6D   $��Choose Avatar��6X   $	��Top=�6m   $��16(�6�   �� 5   
   -   5        $��Select File��5   2   $
��Left=�6H   $��602,339,0,0q�6c   $	��Top=�6x   $��85��6�   $��26��6�   ���	#FF0FB200���	#FF0FB200
�������6�   �� 5   
   -   5        $��Confirm��5   /   $
��Left=�6A   $��140,466,0,0q�6\   $	��Top=�6q   $	��139��6�   $��61��6�   ���	#FF0FB200���	#FF0FB200
�������$��24(�6�   �� 5   
   -   5        $��Cancel��5   .   $
��Left=�6?   $��495,466,0,0q�6Z   $	��Top=�6o   $	��139��6�   $��61��6�   ���	#FF0FB200���	#FF0FB200
�������$��24(�6�   �� 5   
   -   5         ��Name$ NicknameErrorTextBlock��5      
���  ��$
��Left=�6E   $��168,204,0,0q�6`   $
��Wrap=�6u   $��	TextBlock��6�   $	��Top=�6�   $y�Hidden=�6�   5      5      