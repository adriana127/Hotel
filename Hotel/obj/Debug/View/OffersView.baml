   M S B A M L   `   `   `  ����@  <Hotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Hotel.View
Hotel.View  5          Hotel.View.OffersView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Hotel.View     5      .��5	      � .+�5   
   �� $
��Left=�6   $	��450��6,   $	��Top=�69   $	��800��6Q   $��
0,0,0,-0.4q�6]   $��2��6q   .+�5      �� 
�������$��Bookings��6S   $	��135��6f   $��50��6r   ��6(   �� *ChangeScreenToBookings+6r   �� 5      
�������$��Rooms��6P   $	��135��6`   $��50��6l     �� Left$	  135��6x   ��6(   �� *ChangeScreenToRooms+6x   �� 5      
�������$��Offers��6p   $	��135��6�   $��50��6�   $	  270��6�   y�6(   �� *	IsAdmin+��6G   �� *ChangeScreenToOffers+6�   �� 5      
�������$��Services��6r   $	��130��6�   $��50��6�   $	  406��6�   y�6(   �� *	IsAdmin+��6G   �� *ChangeScreenToServices+6�   �� 5      
�������$��Features��6r   $	��135��6�   $��50��6�   $	  670��6�   y�6(   �� *	IsAdmin+��6G   �� *ChangeScreenToFeatures+6�   �� 5      
�������$��Account��6r   $	��135��6�   $��50��6�   $	  535��6�   y�6(   �� *	IsAdmin+��6G   �� *ChangeScreenToAccounts+6�   �� 5      $��	Add Offer��6   $	  670��6O   
 �� Top$	 390��6a   $	��130��6r   $��60��6~   ��6)   �� *NavigateOfferForm+6~   �� 5      $	��335��6   $  10��6m   $ 55��6~   $	��660��6�   ��6$   �� *	OfferList+ �� SelectedItem 6F   �� *SelectedOffer+ �� View 5      �� 5      .P�5      ��  �� Width$	 200��6)   $��
Offer Name��65    �� DisplayMemberBinding 6I   �� *	offerName+�� 5      $	 100��6)   $��Nights��65    6E   �� *nrBookedRooms+�� 5      $	 150��6)   $��
Start Date��65    6I   �� *	startDate+�� 5      $	 150��6)   $��Due Date��65    6G   �� *	dueDate+�� 5      $ 50��6)   $��Price��64    6C   �� *
newPrice+5      5!      5&      5(      5)      