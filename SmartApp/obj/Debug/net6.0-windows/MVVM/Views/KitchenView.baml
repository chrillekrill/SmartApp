   M S B A M L   `   `   `  ????C  ?SmartApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SmartApp.MVVM.ViewsSmartApp.MVVM.Views  5      9!clr-namespace:SmartApp.ComponentsSmartApp.Components  6>   %    SmartApp.MVVM.Views.KitchenView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:SmartApp.MVVM.Views     5      8
components!clr-namespace:SmartApp.Components     6>   .??5	      ??   ?? CornerRadius$  12??6   ??5
   
   ?? 5       ?? ImageSource$  /Assets/Images/Kitchen.jpg??6   ._?5   
   ? $??30q?6    ? RowDefinitions 5      ?? 5      $
??auto ?6    ?? 5      $??* ?6    .+?5      ? $??0??6   $??0 0 0 50q?6     ? ColumnDefinitions 5      ?? 5      $??1* ?6'   ?? 5      $??2* ?6'   ?? 5      $??1* ?6'   .+?5      ?? $??0??6    ?? Orientation$ Vertical=?6-   $
??Left=?6D   $	??Top=?6_   .+?5      ?? $??64(?6    
???   ?$
??Left=?6A   $??Center=?6\   ?? 5      ?6   ?? *Title+5      ?? 5      $??22(?6    
???   ?$
??Left=?6A   $??Center=?6\   ?? 5       $??32(?6;   ?6   ?? *Temperature+6;    ?? 5!      $	?°C??6   5"      5#      ?? 5%      $??1??6   $??Center=?6-   $	??Top=?6J   $??	0 -15 0 0q?6b   .+?5&      ?? $??52(?6=   
???   ?$??Center=?6^   $	??Top=?6{   ??6    ?? *CurrentTime+6{   ?? 5'      $??20(?6=   
???   ?$??Center=?6^   ??6    ?? *CurrentDate+6^   5(      ?? 5*      $??2??6   $	????6)   $??Segoe MDL2 Assets)?6<   $??32(?6\   
?????? 
???   ?$??0q?6?   $??Right=?6?   $	??Top=?6?   5,      ?? 5.      -   5         ??Name$ deviceTileListView??5.   (   $??1??6   ??6D   ?? *DeviceItems+??50      ?? 51      .R?52      '   !SmartApp.Components.TileComponent     	IsChecked 53      ?? *DeviceState+   
DeviceName 54      ?? *
DeviceName+   
DeviceType 55      ?? *
DeviceType+	   
IconActive	 56      ?? *
IconActive+
   IconInActive
 57      ?? *IconInActive+59      ??5<      ?? 5=      .R?5>      ? 5?      5B      5C      5E      5F      