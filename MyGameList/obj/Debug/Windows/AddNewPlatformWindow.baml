   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MyGameList.WindowsMyGameList.Windows  5   	   -    'MyGameList.Windows.AddNewPlatformWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MyGameList.Windows     5   	     � Title$  
MyGameList��5   	   $	��450��6   $	��800��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   .��5	      � .+�5
   
   �� ���	#FF0FB200$
��Left=�6%   $��70��6@   ���	#FF0FB200$	��Top=�6_   $	��792��6w   �� 5   
   $
��Left=�6   $��
280,18,0,0q�6/   $
��Wrap=�6C   $��Adding New Platform��6W   $	��Top=�6r   $��24(�6�   $
��Bold"�6�   
�������6�   �� 5   
   $
��Left=�6   $��
346,85,0,0q�6/   $
��Wrap=�6C   $��	Platforms��6W   $	��Top=�6h   $
��Bold"�6�   $��24(�6�   �� 5   
   $
��Left=�6   $��207,135,0,0q�6/   $
��Wrap=�6D   $��	Platform*��6X   $	��Top=�6i   $��16(�6�   �� 5   
   -   5         ��Name$ PlatformTextBox��5      $
��Left=�6+   $��23��6F    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��287��6~   $��304,135,0,0q�6�   ���	#FF0FB2006�   �� 5   
   $
��Left=�6   $��191,190,0,0q�6/   $
��Wrap=�6D   $��Available Platforms��6X   $	��Top=�6s   $
��Bold"�6�   �� 5   
   ���	#FF0FB200$��1q�6)   $
��Left=�6=   $	��117��6X   $��118,211,0,0q�6e   $	��Top=�6z   $	��602��6�   ._�5      �� -   5         ��Name$! AvailablePlatfromsTextBlock��5      $
��Wrap=�6=   $�� ��6Q   {�.  6Y   5      �� 5   
   -   5        $��Confirm��5   /   $
��Left=�6A   $��236,344,0,0q�6\   $	��Top=�6q   $	��122��6�   $��50��6�   ���	#FF0FB200���	#FF0FB200
�������$��20(�6�   �� 5   
   -   5        $��Cancel��5   .   $
��Left=�6?   $��469,344,0,0q�6Z   $	��Top=�6o   $	��122��6�   $��50��6�   ���	#FF0FB200���	#FF0FB200
�������$��20(�6�   �� 5   
   -   5        $ PlatformErrorTextBlock��5      $y�Hidden=�64   
���  ��$
��Left=�6Y   $��596,139,0,0q�6t   $
��Wrap=�6�   $��This can't be empty !��6�   $	��Top=�6�   5      5      