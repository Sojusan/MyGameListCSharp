   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MyGameList.WindowsMyGameList.Windows  5   	   6    0MyGameList.Windows.AdministrativePanelGameWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MyGameList.Windows     5   	   d `Syncfusion.SfHubTile.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfImageEditor.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf     5   	     � Title$  
MyGameList��5	   	   $	��750��6   $
��1000��6)    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L   .��5
      � .+�5   
   �� ���	#FF0FB200$
��Left=�6%   $��70��6@   ���	#FF0FB200$	��Top=�6_   $	��992��6w   �� 5   
   $
��Left=�6   $��
350,18,0,0q�6/   $
��Wrap=�6C   $��Information About Game��6W   $	��Top=�6u   $
��Bold"�6�   $��24(�6�   
�������6�   �� 5   
   $
��Left=�6   $��184,135,0,0q�6/   $
��Wrap=�6D   $��Title*��6X   $	��Top=�6f   $��16(�6~   �� 5   
   -   5         ��Name$ TitleTextBox��5      $
��Left=�6(   $��21��6C   $��239,138,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��229��6�   ���	#FF0FB2006�   �� 5   
   $
��Left=�6   $��169,172,0,0q�6/   $
��Wrap=�6D   $��Studio*��6X   $	��Top=�6g   $��16(�6   �� 5   
   -   5        $ StudioTextBox��5      $
��Left=�6)   $��21��6D   $��239,175,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��229��6�   ���	#FF0FB2006�   �� 5   
   $
��Left=�6   $��149,212,0,0q�6/   $
��Wrap=�6D   $��
Publisher*��6X   $	��Top=�6j   $��16(�6�   �� 5   
   -   5        $ PublisherTextBox��5      $
��Left=�6,   $��21��6G   $��239,215,0,0q�6S   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��229��6�   ���	#FF0FB2006�   �� 5   
   $
��Left=�6   $��151,252,0,0q�6/   $
��Wrap=�6D   $��	Premiere*��6X   $	��Top=�6i   $��16(�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ PremiereDatePicker��5      $
��Left=�61   $��239,252,0,0q�6L   $	��Top=�6a   $��21��6y   $	��229��6�   ��5      �� 5       �� EndPoint$ 0.5,0&�6&    �� 
StartPoint$ 0.5,1&�67   .��5      �  � Color$ 	#FFA3AEB9��6#   	 � Offset$	 0Q�65   � 5      $ 	#FF8399A9��6#   $	 0.375Q�65   � 5      $ 	#FF718597��6#   $	 0.375Q�65   � 5      $ 	#FF0FB200��6#   $	 1Q�65   5      5      �� 5   
   $
��Left=�6   $��147,298,0,0q�6/   $
��Wrap=�6D   $��
Platforms*��6X   $	��Top=�6j   $��16(�6�   3  -Syncfusion.Windows.Tools.Controls.ComboBoxAdv  5    
   -   5        
  Name$
 PlatformsComboBoxAdv��5    !      DefaultText$ Choose Platforms ...��6?   $
��Left=�6b   $��21��6}   $��239,298,0,0q�6�   $	��Top=�6�   $	��229��6�      AllowMultiSelect .    AllowSelectAll .    EnableOKCancel . 6�   �� 5!   
   $
��Left=�6   $��165,336,0,0q�6/   $
��Wrap=�6D   $��Genres*��6X   $	��Top=�6g   $��16(�6     5"   
   -   5        $
 GenresComboBoxAdv��5"   !   $ Choose Genres ...��6<   $
��Left=�6\   $��21��6w   $��239,336,0,0q�6�   $	��Top=�6�   $	��229��6�    .  .  . 6�   �� 5#   
   -   5        $��Delete��5#   .   $
��Left=�6?   $��
735,77,0,0q�6Z   $	��Top=�6n   $	��118��6�   $��46��6�   ���	#FF0FB200���	#FF0FB200
�������$��24(�6�   �� 5$   
   $
��Left=�6   $��597,153,0,0q�6/   $
��Wrap=�6D   $��	Preview *��6X   $	��Top=�6i   $��16(�6�   �� 5%   
   -   5         ��Name$ CoverImageBorder��5%      
���   �$��1q�6?   $
��Left=�6S   $	��250��6n   $��673,142,0,0q�6{   $	��Top=�6�   $	��180��6�   ._�5&      �� -	   5         ��Name$ 
CoverImage��5&      $
��Fill=�6(   5'      �� 5(   
   $
��Left=�6   $��665,408,0,0q�6/   $
��Wrap=�6D   $��Choose Cover��6X   $	��Top=�6l   �� 5)   
   -
   5        $��Select File��5)   2   $
��Left=�6H   $��768,402,0,0q�6c   $	��Top=�6x   $��85��6�   ���	#FF0FB200���	#FF0FB200
�������$��27��6�   �� 5*   
   -   5        $ DescriptionTextBox��5*      $
��Left=�6.   $	��137��6I   $��
92,471,0,0q�6V   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��851��6�   ���	#FF0FB2006�   �� 5+   
   $
��Left=�6   $��148,441,0,0q�6/   $
��Wrap=�6D   $��Description*��6X   $	��Top=�6l   $
��Bold"�6�   $��16(�6�   �� 5,   
   -   5        $��Confirm��5,   /   $
��Left=�6A   $��223,632,0,0q�6\   $	��Top=�6q   $	��130��6�   $��57��6�   ���	#FF0FB200���	#FF0FB200
�������$��20(�6�   �� 5-   
   -   5        $��Cancel��5-   .   $
��Left=�6?   $��665,632,0,0q�6Z   $	��Top=�6o   $	��130��6�   $��57��6�   ���	#FF0FB200���	#FF0FB200
�������$��20(�6�   �� 5.   
   -   5         ��Name$ TitleErrorTextBlock��5.      
���  ��$
��Left=�6B   $��473,140,0,0q�6]   $
��Wrap=�6r   $��This can't be empty !��6�   $	��Top=�6�   $y�Hidden=�6�   �� 5/   
   -   5        $ StudioErrorTextBlock��5/      
���  ��$
��Left=�6C   $��473,177,0,0q�6^   $
��Wrap=�6s   $��This can't be empty !��6�   $	��Top=�6�   $y�Hidden=�6�   �� 50   
   -   5        $ PublisherErrorTextBlock��50      
���  ��$
��Left=�6F   $��473,217,0,0q�6a   $
��Wrap=�6v   $��This can't be empty !��6�   $	��Top=�6�   $y�Hidden=�6�   �� 51   
   -   5        $ PremiereErrorTextBlock��51      
���  ��$
��Left=�6E   $��473,256,0,0q�6`   $
��Wrap=�6u   $��This can't be empty !��6�   $	��Top=�6�   $y�Hidden=�6�   �� 52   
   -   5        $ PlatformsErrorTextBlock��52      
���  ��$
��Left=�6F   $��473,300,0,0q�6a   $
��Wrap=�6v   $��This can't be empty !��6�   $	��Top=�6�   $y�Hidden=�6�   �� 53   
   -   5        $ GenresErrorTextBlock��53      
���  ��$
��Left=�6C   $��473,338,0,0q�6^   $
��Wrap=�6s   $��This can't be empty !��6�   $	��Top=�6�   $y�Hidden=�6�   �� 54   
   -   5        $ CoverErrorTextBlock��54      
���  ��$
��Left=�6B   $��858,256,0,0q�6]   $
��Wrap=�6r   $��This can't be empty !��6�   $	��Top=�6�   $y�Hidden=�6�   �� 55   
   -   5        $ DescriptionErrorTextBlock��55      
���  ��$
��Left=�6H   $��247,445,0,0q�6c   $
��Wrap=�6x   $��This can't be empty !��6�   $	��Top=�6�   $y�Hidden=�6�   57      58      