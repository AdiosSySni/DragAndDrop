using Microsoft.Maui.Controls;

namespace MauiApp5;

public partial class MainPage : ContentPage
{ 
	Dictionary<string, VerticalStackLayout> _data = new Dictionary<string, VerticalStackLayout>();
	public MainPage()
	{
		InitializeComponent();
		_data.Add("firstVSL", FirstVSL);
		_data.Add("secondVSL", SecondVSL);
		_data.Add("thirdVSL", ThirdVSL);

	}

	private void DragStarting(object sender, DragStartingEventArgs e)
	{
		var frame = (sender as DragGestureRecognizer).Parent as Frame;
		e.Data.Properties.Add("frame", frame);
		
      	
		//foreach(var item in _data)
		//{
		//	item.Value.Children.Remove(frame);
		//}

        //frame.Parent.Children
        //.Children.Remove(ChildDrag);
    }

    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {
        
        Frame data = e.Data.Properties["frame"] as Frame;
        (data.Parent as VerticalStackLayout).Children.Remove(data);
        ((sender as DropGestureRecognizer)?.Parent as VerticalStackLayout).Children.Add(data);
	}

}

