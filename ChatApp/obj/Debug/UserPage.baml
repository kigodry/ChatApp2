   M S B A M L   `   `   `  ����B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ChatAppChatApp  5   	       ChatApp.UserPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ChatApp     5   	     � Title$  UserPage��5   	   $	��450��6   $	��800��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   ���#007ACC$
��Auto=�69   .��5      �� .+�5      �� $(��"Пользователи чата:��6   
�������$��18(�6I   $��Center=�6W   �� 5      -   5         ��Name$ userList��5      $��10q�6,   
������ 
������ ��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value
 �����6;   �� 5       � ��$ 16(�69   �� 5       � ��$ 5q�67   5      5      5      5      �� 5!   
   -   5        $ messageListBox��5!      $��1��6   $��10q�67   
������ 
�������$��Center=�6p   �� 5$   
   $��2��6    �� Orientation$ 
Horizontal=�6"   ���#007ACC.+�5%      �� -   5         ��Name$ 
messageBox��5%      $��10q�6*   $��Center=�66   $��16(�6Q   $��40��6_   $	��400��6n   �� 5&      -   5         ��Name$ 
sendButton��5&      $��Отправить��6)   $��10q�6=   $
��10 5q�6I   $��16(�6X   $
��Bold"�6f   ���#4CAF50
�������6�   �� 5'      -   5        $ 
exitButton��5'      $��
Выход��6)   $��10q�69   $
��10 5q�6E   $��16(�6T   $
��Bold"�6b   ���#F44336
�������6�   5(      5)      5*      