   M S B A M L   `   `   `  ����    MiWavez.Desktop.Presentation(    "MiWavez.Desktop.Presentation.Login   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Sign In��$	��300��$	��650�� � 
ResizeMode$ NoResize=� � Icon$H B/MiWavez.Desktop.Presentation;component/Images/profile/ventura.png�� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $	��315 ��� $
��313* � � RowDefinitions �� $��23 ��� .+�o� -   $��mnuMain��$��23��$��2��$	��Top=� o� 
IsMainMenu . .@�m� $��_Ventura.Wavez��.@�m� $��_Close��m� $��_Tools��.@�m� $��_Connection��m� $��_Help��.@�m� $��_Guides and Support��m� $��_Check for Updates��m� $��_About mi.wavez���� -   $��imgLogo��$��1��$��0,0,0,0q�$
��None=�$L��F/MiWavez.Desktop.Presentation;component/Images/profile/Ventura_tag.JPG��� $��1��$��1������  �� EndPoint$ 	0.504,1.5&� �� 
StartPoint$ 
0.504,0.03&�.��� 	 � Color$	 #F76129��
 � Offset$
 0Q�� $	 #F76129��$	
 0.9Q� �� �� $��28 ��� $��16 ��� $��28 ��� $��16 ��� $��28 ��� $��60 ��� $��28 ��� $��16 � �� �� $	��300 ��� .+��� -   $��lblUsername��$��	Username:��$��1��$��1��$��28��$
��Left=�$	��Top=�
��������� -   $��lblPassword��$��	Password:��$��3��$��1��$��28��$
��Left=�$	��Top=�
��������� -   $��txtUsername��$��1��$��1��$��28��$
��Left=�$��80,0,0,0q�$	��Top=�$	��200��$��Center=�G� -   $��txtPassword��$��1��$��3��$��28��$
��Left=�$��80,0,0,0q�$	��Top=�$	��200��$��Center=��� -   $��	cmdSignIn��$��1��$��5��$��Sign In��$��28��$��60,0,0,0q�$	��200�� �� 	IsDefault . �� $��1��$��7��$��28��$��Stretch=�$	��Top=�
�����������  �� Path$ LoginStatus�