   M S B A M L   `   `   `  ����E  AMyGameList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyGameList.PagesMyGameList.Pages  5      5clr-namespace:MyGameList.ModelsMyGameList.Models  5   <   !    MyGameList.Pages.ReviewPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MyGameList.Pages     5      d `Syncfusion.SfHubTile.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b ^Syncfusion.SfInput.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89a ]Syncfusion.Shared.Wpf, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89h dSyncfusion.SfImageEditor.WPF, Version=17.4460.0.39, Culture=neutral, PublicKeyToken=3d67ed1f87d44c898
syncfusion!http://schemas.syncfusion.com/wpf     5      2Modelsclr-namespace:MyGameList.Models     6<     N� Title$  
ReviewPage��5
       N� 
Background
 �����.��5      � .+�5   
   �� -   5         ��Name$ TitleTextBlock��5      $
��Left=�6,   $��10,5,0,0q�6G   $
��Wrap=�6Y   $��Placeholder Title��6m   $	��Top=�6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5         ��Name$ 
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
��Wrap=�6(   $��Studio��6<   $	��Top=�6J   $��70��6b   $��0q�6m   �� 5      -   5        $ StudioTextBlock��5      $
��Wrap=�65   $��Studio Placeholder��6I   $	��Top=�6c   $	��185��6{   $��16��6�   $��0q�6�   5      ]� 5      ��.  $��0,0,0,5q�6.   .+�5      �� $��17��6   $
��Wrap=�6(   $��	Publisher��6<   $	��Top=�6M   $��70��6e   $��0q�6p   �� 5      -   5        $ PublisherTextBlock��5      $
��Wrap=�68   $��Publisher Placeholder��6L   $	��Top=�6i   $��17��6�   $	��190��6�   $��0q�6�   5      ]� 5      ��.  $��0,0,0,5q�6.   .+�5      �� $
��Wrap=�6   $��Premiere��60   $	��Top=�6@   $��70��6X   $��0q�6c   �� 5      -   5        $ PremiereTextBlock��5      $
��Wrap=�67   $��Placeholder date 00.00.00��6K   $	��Top=�6l   $	��186��6�   $��14��6�   $��0q�6�   5      ]� 5      ��.  $��0,0,0,5q�6.   .+�5      �� $
��Wrap=�6   $��	Platforms��60   $	��Top=�6A   $��70��6Y   $��0q�6d   �� 5       -   5        $ PlatformsTextBlock��5       $
��Wrap=�68   $9��3PC, PS4, PS3, PS2, PS1, SWITCH, 3DS, 2DS, DS, ATARI��6L   $	��Top=�6�   $	��180��6�   $��0q�6�   5!      ]� 5"      ��.  .+�5#      �� $
��Wrap=�6   $��Genres��60   $	��Top=�6>   $��70��6V   $��0q�6a   �� 5$      -   5        $ GenresTextBlock��5$      $
��Wrap=�65   $@��:Action, Adventure, Role-Playing-Game, Clicker, Point&Click��6I   $	��Top=�6�   $��31��6�   $	��177��6�   $��0q�6�   5%      5&      �� 5'   
   $
��Left=�6   $��1��6/   $��-31,375,0,0q�6:   $	��Top=�6O   $	��673��6g    J� RenderTransformOrigin$ 0.5,0.5&�6s   z�5(      V� 5)      .~�5*      ��  �� ScaleY$ -1Q�6%   �� 5+      �� 5,       �� Angle$	 -90Q�6&   T� 5-      5.      50      �� 51   
   $��Review��6   $
��Left=�6!   $��
321,33,0,0q�6<   $	��Top=�6P   $
��Bold"�6h   �� 52   
   $
��Left=�6   $��8��6/   $��
321,59,0,0q�6:   $	��Top=�6N   $	��869��6f   �� 53   
   $
��Left=�6   $	��648��62   $��
321,72,0,0q�6?   $	��Top=�6S   $	��879��6k   $
��Auto=�6w   .��54      � -   5         �Name$ ReviewsWrapPanel��54      $	��860��62   .+�56      %   MyGameList.Models.ReviewElement    57        58        59      5;      5<      5>      5?      