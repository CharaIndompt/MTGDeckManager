using MTGDeckManager.Model.Cards;
using MTGDeckManager.Model.Decks;
using MTGDeckManager.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTGDeckManager.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IDataAccess _dataAccess;
        
        private ObservableCollection<Card> cards;
        private ObservableCollection<Deck> decks;
        private Card selectedCard;
        private Deck selectedDeck;

        public MainPageViewModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            Cards = new ObservableCollection<Card>();
            Decks = new ObservableCollection<Deck>();
            
            LoadCardsCommand = new Command(LoadCards);
            LoadDecksCommand = new Command(LoadDecks);
            TestClassesCommand = new Command(TestClasses);
        }

        public ObservableCollection<Card> Cards
        {
            get => cards;
            set => SetProperty(ref cards, value);
        }

        public ObservableCollection<Deck> Decks
        {
            get => decks;
            set => SetProperty(ref decks, value);
        }

        public Card SelectedCard
        {
            get => selectedCard;
            set => SetProperty(ref selectedCard, value);
        }

        public Deck SelectedDeck
        {
            get => selectedDeck;
            set => SetProperty(ref selectedDeck, value);
        }

        public ICommand LoadCardsCommand { get; }
        public ICommand LoadDecksCommand { get; }
        public ICommand TestClassesCommand { get; }

        private void LoadCards()
        {
            var allCards = _dataAccess.GetAllCards();
            if (allCards != null)
            {
                Cards.Clear();
                foreach (var card in allCards)
                {
                    Cards.Add(card);
                }
            }
        }

        private void LoadDecks()
        {
            var allDecks = _dataAccess.GetAllDecks();
            if (allDecks != null)
            {
                Decks.Clear();
                foreach (var deck in allDecks)
                {
                    Decks.Add(deck);
                }
            }
        }

        private void TestClasses()
        {
            // Test instantiation of each class with test data
            var creature = new CreatureCard(100, "Test Elf", "A test elf creature for validation", "{G}", "Common", 2, 2, "Elf");
            var land = new LandCard(101, "Test Forest", "A test forest land", "", "Common", "Forest", true);
            var deck = new Deck(1, "Test Deck", "Commander");
            
            deck.AddCard(creature);
            deck.AddCard(land);
            
            Console.WriteLine($"Creature: {creature.AutoDescription()}");
            Console.WriteLine($"Land: {land.AutoDescription()}");
            Console.WriteLine($"Deck has {deck.Cards.Count} cards");
        }
    }
}
