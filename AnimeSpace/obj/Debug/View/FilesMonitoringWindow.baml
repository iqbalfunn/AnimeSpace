   M S B A M L   `   `   `  ����E  AAnimeSpace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AnimeSpace.ViewAnimeSpace.View  5   	   +    %AnimeSpace.View.FilesMonitoringWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AnimeSpace.View     5   	      MaterialDesignPaper#���   5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Title$ Scan Folder��5   	   $	��500��6   $	��600��6*    � 	Resources 5       �� 
TargetType �� BasedOn��%�   '��       '�� &     '�� L     �� 5   
   " ��6    6/   Z� �� 5   
   " ��6    6;   Z� �� 5   
   " ��6    63   Z� 5      .��5      � .+�5   
   � $��358,0,0,115q�6   $	��320��6$   $��Bottom=�61   .+�5      �� -   5         ��Name$ BtnAddFolder��5      $��24,1,22,287q�6+   .��5      �� Add6!   5      �� 5      -   5        $ BtnDeleteSelected��5      $��24,56,22,232q�60   .��5      �� Delete Selected6-   5      5      � 5    
   $��Bottom=�6   ���	#FF1D1D1D.+�5!      �� -   5        $ 	BtnUpdate��5!   &    K� ZIndex$ 2��6   $��160,23,244,24q�69   $	��188��6P   .��5"      �� Update6$   5#      �� 5%      -   5        $ BtnClose��5%   &   $ 2��6   $��382,23,22,24q�68   $	��188��6N   .��5&      �� Close6#   5'      5(      � 5+   
   $��10,21,234,98q�6   .+�5,      �� -   5         ��Name$ 	LvScanDir��5-      
�������$��19,10q�50   %   ��6   �� 	 �� View	 52      �� 53      .P�54      �� 
 �� Width$	
 300��6)   $��Folder��65    �� DisplayMemberBinding 55      �� *
pathFolder+56      58      5:      5<      5=      