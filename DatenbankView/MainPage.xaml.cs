namespace DatenbankView
{
    public partial class MainPage : ContentPage
    {
        private DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            LoadData();
        }

        private void LoadData()
        {
            if (_databaseService.TestConnection())
            {
                StatusLabel.Text = "Mit der Datenbank verbunden";
                
                // Laden der Paletten
                List<Palette> paletten = _databaseService.GetPaletten();
                PalettenCollectionView.ItemsSource = paletten;

                // Laden der PKWs
                List<PKW> pkws = _databaseService.GetPKWs();
                PKWsCollectionView.ItemsSource = pkws;
            }
            else
            {
                StatusLabel.Text = "Keine Verbindung zur Datenbank";
            }
        }
    }
}