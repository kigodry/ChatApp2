   M S B A M L   `   `   `  ����B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ChatAppChatApp  5   	       ChatApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ChatApp     5   	     � Title$  
MainWindow��5   	   $	��240��6   $	��400��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Center=�6!   $��Center=�6>   $��24(�6Y   " Добро пожаловать!6z   �� 5   
   $��1��6   $��Center=�6"   $��Center=�6?   .+�5      �� $%��Введите ваше имя:��6   $��Center=�61   �� 5      -   5         ��Name$ Username��5      $	��200��6(   $	��0 5q�64   5      �� 5   
   $��2��6   $��Center=�6"   $��Center=�6?   .+�5      �� -   5         ��Name$ 
CreateChat��5      $��Создать чат��6)   $	��100��6?   $	��0 5q�6K   6X   �� 5      -   5        $ LogChat��5      $,��&Зайти в существующий��6&   $	��140��6E   $	��0 5q�6Q   6^   5      �� 5   
   $��3��6   $��Center=�6"   $��Center=�6?   .+�5      �� $#��Введите IP адрес:��6   $��Center=�61   �� 5      -   5        $ 	IPAddress��5      $	��200��6)   $	��0 5q�65   5       5!      5"      