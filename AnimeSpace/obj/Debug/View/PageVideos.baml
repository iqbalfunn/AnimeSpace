   M S B A M L   `   `   `  ����E  AAnimeSpace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AnimeSpace.ViewAnimeSpace.View  5           AnimeSpace.View.PageVideos   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:AnimeSpace.View     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  
PageVideos��5
         MaterialDesignPaper N� 
Background# �   5      .��5      � .+�5   
   �� -   5         ��Name$ BtnAddScannedFolder��5      $��90��6.   $��90��6:   $��1200,1,11,440q�6E    K� ZIndex$ 1��6\   ���	#FF1E1E1F���	#FF1E1E1F.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	FolderAdd=�6&   $��90��67   $��90��6C   $��Center=�6N   $��Center=�6i   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGFileCatalog��5      ���	#FF404142   HeadersVisibility$
 None=�5         AutoGenerateColumns .     SelectionMode$ Extended=�5      	   CanUserAddRows	 .  
   
IsReadOnly
 . $��20(�5      $	��934��5      $	��500��5       $��263,159,169,71q�5!      ��5      ��    Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *name+6L   5'      � 5)   
   ���	#FF1C1D1D$
��Left=�6&   $��60��6A   $��261,100,0,0q�6M   $	��Top=�6b   $	��936��6z   .+�5+      ]� ��. $
��auto��6-   $
��Left=�6:   .+�5,        -   5          Name$ Up_Dir��5,   *   $ FolderUpload=�6:   $��40��6N   $��40��6Z   $��Center=�6e   $��20,0,0,0q�6�   ���	#DDFFFFFF
������ 6�   �� 5-      -   5        $��textBlockParentFolder��5-      $
��Root��69   $��Center=�6E   $��
10,18,0,16q�6`   $��20(�6t   ���	#DDFFFFFF6�   5.      55      56      57      