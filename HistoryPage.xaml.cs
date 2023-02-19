namespace ChatFlow;

public partial class HistoryPage : ContentPage
{
    private static HistoryPage instance;
    private static HistoryCollection historyCollection;
    private HistoryPage()
    {
        historyCollection = new HistoryCollection();
        InitializeComponent();
    }
    private HistoryPage(Dictionary<string, string[]> data)
    {
        historyCollection = new HistoryCollection(data);
        InitializeComponent();
    }
    public static HistoryPage GetInstance(Dictionary<string,string[]> data = null)
    {
        if (instance == null && data == null)
        {
            instance = new HistoryPage();
        }
        else
        {
            instance = new HistoryPage(data);
        }
        return instance;
    }
}