   M S B A M L   `   `   `  ����G  CChatModelWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ChatModelWPFChatModelWPF  5   	       ChatModelWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ChatModelWPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	        ChatModelWPF.ViewModel  5
   
   6   .��5      �  � RowDefinitions 5   
   �� 5      $	��10* �6   6+   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��4* �6   6,   �� 5      6!   .+�5   
   �� $��0��6_   $��0��6l   ��6   �� *MessagesHistory+ �� UpdateSourceTrigger$ PropertyChanged=�6~   �� 5   
   $��0��6P   $��1��6`   ��6   �� *	Message+$ PropertyChanged=�6o   �� 5   
   $��1��6-   $��1��6=   ��6   �� *	SendBtn+.��6J   Send message6X   �� 5   
   $��1��6   ��6"   �� *
UserList+$ PropertyChanged=�5      5      