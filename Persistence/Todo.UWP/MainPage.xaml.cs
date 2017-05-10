namespace CurrencyApp.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage 
    {
        public MainPage()
        {
            OxyPlot.Xamarin.Forms.Platform.UWP.PlotViewRenderer.Init();
            this.InitializeComponent();
            OxyPlot.Xamarin.Forms.Platform.UWP.PlotViewRenderer.Init();

            LoadApplication(new CurrencyApp.App());
            OxyPlot.Xamarin.Forms.Platform.UWP.PlotViewRenderer.Init();

        }
    }
}
