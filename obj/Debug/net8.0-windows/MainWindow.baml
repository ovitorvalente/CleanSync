   M S B A M L   `   `   `  ����D  @CleanSync, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CleanSync	CleanSync  5   	       CleanSync.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CleanSync     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ 	CleanSync��5   	   $	��540��5   	   $	��640��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��170 �6#   �� 5      $��* �6#   �� 5      $��60 �6#   .+�5      �� -   5        ���#1976D2$��0��5      $
��Left=�5      $��Center=�5      $��
8, 0, 0, 0q�5        �� Padding$ 8q�5!      $��40��5"       � Cursor$
 Hand��5#       � ToolTip$ Clique para iniciar...��5$      $
|�True��5%       �� CornerRadius$ 7��5'      ._�5(      �� $��▶ Iniciar Processo [F2]��6   
�������$��SemiBold"�5*      $��Center=�5+      $��Center=�5,      5-      �� 5/      $��1��6   $��Center=�50      $
��Left=�51      ���#f1f1f1$	��200��53      $��40��54      $ 7��55      ._�56      �� -   5        	 ��Name$	 ConnectionStatus��56      $��🔴 Banco: desconectado��57      $��14(�58      $��12, 0, 0, 0q�59      $
��Bold"�5:      $
��Left=�5;      $��Center=�5<      
���  ��5=      5>      �� 5A      $
 Help��6   $��2��5B      $
|�True��5C      $ Precisa de ajuda?��5D      $��Center=�5E      $��Center=�5F      $��30(�5G      �� 5H      -   5        
 �� TextDecorations$

 None{�5H      
���  ��$,��&mailto:vitorvalente.vrsystem@gmail.com?�5J      .�5K   H   🆘5M      5N      5O      � 5Q   
   $��1��6   .+�5R      �� -   5         ��Name$ TerminalOutput��5R      $��1��5S      $��8q�5T      $��8q�5U      $��Consolas)�5V      $��12(�5W       �� 
IsReadOnly$
 True��5X      
���   ����#f1f1f1 �� TextWrapping$
 Wrap=�5[      " �� VerticalScrollBarVisibility$
 Auto=�5\      $ �� HorizontalScrollBarVisibility$
 Auto=�5]      $ Console��5^      5`      �� 5b   
   $��2��6   .@�5c      �� $ Clique para saber mais...��6   $��
6, 0, 0, 0q�5d      $��12(�5e      $��SemiBold"�5f      $��Center=�5g      $��Center=�5h      �� 5i      -   5        $

 None{�5i      ���#1976D2$&�� https://github.com/ovitorvalente?�5k      .�5l   H   53© 2025 Vitor Valente. Todos os direitos reservados5n      5o      5p      5q      5r      