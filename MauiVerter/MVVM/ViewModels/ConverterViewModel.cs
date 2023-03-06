using System.Collections.ObjectModel;
using System.Windows.Input;
using PropertyChanged;
using UnitsNet;

namespace MauiVerter.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class ConverterViewModel
{
	public ConverterViewModel(string quantityName)
	{
		QuantityName = quantityName;
		FromMeasures = LoadMeasures();
		ToMeasures = LoadMeasures();
		CurrentFromMeasures = FromMeasures.FirstOrDefault();
		CurrentToMeasures = ToMeasures.Skip(1).FirstOrDefault();
		Convert();
	}

	public string QuantityName { get; set; }

	public ObservableCollection<string> FromMeasures { get; set; }

	public ObservableCollection<string> ToMeasures { get; set; }

	public string CurrentFromMeasures { get; set; }

	public string CurrentToMeasures { get; set; }

	public double FromValue { get; set; } = 1;

	public double ToValue { get; set; }

	public ICommand FinishTyping => new Command(Convert);

	public void Convert()
	{
		ToValue = UnitConverter.ConvertByName(FromValue, QuantityName, CurrentFromMeasures, CurrentToMeasures);
	}

	private ObservableCollection<string> LoadMeasures()
	{
		var types = Quantity.Infos
			.FirstOrDefault(x => x.Name == QuantityName)
			.UnitInfos
			.Select(x => x.Name)
			.ToList();

		return new ObservableCollection<string>(types);
	}
}
