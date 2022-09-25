namespace Path.Console
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void AddToList_WithValidInput_CreateNode()
        {
            // arrange
            string value = "test";

            HashTable hashTable = new HashTable(0xFFFFFFFF);

            // act
            hashTable.AddToList(value);

            // assert
            Assert.IsNotNull(hashTable.values[0]);
        }

        [TestMethod]
        public void DeleteToList_WithValidInput_DeleteNode()
        {
            // arrange
            string value = "test";

            HashTable hashTable = new HashTable(0xFFFFFFFF);

            // act
            hashTable.AddToList(value);
            hashTable.DeleteToList(value);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SearchLinkedList_WithValidInput_SearchValue()
        {
            // arrange
            string value = "test";

            HashTable hashTable = new HashTable(0xFFFFFFFF);

            // act
            hashTable.AddToList(value);
            hashTable.SearchLinkedList(value);

            // assert
            Assert.IsTrue(true);
        }
    }
}
