   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyGameList.PagesMyGameList.Pages  5      #    MyGameList.Pages.GameListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MyGameList.Pages     5        N� Title$  GameListPage��5	       N� 
Background
 �����.��5      � .+�5   
   ]� $
��Left=�6   ��.  $��
167,10,0,0q�6E   $	��Top=�6Y   .+�5      �� -   5        $��	All Games��5   4   $	��Top=�6H   
����������	#FF0FB200$��0,0,15,0q�6�   $��20(�6�    � Cursor$
 Hand��6�   �� 5      -   5        $��Currently Playing��5   <   $	��Top=�6X   
����������	#FF0FB200$��0,0,15,0q�6�   $��20(�6�   $
 Hand��6�   �� 5      -   5        $��	Completed��5   5   $	��Top=�6I   ���	#FF0FB200
�������$��0,0,15,0q�6�   $��20(�6�   $
 Hand��6�   �� 5      -   5        $��On Hold��5   2   $	��Top=�6D   ���	#FF0FB200
�������$��0,0,15,0q�6�   $��20(�6�   $
 Hand��6�   �� 5      -   5        $��Dropped��5   3   $	��Top=�6E   ���	#FF0FB200
�������$��0,0,15,0q�6�   $��20(�6�   $
 Hand��6�   �� 5      -   5        $��Plan To Play��5   6   $	��Top=�6M   ���	#FF0FB200
�������$��20(�6�   $
 Hand��6�   5      ]� 5   
   $
��Left=�6   ��.  $��
868,17,0,0q�6E   $	��Top=�6Y   .+�5      �� $
��Wrap=�6   $��Viewing��6,   $	��Top=�6;   $��0,0,10,0q�6S   �� 5      -   5         ��Name$ NicknameTextBlock��5      $
��Wrap=�63   $��Placeholder��6G   $	��Top=�6Z   $
��Bold"�6r   $��14(�6�   �� 5      $
��Wrap=�6   $��'s GameList��6,   $	��Top=�6?   $
��Bold"�6W   $��14(�6i   5      �� 5   
   -   5        $ StatusTextBlock��5      $
��Left=�6-   $��	41,45,0,0q�6H   $
��Wrap=�6[   $��Choose��6o   $	��Top=�6}   $
��Bold"�6�   $��24(�6�   �� 5   
   $
��Left=�6   $��8��6/   $��	10,77,0,0q�6:   $	��Top=�6M   $
��1180��6e   �� 5   
   $
��Left=�6   $	��635��62   $��0,85,0,0q�6?   $	��Top=�6Q   $
��1200��6i   $
��Auto=�6v   .��5      � -	   5         �Name$ ImagesWrapPanel��5      $
��1200��61    � 
ItemHeight$	 260��6>    � 	ItemWidth$	 195��6O   5      5      5       5!      