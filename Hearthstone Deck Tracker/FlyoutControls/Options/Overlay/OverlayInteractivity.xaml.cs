﻿#region

using System.Windows;
using System.Windows.Controls;

#endregion

namespace Hearthstone_Deck_Tracker.FlyoutControls.Options.Overlay
{
	/// <summary>
	/// Interaction logic for OverlayInteractivity.xaml
	/// </summary>
	public partial class OverlayInteractivity : UserControl
	{
		private bool _initialized;

		public OverlayInteractivity()
		{
			InitializeComponent();
		}

		public void Load()
		{
			ToggleSwitchExtraFeatures.IsChecked = Config.Instance.ExtraFeatures;
			CheckBoxForceExtraFeatures.IsChecked = Config.Instance.ForceMouseHook;
			CheckBoxForceExtraFeatures.IsEnabled = Config.Instance.ExtraFeatures;
			_initialized = true;
		}

		private void ToggleSwitchExtraFeatures_Checked(object sender, RoutedEventArgs e)
		{
			if(!_initialized)
				return;
			Config.Instance.ExtraFeatures = true;
			CheckBoxForceExtraFeatures.IsEnabled = true;
			Config.Save();
		}

		private void ToggleSwitchExtraFeatures_Unchecked(object sender, RoutedEventArgs e)
		{
			if(!_initialized)
				return;
			Config.Instance.ExtraFeatures = false;
			CheckBoxForceExtraFeatures.IsEnabled = false;
			Config.Save();
		}

		private void CheckBoxForceExtraFeatures_OnChecked(object sender, RoutedEventArgs e)
		{
			if(!_initialized)
				return;
			Config.Instance.ForceMouseHook = true;
			Helper.MainWindow.Overlay.HookMouse();
			Config.Save();
		}

		private void CheckBoxForceExtraFeatures_OnUnchecked(object sender, RoutedEventArgs e)
		{
			if(!_initialized)
				return;
			Config.Instance.ForceMouseHook = false;
			Helper.MainWindow.Overlay.UnHookMouse();
			Config.Save();
		}
	}
}