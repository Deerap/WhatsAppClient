   M S B A M L   `   `   `  ���� W  SMiWavez.Desktop.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:MiWavez.Desktop.Presentation.Converters'MiWavez.Desktop.Presentation.Converters  ]3clr-namespace:MiWavez.Desktop.Presentation.Controls%MiWavez.Desktop.Presentation.Controls  q=clr-namespace:MiWavez.Desktop.Presentation.Controls.Watermark/MiWavez.Desktop.Presentation.Controls.Watermark  -    'MiWavez.Desktop.Presentation.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Ced4http://schemas.microsoft.com/expression/2010/drawing     L
converters5clr-namespace:MiWavez.Desktop.Presentation.Converters     Hcontrols3clr-namespace:MiWavez.Desktop.Presentation.Controls     S	watermark=clr-namespace:MiWavez.Desktop.Presentation.Controls.Watermark     -     � Title$  Ventura��$	��550��$	��700�� � Icon$H B/MiWavez.Desktop.Presentation;component/Images/profile/ventura.png��$��Segoe UI)� � 	Resources    hideHeaderStyle �� 
TargetType �� Property �� Value  	highlight?   9MiWavez.Desktop.Presentation.Controls.SearchableTextBlock �� 
TargetType ��NameC   =MiWavez.Desktop.Presentation.Converters.DateToStringConverter  dateToStringConverterJ   DMiWavez.Desktop.Presentation.Converters.IntegerToVisibilityConverter   integerToVisibilityConverterJ   DMiWavez.Desktop.Presentation.Converters.IntegerToFontWeightConverter   integerToFontWeightConverterJ   DMiWavez.Desktop.Presentation.Converters.BooleanToVisibilityConverter   booleanToVisibilityConverterQ   KMiWavez.Desktop.Presentation.Converters.ReverseBooleanToVisibilityConverter ' #reverseBooleanToVisibilityConverterC   =MiWavez.Desktop.Presentation.Converters.StringToXamlConverter  stringToXamlConverter��%5  &	        &	 *     '  U     &	 �     &	 �     &	 �     &	 �     &	 �     &	 �     �� " ��.���  � y�$ 	Collapsed=��� " ��.���  � �� �	#FFfea656�� "  .���  � �� �� "  .R��� #��z��#��z��#��z��._��� $ 	PART_TEXT��$
��Wrap=�            .��� $��Stretch=�$��Stretch=� � ColumnDefinitions �� $��4* ��� $
��Auto ��� $��6* �.+��� 	 �� ResizeDirection$	 Columns=�$��1��$��4��$
��Auto��$��Stretch=�$��Stretch=����	#FF373e44
 J� Opacity$	
 0.3Q�� $��0�� � RowDefinitions �� $��32 ��� �� $��32 �.+��� 
��� ���$��1q� �� CornerRadius$ 2�� �� Padding$ 0q�$��2,4,2,4q�._�� $��Stretch=� �� �� $��24 �.+��� -    ��Name$ 	txtSearch��$��0q�$��2q�$��Stretch=�$��Stretch=�����  �� Path$ 
SearchText� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ Explicit=�.��F   @MiWavez.Desktop.Presentation.Controls.Watermark.WatermarkService   	Watermark �� $��0q� �� Padding$ 0q�$��Center=�Search.���� -    ��Name$ cmdClear��$��1��#��[" �y��� $ InSearchMode� �� 	Converter# [ ���� $��2q�$��16��$��Images/delete.png���� $��1��$��2q�$��16��$��Images/search.png��y��� $ InSearchMode�# [ �� -   $��	lvwRoster��$��1��
��� E��$��0 1 0 1q����� $ Items� �� SelectedItem �� $! RosterInstance.SelectedItem�$ TwoWay=����� " ��.���  � ��$ Stretch=� �� View �� ! �� ColumnHeaderContainerStyle# [  .P���  �� CellTemplate �� .R��� ���#61738B$��	0 0 0 0.1q�$ 1q�._�� $��Stretch=�$��54�� �� $��50 ��� .+��� $��0��$��1q�$��48��$
��Fill=�$	��Top=����� *	AvatarUri+� $��1��$��2q�$��Stretch=� �� $��20 ��� .+�� $��Stretch=� �� �� $��50 �.+�  $	��Top=�   Text �� *Name+���� *UnreadCount+# [    
SearchText ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�$ DataContext.SearchText��� $��1�����	#FF0083c7$��10(� �� TextAlignment$ Right=����� *Time+# [ � $��1��$��Stretch=� �� �� $��50 �.+��� $	��Top=�$��11(�
�������$
��Wrap=�$��CharacterEllipsis=����� *	Message+�� $��1�����	#FFf1831f$��0q�$ 2�����	#FFf1831f$	��Top=�$��Right=�y��� *UnreadCount+# [ ._�� $	��Top=�.+��� $��10(�
�������$	��Top=�$ Center=�$ 2q�$��16������ *UnreadCount+� $��2��.+��� $��Stretch=�$
��Left=�$��Stretch=�#��[" �.��� $
��Left=�$��Stretch=�.+��� $��Images/add.png��$
��Left=�$��16��$��16��$��8,0,0,0q��� $��Subscribe to a Wave��$��30,0,6,0q�$
��Left=�� $��2��$��Stretch=�$��Stretch=� �� $��60 ��� �� $
��Auto �.+��� ���	#FF0e4964$��0 0 0 1q�._�� ����  �� EndPoint$ 	0.504,1.5&�  �� 
StartPoint$  
0.504,0.03&�.��� ! � Color$! #F76129��" � Offset$" 0Q�� $! #F76129��$	" 0.9Q� �� $��60 ��� .+��� ���	#FF1db0ed$��1q�$ 4��$ 0q�$��4q�
�������._��� $��Center=�$��Center=�$��48��$��48��$
��Fill=����� $+ %RosterInstance.SelectedItem.AvatarUri�� $��1�� �� $��30 ��� .+��� $��4q�$��Stretch=�$��Stretch=�$��14(�$��Medium"�
����������� *" RosterInstance.SelectedItem.Name+�� $
��50px��
�������$��Right=��� -   
�������.�	Log Out�� $��1��$��4,0,4,0q�$��Stretch=�$��Stretch=�$��12(�
����������� *)'RosterInstance.SelectedItem.Description+�� -   $��lvwMessages�����	#ffebeae5$��0q�$��1��
���   �# �� IsTextSearchEnabled# .  ���� $ Messages�$ �� 
GroupStyle$ (	  "System.Windows.Controls.GroupStyle	  % 	  HeaderTemplate% �� .R��� $��11(�$��Center=����	#FF999999$��8q����� $
 Name�& �� StringFormat$& dd MMM yyyy hh:mm tt������ " ��.���  � ��$ Stretch=� �� # [  .P���  �� .R�� $��30��$��0,4,0,4q� �� .+�� .+��� 
�������$ 4��$ 8q�$��8,0,0,0q�$��1q�
�������._�   �� *Text+ ��  �� *FindAncestor+$ WindowL�$ DataContext.SearchText�� $��2��$��Stretch=�$��Stretch=�$��50��y��� $ IsTwoWay� �� �� $��50 �.+��� -   $��txtChatMessage��$��0��$��Stretch=�$��Stretch=�.���� -   $��btnSendChat��$��1��$��Stretch=�$��Stretch=�.��Send