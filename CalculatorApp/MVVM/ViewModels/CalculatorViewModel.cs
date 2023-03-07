using System.Windows.Input;
using Dangl.Calculator;
using PropertyChanged;

namespace CalculatorApp.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class CalculatorViewModel
{
	public string Formula { get; set; }

	public string Result { get; set; } = "0";

	public ICommand OperationCommand
			=> new Command((number) => { Formula += number; });

	public ICommand ResetCommand
			=> new Command(() =>
			{
				Result = "0";
				Formula = string.Empty;
			});

	public ICommand BackspaceCommand
			=> new Command(() =>
			{

				if (Result.Length > 0)
				{
					Formula = Formula[..^1];
				}
			});

	public ICommand CalculateCommand 
			=> new Command(() =>
			{
				if (Formula.Length == 0)
				{
					return;
				}

				Result = Calculator.Calculate(Formula).Result.ToString();
			});
}
