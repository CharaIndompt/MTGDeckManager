using MTGDeckManager.Model.Cards;
using MTGDeckManager.Model.Decks;
using MTGDeckManager.Utilities.DataAccess;
using MTGDeckManager.Utilities.DataAccess.Files;
using MTGDeckManager.ViewModel;
using System.Collections.ObjectModel;

namespace MTGDeckManager.View
{
    public partial class MainPage : ContentPage
    {
        private const string CONFIG_CSV = "/workspace/MTGDeckManager/Configuration/Datas/Config.txt";
        private const string CONFIG_JSON = "/workspace/MTGDeckManager/Configuration/Datas/ConfigJson.txt";

        public MainPage(MainPageViewModel mainPageVM)
        {
            BindingContext = mainPageVM;
            InitializeComponent();
        }

        /// <summary>
        /// Test button for Checkpoint 1: Instantiate objects of EACH class with test data
        /// </summary>
        private void buttonTestClasses_Clicked(object sender, EventArgs e)
        {
            // Instantiate CreatureCard with test data
            var creature = new CreatureCard(
                id: 100,
                name: "Test Elf Warrior",
                description: "A test elf creature for validation purposes",
                manaCost: "{1}{G}",
                rarity: "Common",
                power: 2,
                toughness: 2,
                creatureType: "Elf Warrior"
            );

            // Instantiate LandCard with test data
            var land = new LandCard(
                id: 101,
                name: "Test Forest",
                description: "A basic forest land for testing",
                manaCost: "",
                rarity: "Common",
                landType: "Forest",
                canTapForMana: true
            );

            // Instantiate Deck with test data
            var deck = new Deck(
                id: 1,
                name: "Test Commander Deck",
                format: "Commander"
            );

            // Add cards to deck
            deck.AddCard(creature);
            deck.AddCard(land);

            // Display results
            lblDebug.Text = $"=== Test Class Instantiation ===\n\n" +
                           $"Creature: {creature.AutoDescription()}\n" +
                           $"Creature Check: {creature.Check()}\n\n" +
                           $"Land: {land.AutoDescription()}\n" +
                           $"Land Check: {land.Check()}\n\n" +
                           $"Deck: {deck.Name} ({deck.Format})\n" +
                           $"Deck has {deck.Cards.Count} cards\n" +
                           $"Deck Check: {deck.Check()} (needs 60+ cards)\n\n" +
                           $"All classes instantiated successfully!";
        }

        /// <summary>
        /// Test button for CSV: Load external data from CSV files into collections
        /// </summary>
        private async void buttonTestCsv_Clicked(object sender, EventArgs e)
        {
            try
            {
                lblDebug.Text = "Loading CSV data...";

                // Create DataFilesManager with CSV config
                var dfm = new DataFilesManager(CONFIG_CSV);

                // Create DataAccessCsvFile
                var dataAccessCsv = new DataAccessCsvFile(dfm);

                // Load creatures from CSV
                var creatures = dataAccessCsv.GetAllCreatureCards();
                if (creatures != null)
                {
                    cardsCollection.ItemsSource = creatures;
                    lblDebug.Text = $"CSV Load Success!\n\nCreatures loaded: {creatures.Count}\n\n" +
                                   $"First creature: {creatures[0].Name}\n" +
                                   $"Last creature: {creatures[creatures.Count - 1].Name}";
                }
                else
                {
                    lblDebug.Text = "Error: Could not load creatures from CSV";
                }

                // Load lands from CSV
                var lands = dataAccessCsv.GetAllLandCards();
                if (lands != null)
                {
                    lblDebug.Text += $"\n\nLands loaded: {lands.Count}";
                }

                // Load decks from CSV
                var decks = dataAccessCsv.GetAllDecks();
                if (decks != null)
                {
                    decksCollection.ItemsSource = decks;
                    lblDebug.Text += $"\nDecks loaded: {decks.Count}";
                }
            }
            catch (Exception ex)
            {
                lblDebug.Text = $"CSV Load Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Test button for JSON: Load external data from JSON files into collections
        /// </summary>
        private async void buttonTestJson_Clicked(object sender, EventArgs e)
        {
            try
            {
                lblDebug.Text = "Loading JSON data...";

                // Create DataFilesManager with JSON config
                var dfm = new DataFilesManager(CONFIG_JSON);

                // Create DataAccessJsonFile
                var dataAccessJson = new DataAccessJsonFile(dfm);

                // Load creatures from JSON
                var creatures = dataAccessJson.GetAllCreatureCards();
                if (creatures != null)
                {
                    cardsCollection.ItemsSource = creatures;
                    lblDebug.Text = $"JSON Load Success!\n\nCreatures loaded: {creatures.Count}\n\n" +
                                   $"First creature: {creatures[0].Name}\n" +
                                   $"Last creature: {creatures[creatures.Count - 1].Name}";
                }
                else
                {
                    lblDebug.Text = "Error: Could not load creatures from JSON";
                }

                // Load lands from JSON
                var lands = dataAccessJson.GetAllLandCards();
                if (lands != null)
                {
                    lblDebug.Text += $"\n\nLands loaded: {lands.Count}";
                }

                // Load decks from JSON
                var decks = dataAccessJson.GetAllDecks();
                if (decks != null)
                {
                    decksCollection.ItemsSource = decks;
                    lblDebug.Text += $"\nDecks loaded: {decks.Count}";
                }
            }
            catch (Exception ex)
            {
                lblDebug.Text = $"JSON Load Error: {ex.Message}";
            }
        }
    }
}
