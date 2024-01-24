using System;
using colol2.Models;
using ReactiveUI;

namespace colol2.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
#pragma warning disable CA1822 // Mark members as static

		public static LoginUser login = new();

		private string? loginuse = null;
		private string? password = null;


		public string EnterLogin
		{
			get => loginuse;
			set => this.RaiseAndSetIfChanged(ref loginuse, value);
		}

		public string ShowLogin { get => result; set => this.RaiseAndSetIfChanged(ref result, value); }

		private string? result;

		public void Press()
		{
			if (loginuse == null)
			{
				ShowLogin = "Вы ничего не ввели";
			}
			else if (loginuse == "проверка")
			{
				ShowLogin = "Вы ввели логин";
			}

		}
		}
	#pragma warning restore CA1822 // Mark members as static
}
