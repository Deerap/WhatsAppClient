   M S B A M L   `   `   `  ����X  TWhatsapp.Desktop.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Whatsapp.Desktop.Presentation.Converters(Whatsapp.Desktop.Presentation.Converters  5   	   _4clr-namespace:Whatsapp.Desktop.Presentation.Controls&Whatsapp.Desktop.Presentation.Controls  5   	   u?clr-namespace:Whatsapp.Desktop.Presentation.Controls.Extensions1Whatsapp.Desktop.Presentation.Controls.Extensions  5   	   s>clr-namespace:Whatsapp.Desktop.Presentation.Controls.Watermark0Whatsapp.Desktop.Presentation.Controls.Watermark  5   	   .    (Whatsapp.Desktop.Presentation.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Ced4http://schemas.microsoft.com/expression/2010/drawing     5   	   M
converters6clr-namespace:Whatsapp.Desktop.Presentation.Converters     5   	   Icontrols4clr-namespace:Whatsapp.Desktop.Presentation.Controls     5   	   V
extensions?clr-namespace:Whatsapp.Desktop.Presentation.Controls.Extensions     5   	   T	watermark>clr-namespace:Whatsapp.Desktop.Presentation.Controls.Watermark     5   	   -   5          � Title$  Whatsapp��5	   	   $	��550��6   $	��700��6'    � Icon$A ;/Whatsapp.Desktop.Presentation;component/Images/appicon.png��63   $��Segoe UI)�6v    � 	Resources 5         hideHeaderStyle �� 
TargetType �� Property �� Value  	highlight@   :Whatsapp.Desktop.Presentation.Controls.SearchableTextBlock �� 
TargetType ��NameD   >Whatsapp.Desktop.Presentation.Converters.DateToStringConverter  dateToStringConverterK   EWhatsapp.Desktop.Presentation.Converters.IntegerToVisibilityConverter   integerToVisibilityConverterK   EWhatsapp.Desktop.Presentation.Converters.IntegerToFontWeightConverter   integerToFontWeightConverterK   EWhatsapp.Desktop.Presentation.Converters.BooleanToVisibilityConverter   booleanToVisibilityConverterR   LWhatsapp.Desktop.Presentation.Converters.ReverseBooleanToVisibilityConverter ' #reverseBooleanToVisibilityConverterO   IWhatsapp.Desktop.Presentation.Converters.MessageTypeToColorBrushConverter $  messageTypeToColorBrushConverterQ   KWhatsapp.Desktop.Presentation.Converters.MessageTypeToCornerRadiusConverter & "messageTypeToCornerRadiusConverterT	   NWhatsapp.Desktop.Presentation.Converters.MessageTypeToMarginThicknessConverter )	 %messageTypeToMarginThicknessConverterT
   NWhatsapp.Desktop.Presentation.Converters.MessageTypeToBorderThicknessConverter )
 %messageTypeToBorderThicknessConverterO   IWhatsapp.Desktop.Presentation.Converters.MessageTypeToVisibilityConverter $  messageTypeToVisibilityConverterD   >Whatsapp.Desktop.Presentation.Converters.StringToXamlConverter  stringToXamlConverter��%�  &	        &	 O     '  �     &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &		     &	
 )    &	 <    &	 O    �� 5   
   " ��6(   .�5      ��  � y�$ 	Collapsed=�6+   5      �� 5   
   " ��6"   .�5      ��  � �� �	#FFfea6566+   5      �� 5   
   "  6   .�5      ��  � �� 5      �� 5      "  6&   .R�5      �� #��z��6!   #��z��5      #��z��5      ._�5      �� $ 	PART_TEXT��6<   $
��Wrap=�6(   6<   5      5      5      5        5"   
   6+     5#   
   62     5$   
   62     5%   
   62     5&   
   69     5'   
   66     5(   
   68   	  5)   
   6;   
  5*   
   6;     5+   
   66     5,   
   6+   5-      .��5.      � $��Stretch=�6   $��Stretch=�6'    � ColumnDefinitions 5/   
   �� 50      $��4* �6   �� 51      $
��Auto �6   �� 52      $��6* �6   .+�54   
   �� 	 �� ResizeDirection$	 Columns=�6   $��1��61   $��4��6A   $
��Auto��6K   $��Stretch=�6Y   $��Stretch=�6w   ���	#FF373e44
 J� Opacity$	
 0.3Q�6�   � 56   
   $��0��6    � RowDefinitions 57      �� 58      $��32 �6    6.   �� 59      6"   �� 5:      $��32 �6    6.   .+�5<      �� 
����� �$��1q�6,    �� CornerRadius$ 2��6@    �� Padding$ 0q�6Q   $��2,4,2,4q�6]   ._�5=      � $��Stretch=�6    5>      �� 5?      6-   �� 5@      $��24 �6+   68   .+�5B      �� -   5         ��Name$ 	txtSearch��5B      $��0q�61   $��2q�6E   $��Stretch=�6P   $��Stretch=�6n   ��6�   ��  �� Path$ 
SearchText� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ Explicit=�.��6�   G   AWhatsapp.Desktop.Presentation.Controls.Watermark.WatermarkService   	Watermark 5C      �� 5D      $��0q�6(    �� Padding$ 0q�63   $��Center=�6?   Search6b   .��5E   @   5F      �� 5G      -   5         ��Name$ cmdClear��5G      $��1��60   #��[" �6@   y�5H      �� $ InSearchMode� �� 	Converter# [ ��5I      �� 5J      $��2q�6$   $��16��6/   $��Images/delete.png��6:   5L      �� 5M      $��1��6   $��2q�6,   $��16��67   $��Images/search.png��6B   y�6]   �� $ InSearchMode�# [ 5O      5P      �� 5Q      -   5        $��	lvwRoster��5Q   %   $��1��6   ��. 
����� �$��0 1 0 1q�5S   v   ��5R      �� $ Items� �� SelectedItem 5S      �� $! RosterInstance.SelectedItem�$ TwoWay=���5T      �� 5U      " ��6   .�5V      ��  � ��$ Stretch=�6G   5W       �� View 5Y      �� 5Z      ! �� ColumnHeaderContainerStyle# [  6   .P�5[      ��  �� CellTemplate 5\      �� 5]   "   .R�5^   &   �� ���#61738B$��	0 0 0 0.1q�6C   $ 1q�6_   ._�5_   *   � $��Stretch=�6/   $��54��6M    5`   .   �� 5a   2   $��50 �6C   �� 5b   2   .+�5d   .   ��  �� RadiusX$ 20��68    �� RadiusY$ 20��6E   ��5e   2   �� 5f   6   rosterMainAvatar�� �� ImageSource 6[   �� $ AvatarPreviewURL�6�   5h   /   � 5i   .   $��1��63   $��2q�6C   $��Stretch=�6N    5j   2   �� 5k   6   $��20 �6D   6R   �� 5l   6   6F   .+�5n   2   � $��Stretch=�67    5o   6   �� 5p   :   �� 5q   :   $��50 �6K   .+�5s   6     $	��Top=�6p      Text 6S   �� $
 Name�   
SearchText 6�   ��  �� RelativeSource �� *FindAncestor+  �� AncestorType$  WindowL�$ DataContext.SearchText��� 5t   6   $��1��6@   ���	#FF0083c7$��10(�6�   ! �� TextAlignment$! Right=�6�   ��6P   �� $ Presence�6�   5u   3   � 5v   2   $��1��67   $��Stretch=�6D    5w   6   �� 5x   :   �� 5y   :   $��50 �6K   .+�5{   6   �� $	��Top=�6c   $��11(�6{   
�������$
��Wrap=�6�   $��CharacterEllipsis=�6�   ��6@   �� $ Message.Text�6�   5�   3   � 5�   2   $��1��67   $��1��6D   $��Stretch=�6T   y�6r   �� $ Message.MessageType�# [  5�   6   >   8Whatsapp.Desktop.Presentation.Converters.SwitchConverter  msgStatusIcon"   CasesB   <Whatsapp.Desktop.Presentation.Converters.SwitchConverterCase#   When$   Then��%  &	         5�   :   ." 5�   >     $
# Sent��6]   $$ Images/msg_unsent.png��6i     5�   >   $# DeliveredToServer��6]   $$$ Images/msg_deliveredserver.png��6v     5�   >   $# DeliveredToClient��6]   $$$ Images/msg_deliveredclient.png��6v   5�   ;   5�   7   .+�5�   6   �� $��Center=�6�   $��Right=�6�   $��15��6�   $��10��6�   $��Uniform=�6�   ��6<   �� *Message.MessageStatus+# [ 6�   5�   3   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      � 5�      $��2��6    5�      �� 5�      $��9* �6'   64   �� 5�      $��5 �6'   63   �� 5�      $��9* �6'   64   .+�5�      �� -   5        $��btnAddContact��5�      $
��Left=�6.   $��Stretch=�6P   $��Stretch=�6n   #��[" �6�   .��5�      � $
��Left=�6   $��Stretch=�66   .+�5�      �� $ ��Images/add_person_gray.png��6    $
��Left=�6D   $��30��6_   $��30��6j   $��8,0,0,0q�6v   6�   �� 5�      $	��Add��6$   $��50,0,6,0q�6/   $
��Left=�6A   $��Center=�6\   6y   5�      5�      �� 5�      $��1��6   #��["�6,   �� 5�      -   5        $��btnRemoveContact��5�      $
��Left=�61   $��Stretch=�6S   $��Stretch=�6q   #��[" �6�   $��2��6�   .��5�      � $
��Left=�6   $��Stretch=�66   .+�5�      �� $��Images/ic_menu_delete.png��6    $
��Left=�6C   $��30��6^   $��30��6i   $��8,0,0,0q�6u   6�   �� 5�      $��Remove��6$   $��50,0,6,0q�62   $
��Left=�6D   $��Center=�6_   6|   5�      5�      5�      5�      � 5�   
   $��2��6   $��Stretch=�6   $��Stretch=�6=    5�      �� 5�      $��60 �6    6.   �� 5�      6"   �� 5�      $
��Auto �6    60   .+�5�      �� ���	#FF0e4964$��0 0 0 1q�6-   ._�5�      � ���#075E55 5�      �� 5�      $��60 �6+   68   �� 5�      6-   .+�5�      �� $ 20��6    $ 20��6-   ��5�      �� 5�      -   5        chatMainAvatar�� 5�   )   �� $2 ,RosterInstance.SelectedItem.AvatarPreviewURL�$ TwoWay=�6�   5�      � 5�      $��1��6    5�      �� 5�      $
��Auto �6,   6<   �� 5�      6.   .+�5�      �� $��4q�6V   $��Stretch=�6a   $��Stretch=�6}   $��14(�6�   $��Medium"�6�   
���������6$   �� *" RosterInstance.SelectedItem.Name+5�      �� 5�      $��4,27,4,3q�6X   $��Stretch=�6j   $��Stretch=�6�   $��12(�6�   
�������$��2��6�   ��6$   �� *$"RosterInstance.SelectedItem.Status+6�   5�      5�      5�      �� 5�      -   5        $��lvwMessages��5�      $��0q�5�      $��1��6+   J   DWhatsapp.Desktop.Presentation.Controls.Extensions.ListViewExtensions%   AutoScrollToEnd% . 
���   �& �� IsTextSearchEnabled& .  ��5�   *   �� $ Messages���5�      �� 5�      $# Images/WhatsApp-Wallpaper.jpg��6!   ' j� Stretch$
' Fill=�6M   ( j� TileMode$
( Tile=�6\   6n   ) �� 
GroupStyle) 5�      (  "System.Windows.Controls.GroupStyle  5�      *   HeaderTemplate* 5�      �� 5�      .R�5�   "   �� $ 10,10,10,10��6)   
�������$��Center=�6]   $	��Top=�6z   $��0,5,0,0q�6�   ._�5�   &   �� $��10(�60   $��Center=�6~   
�������$��8q�6�   ��6>   �� $
 Name�+ �� StringFormat$+ dd MMM yyyy hh:mm tt��6�   5�   #   5�      5�      ��5�      �� 5�      " ��6   .�5�      ��  � ��$ Stretch=�6G   5�       5�      �� 5�      # [  6   .P�5�      ��  5�      �� 5�   "   .R�5�   &   � $��30��6+   $��0,4,0,4q�6:    5�   *   �� 5�   .   .+�5�   *   �  5�   .   ��%  &	         5   2   ." 5  6     $
# Sent��6U   $$ Images/msg_unsent.png��6a     5  6   $# DeliveredToServer��6U   $$$ Images/msg_deliveredserver.png��6n     5  6   $# DeliveredToClient��6U   $$$ Images/msg_deliveredclient.png��6n   5  3   5  /   .+�5  .   �� $ 8q�5	  5   
���������5  5   �� *MessageType+# [  5  5   �� *MessageType+# [ ��5
  5   �� *MessageType+# [	 ��5  5   �� *MessageType+# [
 ._�5  2   ]� .+�5  6   �� $	��Top=�6A   $��10(�6V   $	��Top=�6e   $ 0,0,0,1q�6}   
�������$��Stretch=�6�   ��6�   �� $ FromInfo�y�6�   �� $ GroupMessage�# [ 6B    5  6   $	��Top=�6�    6S   �� *Text+ 6i   ��  �� *FindAncestor+$  WindowL�$ DataContext.SearchText�6�   �� 5  6   $��Right=�6A   $��Bottom=�6]   , �� Orientation$, 
Horizontal=�6x   .+�5  :   �� $��Bottom=�6D   $��10(�6\   $��Bottom=�6k   $ 0,0,0,1q�6�   
�������$��Right=�6�   $
��Wrap=�6�   ��6�   �� *Time+$+ hh:mm��6  �� 5  :   $��Center=�6�   $��Right=�6�   $��14��6�   $��9��6�   $��Uniform=�6�   $��2,0,0,0q�6�   ��6@   �� *MessageStatus+# [ y�6�   �� *MessageType+# [ 5  7   5  3   5  /   5  +   5  '   5  #   5     5     5     � 5     $��2��6   $��Stretch=�6    $��Stretch=�6?   $��50��6_    5     �� 5      6)   �� 5!     $��50 �6'   64   .+�5#     �� -	   5        $��txtChatMessage��5#     $��0��60   $��Stretch=�6@   $��Stretch=�6`   $y�Visible=�6�   - �� TextWrapping$
- Wrap=�6�   . �� AcceptsReturn. . .��6�   5$     �� 5%     -
   5        $��btnSendChat��5%     $��1��6,   $��Stretch=�6W   $��Stretch=�6u   .��6�   Send6�   5&     5'     5)     5*     