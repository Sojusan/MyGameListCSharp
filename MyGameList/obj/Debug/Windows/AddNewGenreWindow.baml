   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MyGameList.WindowsMyGameList.Windows  5   	   *    $MyGameList.Windows.AddNewGenreWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MyGameList.Windows     5   	     � Title$  
MyGameList��5   	   $	��450��6   $	��800��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   .��5	      � .+�5
   
   �� ���	#FF0FB200$
��Left=�6%   $��70��6@   ���	#FF0FB200$	��Top=�6_   $	��792��6w   �� 5   
   $
��Left=�6   $��
280,18,0,0q�6/   $
��Wrap=�6C   $��Adding New Genre��6W   $	��Top=�6o   $��24(�6�   $
��Bold"�6�   
�������6�   �� 5   
   $
��Left=�6   $��
346,85,0,0q�6/   $
��Wrap=�6C   $��Genres��6W   $	��Top=�6e   $
��Bold"�6}   $��24(�6�   �� 5   
   $
��Left=�6   $��236,135,0,0q�6/   $
��Wrap=�6D   $��Genre*��6X   $	��Top=�6f   $��16(�6~   �� 5   
   -   5         ��Name$ GenreTextBox��5      $
��Left=�6(   $��23��6C    �� TextWrapping$
 Wrap=�6O   $	��Top=�6c   $	��287��6{   $��304,135,0,0q�6�   ���	#FF0FB2006�   �� 5   
   $
��Left=�6   $��191,190,0,0q�6/   $
��Wrap=�6D   $��Available Genres��6X   $	��Top=�6p   $
��Bold"�6�   �� 5   
   ���	#FF0FB200$��1q�6)   $
��Left=�6=   $	��117��6X   $��118,211,0,0q�6e   $	��Top=�6z   $	��602��6�   ._�5      �� -   5         ��Name$ AvailableGenresTextBlock��5      $
��Wrap=�6:   $�� ��6N   {�.  6V   5      �� 5   
   -   5        $��Confirm��5   /   $
��Left=�6A   $��236,344,0,0q�6\   $	��Top=�6q   $	��122��6�   $��50��6�   ���	#FF0FB200���	#FF0FB200
�������$��20(�6�   �� 5   
   -   5        $��Cancel��5   .   $
��Left=�6?   $��469,344,0,0q�6Z   $	��Top=�6o   $	��122��6�   $��50��6�   ���	#FF0FB200���	#FF0FB200
�������$��20(�6�   �� 5   
   -   5        $ GenreErrorTextBlock��5      
���  ��$
��Left=�6B   $��604,139,0,0q�6]   $
��Wrap=�6r   $��This can't be empty !��6�   $	��Top=�6�   $y�Hidden=�6�   5      5      