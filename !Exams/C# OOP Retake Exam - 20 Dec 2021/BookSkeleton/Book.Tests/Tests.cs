namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private string BookName = "HAH";
        private string Author = "Kalsito";
        private int footNoteNumber = 1;
        private string text = "HAHAHHA";
        private Book book;
           [SetUp]
           public void SetUp()
           {
               book = new Book(BookName, Author);
               book.AddFootnote(footNoteNumber, text);
           }
        [Test]
        public void Test_ConstructorSettingProperly()
        {
            Assert.True(book.BookName == BookName);
            Assert.True(book.Author == Author);
            Assert.True(book.FootnoteCount == footNoteNumber);
        }
        [TestCase(null)]
        [TestCase("")]
        public void PropBookName_ThrowException(string name)
        {
            Assert.Throws<ArgumentException>(() => book = new Book(name, Author));
        }
        [TestCase(null)]
        [TestCase("")]
        public void PropAuthor_ThrowException(string author)
        {
            Assert.Throws<ArgumentException>(() => book = new Book(BookName, author));
        }
        [Test]
        public void AddFootnote_ThrowsForExistingFootnoteNumber()
        {
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(footNoteNumber, "Token text"));
        }
        [Test]
        public void AddFootnote_Increse()
        {
            Assert.AreEqual(book.FootnoteCount, 1);
        }
        [Test]
        public void FindFootnote_ThrowsForNonExistingFootnote()
        {
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(123));
        }
        [Test]
        public void FindFootnote_ReturnsCorrectFootnote()
        {
            string expectedString = $"Footnote #{footNoteNumber}: {text}";
            string footnoteTextFound = book.FindFootnote(footNoteNumber);
            Assert.AreEqual(expectedString, footnoteTextFound);
        }
        [Test]
        public void AlterFootnote()
        {
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(123, text));
        }
        [Test]
        public void AlterFootnote_AsserIsSAME()
        {
            string testText = "asfgrefhe";
            string expectedText = $"Footnote #{footNoteNumber}: {testText}";
            book.AlterFootnote(footNoteNumber, testText);
            string resultText = book.FindFootnote(footNoteNumber);
            Assert.AreEqual(expectedText, resultText);
        }
    }
}