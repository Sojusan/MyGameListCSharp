   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyGameList.PagesMyGameList.Pages  5           MyGameList.Pages.LoginPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MyGameList.Pages     5        N� Title$  	LoginPage��5	      $	��676��6   $	��422��6%   .��5      �  � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $
��163* �6   �� 5      $	��18* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   � $
��Left=�6   $	��326��6/   $��1��6<   $	��Top=�6I   $	��225��6a    � 
ItemHeight$ 52��6m    � 	ItemWidth$	 100��6}    � Orientation$ Vertical=�6�   $��1��6�   $��1,0,0,0q�6�   .+�5      �� $��Login��6   $��18(�6$   $
��Bold"�62   $��0,0,-126,18q�6D   �� 5      -   5         ��Name$ LoginTextBox��5       �� TextWrapping$
 Wrap=�6,   ���	#FF0FB200$��14(�6r   $��0,0,-125,27q�6�    �� SelectionBrush 6X   Z� 6�   �� 5      $��Password��6   $��18(�6'   $
��Bold"�65   $��0,0,-126,18q�6G   G� 5      -   5        	 G�Name$	 PasswordTextBox��5      $
��Left=�63   $��25��6N   $	��Top=�6Z   $	��225��6r   $��
0,0,-125,0q�6~   ���	#FF0FB200$��14(�6�   
 G� SelectionBrush
 6�   Z� 6�   �� 5      -   5        $��Forgot password ?��5      $
��Bold"�60   $��
0,0,-22,27q�6B   $��Arial)�6V   ���	#FF0FB200 � Cursor$
 Hand��6�   6�   � 5      $
��Left=�6   $��41��6.   $	��Top=�6:   $	��225��6R   $��
0,0,-125,0q�6^   .+�5      �� -   5        $��Log in��5      $
��Left=�6*   $	��Top=�6E   $��71��6]   $��25,0,0,0q�6h   $��36��6z   ���	#FF0FB200
�������$
 Hand��6�   �� 5      -   5        $��Register��5      $
��Left=�6,   $��	125,0,0,0q�6G   $	��Top=�6Z   $��71��6r   $��36��6}   
����������	#FF0FB200$
 Hand��6�   5      5       �� 5!   
   -   5         ��Name$ LoginErrorTextBlock��5!      $��2��61   $
��Left=�6A   $��	10,56,0,0q�6\   $��1��6o   $
��Wrap=�6|   $��	TextBlock��6�   $	��Top=�6�   
���  ��$y�Hidden=�6�   �� 5"   
   -   5        $ PasswordErrorTextBlock��5"      $��2��64   $
��Left=�6D   $��
10,159,0,0q�6_   $��1��6s   $
��Wrap=�6�   $��	TextBlock��6�   $	��Top=�6�   
���  ��$y�Hidden=�6�   5#      5$      