   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MyGameList.WindowsMyGameList.Windows  5   	   3    -MyGameList.Windows.AddingGameToGamelistWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MyGameList.Windows     5   	   d `Syncfusion.SfHubTile.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfImageEditor.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf     5   	     � Title$  
MyGameList��5	   	   $	��600��6   $	��800��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   .��5
      � .+�5   
   �� ���	#FF0FB200$
��Left=�6%   $��70��6@   ���	#FF0FB200$	��Top=�6_   $	��792��6w   �� 5   
   $
��Left=�6   $��
297,21,0,0q�6/   $
��Wrap=�6C   $��Adding to GameList��6W   $	��Top=�6q   $
��Bold"�6�   $��20(�6�   
�������6�   �� 5   
   $
��Left=�6   $��
174,75,0,0q�6/   $
��Wrap=�6C   $��Information About Game��6W   $	��Top=�6u   $
��Bold"�6�   $��36(�6�   �� 5   
   $
��Left=�6   $��227,141,0,0q�6/   $
��Wrap=�6D   $��Status*��6X   $	��Top=�6g   $��16(�6   �� 5   
   -   5         ��Name$ StatusComboBox��5   1   $
��Left=�6I   $��320,140,0,0q�6d   $	��Top=�6y   $	��191��6�   $��22��6�   ���	#FF0FB200��5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      �  � Color$ 	#FFF0F0F0��6#    � Offset$ 0Q�65   � 5      $ White��6#   $ 1Q�61   5      .@�5      �� $��	COMPLETED��6   �� 5      $��CURRENTLY PLAYING��6   �� 5      $��PLAN TO PLAY��6   �� 5      $��DROPPED��6   �� 5      $��ON HOLD��6   5      �� 5   
   $
��Left=�6   $��227,183,0,0q�6/   $
��Wrap=�6D   $��Score��6X   $	��Top=�6e   $��16(�6}   �� 5   
   -   5        $ ScoreComboBox��5      $
��Left=�6*   $��320,183,0,0q�6E   $	��Top=�6Z   $	��191��6r   $��21��6~   {�.  .@�5      �� $��0��6   �� 5      $��1��6   �� 5       $��2��6   �� 5!      $��3��6   �� 5"      $��4��6   �� 5#      $��5��6   �� 5$      $��6��6   �� 5%      $��7��6   �� 5&      $��8��6   �� 5'      $��9��6   �� 5(      $��10��6   5)      �� 5*   
   $
��Left=�6   $��132,237,0,0q�6/   $
��Wrap=�6D   $��Review��6X   $	��Top=�6f   $
��Bold"�6~   $��16(�6�   �� 5+   
   -   5         ��Name$ ReviewTextBox��5+      $
��Left=�6)   $	��203��6D   $��
65,263,0,0q�6Q   	 �� TextWrapping$
	 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��682��6�   ���	#FF0FB200{�.  6�   �� 5,   
   -   5        $��Confirm��5,   /   $
��Left=�6A   $��196,488,0,0q�6\   $	��Top=�6q   $	��125��6�   $��55��6�   $��20(�6�   ���	#FF0FB200���	#FF0FB200
�������6�   �� 5-   
   -   5        $��Cancel��5-   .   $
��Left=�6?   $��497,488,0,0q�6Z   $	��Top=�6o   $	��125��6�   $��55��6�   $��20(�6�   ���	#FF0FB200���	#FF0FB200
�������6�   5.      5/      