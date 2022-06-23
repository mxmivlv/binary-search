using NUnit.Framework;

namespace Module_2.Tests
{
    [TestFixture]
    public class SortingTest
    {
        private Sorting sorting;

        [SetUp]
        public void BinarySearchTestSetUp()
        {
            sorting = new Sorting();
        }

        #region Task 1
        private static readonly object[] ArrayForTask1 = new object[]
        {
             new char[][] 
             { 
                 new char[] {'a','q','w','e' },
                 new char[] {'a','q','w','e' },
                 new char[] {'q','w','e','a' },
                 new char[] {'r','t','v' },
                 new char[] {'r','t','v' },
                 new char[] {'f','f','f' },
                 new char[] {'f','f','e' }
             }
        };
        [Test(Description = "Сортировка массива таким образом, чтоб не было повторений слов")]
        [TestCaseSource(nameof(ArrayForTask1))]
        public void SortingCollectionWordsTest(char[][] collectionWords) 
        {
            var actual = sorting.SortingCollectionWords(collectionWords);
            char[][] expected = new char[][]
            {
                new[] { 'a','q','w','e' },
                new[] { 'q','w','e','a' },
                new[] { 'w','e','a','q' },
                new[] { 'r','t','v' },
                new[] { 't','v','r' },
                new[] { 'f','f','f' },
                new[] { 'f','f','e' }
            };
            Assert.That(actual.Length, Is.EqualTo(expected.Length));

            for (int i = 0; i < expected.Length; i++)
            {
                for (int j = 0; j < expected[i].Length; j++)
                {
                    Assert.That(actual[i][j], Is.EqualTo(expected[i][j]));
                }
            }
        }
        #endregion
    }
}
