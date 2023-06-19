using Lab03;


namespace TestLab03
{
    public class UnitTest1
    {
        //Test find product method

        [Theory]
        [InlineData("1 2 3",6)]
        [InlineData("1 2", 0)]
        [InlineData("1 2 3 4", 6)]
        [InlineData("-1 2 3", -6)]

        public void TestFindproduct(string numbers,int expected)
        {
           
            TextReader originalInput = Console.In;

                using (StringReader stringReader = new StringReader(numbers))
                {
                    
                    Console.SetIn(stringReader);
                    int actualLength = Program.FindProduct();
                    Assert.Equal(expected, actualLength);
                }
           
                Console.SetIn(originalInput);
            
        }


        

        //Test the most repeted number method
        [Theory]
        [InlineData(new[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 }, 1)]
        [InlineData(new[] { 1, 1, 1, 1, 1 }, 1)]
        [InlineData(new[] { 1, 2, 3, 4 }, 1)]
        [InlineData(new[] { 1,1,1,2,2,2,3,3,3,4,5}, 1)]
        public void MostRepetedNumberTesting(int[] array, int expected)
        {
            // Act
            int actual = Program.MostRepetedNumber(array);

            // Assert
            Assert.Equal(expected, actual);
        }

        //Test the max number method
        [Theory]
        [InlineData(new[] {-1,-2,-3,-5,-6},-1)]
        [InlineData(new[] {1,1,1,1,1,1,1}, 1)]

        public void MaxNumberTesting(int[] array,int expected)
        {
            int actual=Program.MaxNumber(array);

            Assert.Equal(expected, actual);
        }

        //Test number of characters
        [Theory]
        [InlineData("Hello rama", new[] { "Hello: 5", "rama: 4" })]
        [InlineData("How are you ?", new[] { "How: 3", "are: 3","you: 3","?: 1" })]
        [InlineData("Are Youuuuu happy now? Take 100$$", new[] { "Are: 3", "Youuuuu: 7", "happy: 5", "now?: 4","Take: 4","100$$: 5" })]



        public void TestNumberOfChars(string text, string[] expected)
        {

            TextReader originalInput = Console.In;

            using (StringReader stringReader = new StringReader(text))
            {

                Console.SetIn(stringReader);
                string [] actual = Program.NumberofChars();
                Assert.Equal(expected, actual);
            }

            Console.SetIn(originalInput);

        }

    }
}