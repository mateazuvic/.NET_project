   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.PropertiesWpfApp.Properties  5   	   clr-namespace:WpfAppWpfApp  5   	       WpfApp.ConfirmationBox   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0langclr-namespace:WpfApp.Properties     5   	   &localclr-namespace:WpfApp     5   	   -   5          ?Name$  exitBox??5   	    ? WindowStyle$
 None=?5	   	    ? AllowsTransparency . 
??????  ? Title$ ConfirmationBox??5   	   $	??200??6!   $	??400??6.   $??28(?6:    ? 
ResizeMode$ NoResize=?6H    ? WindowStartupLocation$ CenterScreen=?6^   .??5      ??  ?? CornerRadius$ 80??6   $??8q?6   
???????
???????._?5   
   ?  ? ColumnDefinitions 5      ?? 5      ?? 5       ? RowDefinitions 5      ?? 5      ?? 5      .+?5      ?? -   5        	 ??Name$	 lblQuestion??5      $??2??6)   !   WpfApp.Properties.Resources
   Pitanje#??Z
 6=   $	??200??6i   $??50??6u   6?   ?? 5      -   5         ??Name$ 
btnConfirm??5      	   Da#??Z 6*   $??0??6Q   $??1??6a   $	??100??6n   $??50??6z   
??? ? ?
???????6?   ?? 5      -   5        $ 	btnCancel??5      	   Ne#??Z 6(   $??1??6O   $??1??6_   $	??100??6l   $??50??6x   
???  ??
???????6?   5      5      5      