   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyGameList.PagesMyGameList.Pages  5      5clr-namespace:MyGameList.ModelsMyGameList.Models  5   <       MyGameList.Pages.MenuPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      J FWpfAnimatedGif, Version=1.4.18.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5      *localclr-namespace:MyGameList.Pages  5      d `Syncfusion.SfHubTile.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h	 dSyncfusion.SfImageEditor.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf    	 5      2Modelsclr-namespace:MyGameList.Models    	 6<     N� Title$  MenuPage��5       N� 
Background
 �����.��5      � .+�5   
   � $
��Left=�6   $	��720��6*   $	��Top=�67   $
��1203��6O   .+�5      �� $
��Left=�6   $��9��63   $��562,354,-46,0q�6>   $	��Top=�6U   $	��684��6m    J� RenderTransformOrigin$ 0.5,0.5&�6y   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$	 -90Q�6*   T� 5      5      5      �� 5      $��Newest Entries��6   $
��Left=�6-   $	��Top=�6H   $��	10,40,0,0q�6`   �� 5      $
��Left=�6   $��16��63   $��	10,66,0,0q�6?   $	��Top=�6R   $	��885��6j   �� 5      
���   �$��1q�6)   $
��Left=�6=   $��	38,87,0,0q�6X   $	��Top=�6k   ._�5      #   MyGameList.Models.InfoOverlay  -   5          Name$ FirstNewestEntryOverlay��5   %   5      �� 5      
���   �$��1q�6)   $
��Left=�6=   $��
256,87,0,0q�6X   $	��Top=�6l   ._�5        -   5        $ SecondNewestEntryOverlay��5   %   5       �� 5!      
���   �$��1q�6)   $
��Left=�6=   $��
475,87,0,0q�6X   $	��Top=�6l   ._�5"        -   5        $ ThirdNewestEntryOverlay��5"   %   5#      �� 5$      
���   �$��1q�6)   $
��Left=�6=   $��
695,87,0,0q�6X   $	��Top=�6l   ._�5%        -   5        $ FourthNewestEntryOverlay��5%   %   5&      �� 5'      $��	Top Games��6   $
��Left=�6(   $	��Top=�6C   $��
10,395,0,0q�6[   �� 5(      $
��Left=�6   $��16��63   $��
10,421,0,0q�6?   $	��Top=�6S   $	��885��6k   �� 5)      
���   �$��1q�6)   $
��Left=�6=   $��
38,442,0,0q�6X   $	��Top=�6l   ._�5*        -   5        $ FirstTopGameOverlay��5*   %   5+      �� 5,      
���   �$��1q�6)   $
��Left=�6=   $��256,442,0,0q�6X   $	��Top=�6m   ._�5-        -   5        $ SecondTopGamesOverlay��5-   %   5.      �� 5/      
���   �$��1q�6)   $
��Left=�6=   $��475,442,0,0q�6X   $	��Top=�6m   ._�50        -   5        $ ThirdTopGamesOverlay��50   %   51      �� 52      
���   �$��1q�6)   $
��Left=�6=   $��695,442,0,0q�6X   $	��Top=�6m   ._�53        -   5        $ FourthTopGamesOverlay��53   %   54      �� 55      $��Recent Friends Updates��6   $
��Left=�65   $��
915,69,0,0q�6P   $	��Top=�6d   �� 56      $
��Left=�6   $��18��63   $��
915,95,0,0q�6?   $	��Top=�6S   $	��275��6k   �� 57      -	   5         ��Name$$ FirstNewestEntryCoverRectangle��57      ���	#FFF4F4F5$
��Left=�6Q   $	��252��6l   $��	38,87,0,0q�6y   
���   �$	��Top=�6�   $	��182��6�   �� 58      -
   5         ��Name$  FirstNewestEntryCoverImage��58      "  WpfAnimatedGif.ImageBehavior   AnimatedSource$1 +/MyGameList;component/Resources/loading.gif��68   $
��Left=�6�   $	��252��6�   $��	38,87,0,0q�6�   $	��Top=�6�   $	��182��6�   $
��Fill=�6�   �� 59      -   5        $% SecondNewestEntryCoverRectangle��59      ���	#FFF4F4F5$
��Left=�6R   $	��252��6m   $��
256,87,0,0q�6z   
���   �$	��Top=�6�   $	��182��6�   �� 5:      -   5        $! SecondNewestEntryCoverImage��5:      $1 +/MyGameList;component/Resources/loading.gif��69   $
��Left=�6�   $	��252��6�   $��
256,87,0,0q�6�   $	��Top=�6�   $	��182��6�   $
��Fill=�6�   �� 5;      -   5        $$ ThirdNewestEntryCoverRectangle��5;      ���	#FFF4F4F5$
��Left=�6Q   $	��252��6l   $��
475,87,0,0q�6y   
���   �$	��Top=�6�   $	��182��6�   �� 5<      -   5        $  ThirdNewestEntryCoverImage��5<      $1 +/MyGameList;component/Resources/loading.gif��68   $
��Left=�6�   $	��252��6�   $��
475,87,0,0q�6�   $	��Top=�6�   $	��182��6�   $
��Fill=�6�   �� 5=      -   5        $% FourthNewestEntryCoverRectangle��5=      ���	#FFF4F4F5$
��Left=�6R   $	��252��6m   $��
695,87,0,0q�6z   
���   �$	��Top=�6�   $	��182��6�   �� 5>      -   5        $! FourthNewestEntryCoverImage��5>      $1 +/MyGameList;component/Resources/loading.gif��69   $
��Left=�6�   $	��252��6�   $��
695,87,0,0q�6�   $	��Top=�6�   $	��182��6�   $
��Fill=�6�   �� 5?      -   5        $! FirstTopGamesCoverRectangle��5?      ���	#FFF4F4F5$
��Left=�6N   $	��252��6i   $��
38,442,0,0q�6v   
���   �$	��Top=�6�   $	��182��6�   �� 5@      -   5        $ FirstTopGamesCoverImage��5@      $1 +/MyGameList;component/Resources/loading.gif��65   $
��Left=�6�   $	��252��6�   $��
38,442,0,0q�6�   $	��Top=�6�   $	��182��6�   $
��Fill=�6�   �� 5A      -   5        $" SecondTopGamesCoverRectangle��5A      ���	#FFF4F4F5$
��Left=�6O   $	��252��6j   $��256,442,0,0q�6w   
���   �$	��Top=�6�   $	��182��6�   �� 5B      -   5        $ SecondTopGamesCoverImage��5B      $1 +/MyGameList;component/Resources/loading.gif��66   $
��Left=�6�   $	��252��6�   $��256,442,0,0q�6�   $	��Top=�6�   $	��182��6�   $
��Fill=�6�   �� 5C      -   5        $! ThirdTopGamesCoverRectangle��5C      ���	#FFF4F4F5$
��Left=�6N   $	��252��6i   $��475,442,0,0q�6v   
���   �$	��Top=�6�   $	��182��6�   �� 5D      -   5        $ ThirdTopGamesCoverImage��5D      $1 +/MyGameList;component/Resources/loading.gif��65   $
��Left=�6�   $	��252��6�   $��475,442,0,0q�6�   $	��Top=�6�   $	��182��6�   $
��Fill=�6�   �� 5E      -   5        $" FourthTopGamesCoverRectangle��5E      ���	#FFF4F4F5$
��Left=�6O   $	��252��6j   $��695,442,0,0q�6w   
���   �$	��Top=�6�   $	��182��6�   �� 5F      -   5        $ FourthTopGamesCoverImage��5F      $1 +/MyGameList;component/Resources/loading.gif��66   $
��Left=�6�   $	��252��6�   $��695,442,0,0q�6�   $	��Top=�6�   $	��182��6�   $
��Fill=�6�   � 5G      -   5         �Name$# RecentFriendsUpdatesWrapPanel��5G      	 � 
ItemHeight$		 110��6?   
 � 	ItemWidth$	
 270��6P   $
��Left=�6`   $	��571��6{   $��915,113,0,0q�6�   $	��Top=�6�   $	��275��6�    � Orientation$ Vertical=�6�   .+�5H      *   $MyGameList.Models.RecentFriendUpdate    5I        5J        5K        5L      5M      5N      5O      5P      