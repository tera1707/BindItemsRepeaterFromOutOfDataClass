using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using MyWinUI3PackageProjectTemplate6.Converters;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyWinUI3PackageProjectTemplate6.View;

// データ用のクラス
public record MyData(int Data1, ToggleSwitch Toggle);

// ページのクラス
public sealed partial class MainPage : Page, INotifyPropertyChanged
{
    // この数字(MyStatus)とToggleSwitchごとに割り当てられた数字が一致したら、ToggleSwitchをONにする
    public int MyStatus { get; set; } = 0;
    // ItemsRepeaterに表示するためのデータ
    public ObservableCollection<MyData> MyDatas = new ObservableCollection<MyData>();

    public MainPage()
    {
        this.InitializeComponent();

        // データをいくつか作成
        MyDatas.Add(new MyData(0, CreateMyToggleSwitch(this, nameof(MyStatus), 0)));
        MyDatas.Add(new MyData(1, CreateMyToggleSwitch(this, nameof(MyStatus), 1)));
        MyDatas.Add(new MyData(2, CreateMyToggleSwitch(this, nameof(MyStatus), 2)));
        MyDatas.Add(new MyData(3, CreateMyToggleSwitch(this, nameof(MyStatus), 3)));
        MyDatas.Add(new MyData(4, CreateMyToggleSwitch(this, nameof(MyStatus), 4)));
    }

    // バインディングの設定が出来たToggleSwitchを作成するためのメソッド
    private static ToggleSwitch CreateMyToggleSwitch(object src, string PropertyName, int targetStatus)
    {
        var ts = new ToggleSwitch();
        Binding myBinding1 = new Binding();
        myBinding1.Path = new PropertyPath(nameof(MyStatus));
        myBinding1.Source = src;
        myBinding1.Mode = BindingMode.OneWay;
        myBinding1.Converter = new InvertBooleanConverter();
        myBinding1.ConverterParameter = targetStatus;
        ts.SetBinding(ToggleSwitch.IsOnProperty, myBinding1);
        return ts;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MyStatus = MyStatus < MyDatas.Count - 1 ? MyStatus + 1 : 0;//最大数を超えたら0に戻す
        OnPropertyChanged(nameof(MyStatus));
    }

    // IPropertyChangedお決まり部分
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
