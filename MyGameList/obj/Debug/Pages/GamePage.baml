   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyGameList.PagesMyGameList.Pages  5      5clr-namespace:MyGameList.ModelsMyGameList.Models  5   <       MyGameList.Pages.GamePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MyGameList.Pages     5      d `Syncfusion.SfHubTile.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfImageEditor.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf     5      2Modelsclr-namespace:MyGameList.Models     6<     N� Title$  GamePage��5
      .��5      � $��0q�6   .+�5   
   �� -   5         ��Name$ TitleTextBlock��5      $
��Left=�6,   $��10,5,0,0q�6G   $
��Wrap=�6Y   $��Placeholder Title��6m   $	��Top=�6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5         ��Name$ 
CoverImage��5      $
��Left=�6$   $	��260��6?   $��	54,38,0,0q�6L   $	��Top=�6_   $	��190��6w   $9��3/MyGameList;component/Resources/gamePlaceholder.jpg��6�   $
��Fill=�6�   �� 5   
   $��Information��6   $
��Left=�6&   $��
10,313,0,0q�6A   $	��Top=�6U   $
��Bold"�6m   �� 5   
   $
��Left=�6   $��10��6/   $��
10,339,0,0q�6;   $	��Top=�6O   $	��288��6g   �� 5   
   $
��Left=�6   $	��345��60   $��
22,354,0,0q�6=   $	��Top=�6Q   $	��262��6i   .+�5      ]� ��.  $��0,0,0,5q�6.   .+�5      �� $��18��6   $
��Wrap=�6(   $��Studio��6<   $	��Top=�6J   $��70��6b   $��0q�6m   �� 5      -   5        $ StudioTextBlock��5      $
��Wrap=�65   $��Studio Placeholder��6I   $	��Top=�6c   $	��185��6{   $��16��6�   $��0q�6�   5      ]� 5      ��.  $��0,0,0,5q�6.   .+�5      �� $��17��6   $
��Wrap=�6(   $��	Publisher��6<   $	��Top=�6M   $��70��6e   $��0q�6p   �� 5      -   5        $ PublisherTextBlock��5      $
��Wrap=�68   $��Publisher Placeholder��6L   $	��Top=�6i   $��17��6�   $	��190��6�   $��0q�6�   5      ]� 5      ��.  $��0,0,0,5q�6.   .+�5      �� $
��Wrap=�6   $��Premiere��60   $	��Top=�6@   $��70��6X   $��0q�6c   �� 5      -   5        $ PremiereTextBlock��5      $
��Wrap=�67   $��Placeholder date 00.00.00��6K   $	��Top=�6l   $	��186��6�   $��14��6�   $��0q�6�   5      ]� 5      ��.  $��0,0,0,5q�6.   .+�5      �� $
��Wrap=�6   $��	Platforms��60   $	��Top=�6A   $��70��6Y   $��0q�6d   �� 5       -   5        $ PlatformsTextBlock��5       $
��Wrap=�68   $9��3PC, PS4, PS3, PS2, PS1, SWITCH, 3DS, 2DS, DS, ATARI��6L   $	��Top=�6�   $	��180��6�   $��0q�6�   5!      ]� 5"      ��.  .+�5#      �� $
��Wrap=�6   $��Genres��60   $	��Top=�6>   $��70��6V   $��0q�6a   �� 5$      -   5        $ GenresTextBlock��5$      $
��Wrap=�65   $@��:Action, Adventure, Role-Playing-Game, Clicker, Point&Click��6I   $	��Top=�6�   $��31��6�   $	��177��6�   $��0q�6�   5%      5&      �� 5'   
   $
��Left=�6   $��1��6/   $��-31,375,0,0q�6:   $	��Top=�6O   $	��673��6g    J� RenderTransformOrigin$ 0.5,0.5&�6s   z�5(      V� 5)      .~�5*      ��  �� ScaleY$ -1Q�6%   �� 5+      �� 5,       �� Angle$	 -90Q�6&   T� 5-      5.      50      �� 51   
   ���	#FFF4F4F5$
��Left=�6%   $	��134��6@   $��
321,47,0,0q�6M   
�������$	��Top=�6s   $	��855��6�   0  *Syncfusion.Windows.Controls.Input.SfRating  52   
   -   5          Name$ Raiting��52         
ItemsCount$ 5��6/      	Precision$ Exact=�6>   	   
IsReadOnly	 . 
   Value$	
 2.5Q�6b   $
��Left=�6n   $��362,121,0,0q�6�   $	��Top=�6�   ��53      �� 54       �� 
TargetType4  .Syncfusion.Windows.Controls.Input.SfRatingItem"  6   .�55      ��  �� Property �@ 	RatedFill �� Value
 � ���62   �� 56       �@ PointerOverFill
 � ���68   57      59      �� 5:   
   ���	#FF0FB200$��1q�6)   $
��Left=�6=   $��
415,60,0,0q�6X   $	��Top=�6l   ._�5;      �� $��Score��6   5<      �� 5=   
   -	   5        $ ScoreTextBlock��5=      $
��Left=�6,   $��
412,94,0,0q�6G   $
��Wrap=�6[   $��99.99��6o   $	��Top=�6|   $��20(�6�   $��50��6�   ]� 5>   
   $
��Left=�6   ��.  $��409,156,0,0q�6E   $	��Top=�6Z   .+�5?      �� -
   5        $$ NumberOfUsersForScoreTextBlock��5?      $
��Wrap=�6@   $��123,123��6T   $	��Top=�6c   $��16��6{   �� 5@      $
��Wrap=�6   $�� users��6,   $	��Top=�6:   5A      �� 5B   
   $
��Left=�6   $��4��6/   $��473,112,0,0q�6:   $	��Top=�6O   $	��116��6g   $ 0.5,0.5&�6s   z�5C      V� 5D      .~�5E      �� �� 5F      �� 5G      $	 -90Q�6&   T� 5H      5I      5K      ]� 5L   
   $
��Left=�6   ��.  $��
588,99,0,0q�6E   $	��Top=�6Y   .+�5M      �� $
��Wrap=�6   $��Ranked��6,   $	��Top=�6:   $��20(�6R   $��0,0,15,0q�6`   �� 5N      $
��Wrap=�6   $��#��6,   $	��Top=�65   $��20(�6M   �� 5O      -   5        $ RankedTextBlock��5O      $
��Wrap=�61   $��12345��6E   $	��Top=�6R   $��20(�6j   �� 5P      $
��Wrap=�6   $��
Popularity��6,   $	��Top=�6>   $��20(�6V   $
��15,0q�6d   �� 5Q      $
��Wrap=�6   $��#��6,   $	��Top=�65   $��20(�6M   �� 5R      -   5        $ PopularityTextBlock��5R      $
��Wrap=�65   $��12345��6I   $	��Top=�6V   $��20(�6n   �� 5S      $
��Wrap=�6   $��Members��6,   $	��Top=�6;   $��20(�6S   $
��15,0q�6a   �� 5T      -   5        $ MembersTextBlock��5T      $
��Wrap=�62   $��12345��6F   $	��Top=�6S   $��20(�6k   5U      �� 5V   
   -   5         ��Name$ AddToGameListButton��5V   5   $��Add To GameList��6R   $
��Left=�6l   $��417,197,0,0q�6�   $	��Top=�6�   ���	#FF0FB200���	#FF0FB200
�������6�   �� 5W   
   -   5        $ AddToFollowButton��5W   3   $��Add To Follow��6N   $
��Left=�6f   $��542,197,0,0q�6�   $	��Top=�6�   
����������	#FF0FB200���	#FF0FB2006�   �� 5X   
   $��Description��6   $
��Left=�6&   $��321,236,0,0q�6A   $	��Top=�6V   $
��Bold"�6n   �� 5Y   
   $
��Left=�6   $��8��6/   $��321,267,0,0q�6:   $	��Top=�6O   $	��869��6g   �� 5Z   
   -   5        $ DescriptionTextBox��5Z      $
��Left=�60   $��330,280,0,0q�6K   $
��Wrap=�6`   $��Description Placeholder��6t   $	��Top=�6�   $	��163��6�   $	��846��6�   �� 5[   
   $��Review��6   $
��Left=�6!   $��321,463,0,0q�6<   $	��Top=�6Q   $
��Bold"�6i   �� 5\   
   $
��Left=�6   $��8��6/   $��321,489,0,0q�6:   $	��Top=�6O   $	��869��6g   ]� 5]   
   $
��Left=�6   ��.  $��417,502,0,0q�6E   $	��Top=�6Z   ]� 5^   
   $
��Left=�6   ��.  $��417,533,0,0q�6E   $	��Top=�6Z   �� 5_   
   -   5        $ EditGameButton��5_      $��	Edit Game��6H   $
��Left=�6\   $��1056,197,0,0q�6w   $	��Top=�6�   $	��114��6�   $��43��6�   
����������	#FF0FB2006�   �� 5`   
   -   5        $ EditGameListButton��5`      ���	#FF0FB200���	#FF0FB200
�������$��Edit GameList��6�   $
��Left=�6�   $��427,221,0,0q�6�   $	��Top=�6�   $y�Hidden=�6�   %   MyGameList.Models.ReviewElement  5b   
   -   5          Name$ ReviewThing��5b      $
��Left=�64   $��330,505,0,0q�6O   $	��Top=�6d   �� 5c   
   -   5        $
��Left=�5c      $��1127,468,0,0q�6/   $
��Wrap=�6E   $
��More��6Y   $	��Top=�6e   ���	#FF0FB200 � Cursor$
 Hand��6�   5e      5f      