   M S B A M L   `   `   `  ����N  JWpfXamlPopup, Version=1.0.4955.25985, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfXamlPopupWpfXamlPopup  5      #    WpfXamlPopup.MainNotifyWindow   5      R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      *localclr-namespace:WpfXamlPopup    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    6V   -   5          �Name$  uiMainNotifyWindow��5	   -    � Title$  ��5
      $	��350��6   $	��250��6    � ShowInTaskbar .   � WindowStyle$
 None=�5       � AllowsTransparency .  � 
ResizeMode$ NoResize=�5      
������ $y�Visible=�5       � Topmost . $��1q�5       � 	Resources 5         gridFadeInStoryBoard �� 
TargetName	 g� 	BeginTime
 �� TargetProperty W� From	 W� To g� AutoReverse g� Duration  gridFadeOutStoryBoard��%X  &	        &	 �     �� 5   
   .��5      W� $ 
uiGridMain��6   $	 0:0:0.1X�6A   $
 Opacity�5      $
 0.00X�65   $
 1.00X�6A    .  $ 0:0:0.3D�6_   5      �� 5   
   .��5      W� $ 
uiGridMain��6   $	 0:0:0.5X�6A   $
 Opacity�5      $
 1.00X�65   $
 0.00X�6A    .  $ 0:0:0.3D�6_   5      5      .��5      ��  �� CornerRadius$ 5��6   ._�5    
   � -   5         �Name$ 
uiGridMain��5       $��10q�6#   .+�5!      �� $
��Auto��6   $
��Auto��6"     MainGridBorder#��[ 60   5"      � 5#      $��5,0,12,0q�6    � RowDefinitions 5$      �� 5%      $��0 �6   �� 5&      $��18 �6    � ColumnDefinitions 5(      �� 5)      $��* �6!   �� 5*      $��36 �6!   �� 5+      $��42 �6'   .+�5-      $   WpfXamlPopup.SlickToggleButton  -   5          Name$ 	PinButton��5-   A   $   WpfXamlPopup.SlickToggleButton   Click$ PinButton_Click��6�      CornerRadius$ 0,0,0,4��6*     SlickButton#��[ 6T      HighlightBackground$ Orange��6y      PressedBackground$ 	OrangeRed��6�   $��1��6�   $��1��6�   $
��Bold"�6�   .��5.      �� -   5         ��Name$ PinImage��5.       $0��*pack://application:,,/Images/Un-Pinned.png��62   $
��None=�6f   5/        50      -   5        $ CloseButton��50   A   $ CloseButton_Click��6�   $ 0,0,4,0��6*   #��[ 6V   $ Orange��6{   $��X��6�   $��1��6�   $
��Bold"�6�   ���	#FFFFFFFF$��2��6�   51      � 52       53      �� 54      $��44 �6$   �� 55      $��* �6$   �� 56      $��44 �6$   .+�58      &    WpfXamlPopup.HorizontalSeparator  $��1��6Q     59      $��5��6T   �� 5:      -   5         ��Name$ 
TitleLabel��5:   /   $��5,3.395,79,15q�6   
������� J� Opacity$	 0.9Q�6V   $��My Popup Window��6d   �� 5;      $��1��6   $��10,10,10,10q�6*   .+�5<      �� $
��Bold"�6   .��6.   Set the icon colour to:6G   	� 5=      -   5        $��redRadioButton��5=   M   $��1��6"   $��10,0,0,0q�6/   $��16��6A    	� 	GroupName$ ColourGroup��6c   
 � Tag$	 Red��6�    d� 	IsChecked$
 TrueY�6�   $	��Top=�6�   .��6�   Red6�   	� 5>      -   5        $��amberRadioButton��5>   M   $��1��6"   $��10,0,0,0q�6/   $��16��6A   $ ColourGroup��6e   $ Amber��6�   $	��Top=�6�   .��6�   Amber6�   	� 5?      -	   5        $��greenRadioButton��5?   M   $��1��6"   $��10,0,0,0q�6/   $��16��6A   $ ColourGroup��6e   $ Green��6�   $	��Top=�6�   .��6�   Green6�   	� 5@      -
   5        $��blueRadioButton��5@   M   $��1��6"   $��10,0,0,0q�6/   $��16��6A   $ ColourGroup��6d   $
 Blue��6�   $	��Top=�6�   .��6�   Blue6�   5A      �� 5B      $��LeftToRight=�6    �� Orientation$ 
Horizontal=�69   $��5,5,5,5q�6R   $��2��6c   .+�5C      �� -   5         ��Name$ txtReply��5C      $	��179��60   $
��Left=�6>   �� 5D      -   5          ��Name$  btnReply��5D      $
��Send��6/   $��40��6>   5E      5F      5G      5H      5I      