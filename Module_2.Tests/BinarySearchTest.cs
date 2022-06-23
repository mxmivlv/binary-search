using NUnit.Framework;
using System.Collections.Generic;

namespace Module_2.Tests
{
    [TestFixture]
    public class BinarySearchTest
    {
        private BinarySearch binarySearch;

        [SetUp]
        public void BinarySearchTestSetUp() 
        {
            binarySearch = new BinarySearch();
        }

        #region Task 1
        private static readonly object[] ArrayForTask1 = new object[]
        {
            new object [] 
            { 
                new string[] 
                { 
                    "Азербайджанский", 
                    "Албанский", 
                    "Английский", 
                    "Венгерский", 
                    "Гавайский",        
                    "Греческий",
                    "Польский",
                    "Русский",
                    "Французский",
                    "Фризский" 
                },
                "Русский" 
            }
        };
        [Test(Description = "Поиск в массиве")]
        [TestCaseSource(nameof(ArrayForTask1))]
        public void SearchInTheCollectionLanguageTest(string[] collectionLanguages, string language)
        {
            var actual = binarySearch.SearchInTheCollectionLanguage(collectionLanguages, language);
            var expected = true;
            Assert.That(actual, Is.EqualTo(expected));
        }
        #endregion

        #region Task 2
        private static readonly object[] ArrayForTask2 = new object[]
        {
            new object [] 
            { 
                new DatingUser[] 
                {  
                    new DatingUser(100,"Имя100"), 
                    new DatingUser(150,"Имя150"), 
                    new DatingUser(150,"Имя150-2"),               
                    new DatingUser(200,"Имя200"), 
                    new DatingUser(300,"Имя300"),
                    new DatingUser(300,"Имя300-2") 
                }, 
                150, 250 
            }
        };
        [Test(Description = "Поиск в массиве, в заданном диапазоне")]
        [TestCaseSource(nameof(ArrayForTask2))]
        public void FindUsersTest(DatingUser[] collectionUsers, int lowerIqBound, int upperIqBound)
        {
            var actual = binarySearch.FindUsers(collectionUsers, lowerIqBound, upperIqBound);
            List<DatingUser> expected = new List<DatingUser>()
            {
                new DatingUser(150,"Имя150"),
                new DatingUser(150,"Имя150-2"),
                new DatingUser(200,"Имя200")
            };
            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i], Is.EqualTo(expected[i].Name));
            }
        }
        #endregion

        #region Task 3
        private static readonly object[] ArrayForTask3 = new object[]
        {
            new object [] 
            { 
                new long[] 
                { 
                    +79300000000, 
                    +79290000000, 
                    +79280000000, 
                    +79270000000, 
                    +79260000000, 
                    +79250000000 
                }, 
                +79300000001 
            }
        };

        [Test(Description = "Нахождение переменной в массиве, который может быть отсортирован в двух направлениях")]
        [TestCaseSource(nameof(ArrayForTask3))]
        public void FindPhoneNumberTest(long[] collectionPhoneNumbers, long phoneNumber)
        {
            var actual = binarySearch.FindPhoneNumber(collectionPhoneNumbers, phoneNumber);
            var expected = -1;
            Assert.That(actual, Is.EqualTo(expected));
        }
        #endregion

        #region Task 4
        private static readonly object[] ArrayForTask4 = new object[]
        {
            new object [] 
            { 
                new List<string> 
                { 
                    "Азбука", 
                    "Алфавит", 
                    "Буквы", 
                    "Город", 
                    "Мир", 
                    "Слова" 
                }, 
                "Вставка" 
            }
        };
        [Test(Description = "Вставка новых слов в словарь")]
        [TestCaseSource(nameof(ArrayForTask4))]
        public void InsertNewWordTest(List<string> collectionWord, string word)
        {
            var actual = binarySearch.InsertNewWord(collectionWord, word);
            List<string> expected = new List<string>() 
            {
                "Азбука", 
                "Алфавит", 
                "Буквы",
                "Вставка", //Вставляемое слово
                "Город", 
                "Мир", 
                "Слова",
            };
            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(actual[i], Is.EqualTo(expected[i]));
            }
        }
        #endregion

        #region Task 5
        private static readonly object[] ArrayForTask5 = new object[]
        {
             new object [] 
             { 
                 new List<Player> 
                 { 
                     new Player(100,"Iq-100"), 
                     new Player(200, "Iq-200"), 
                     new Player(200, "Iq-200"),                         
                     new Player(300, "Iq-300"), 
                     new Player(300, "Iq-300"), 
                     new Player(400,"Iq-400"), 
                     new Player(500,"Iq-500") 
                 }, 
                 300 
             }
        };

        [Test(Description = "Поиск в коллекции экземпляра с заданным рейтингом")]
        [TestCaseSource(nameof(ArrayForTask5))]
        public void SearchPlayerTest(List<Player> collectionPlayers, int ratingPlayer)
        {
            var actual = binarySearch.SearchPlayer(collectionPlayers, ratingPlayer);
            var expected = 4;
            Assert.That(actual, Is.EqualTo(expected));
        }
        #endregion

        #region Task 6
        private static readonly object[] ArrayForTask6 = new object[]
        {
            new object [] 
            {
                new List<Player> 
                { 
                    new Player(100,"Iq-100"), 
                    new Player(200, "Iq-200"), 
                    new Player(200, "Iq-200"),           
                    new Player(300, "Iq-300"), 
                    new Player(300, "Iq-300"), 
                    new Player(400,"Iq-400"),     
                    new Player(500,"Iq-500") 
                }, 
                1, new Player(150, "Iq-150") 
            }
        };
        [Test(Description = "Добавление клиента в заданный индекс")]
        [TestCaseSource(nameof(ArrayForTask6))]
        public void InsertPlayerInCollectionPlayer(List<Player> collectionPlayer, int indexToInsert, Player newPlayer)
        {
            var actual = binarySearch.InsertPlayerInCollectionPlayer(collectionPlayer, indexToInsert, newPlayer);
            List<Player> expected = new List<Player>()
            {
                new Player(100,"Iq-100"),
                new Player(150, "Iq-150"), //Add Player
                new Player(200, "Iq-200"), 
                new Player(200, "Iq-200"),                    
                new Player(300, "Iq-300"), 
                new Player(300, "Iq-300"), 
                new Player(400,"Iq-400"),                         
                new Player(500,"Iq-500"),
                
            };
            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.That(actual[i].Rating, Is.EqualTo(expected[i].Rating));
            }
        }
        #endregion
    }
}
