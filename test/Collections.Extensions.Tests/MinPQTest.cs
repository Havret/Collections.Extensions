using Havret.Collections.Extensions;
using Xunit;

namespace Collections.Extensions.Tests
{
    public class MinPQTest
    {
        [Fact]
        public void should_process_elements_in_ascending_order()
        {
            var minPQ = new MinPQ<int>();
            minPQ.Insert(1);
            minPQ.Insert(9);
            minPQ.Insert(2);
            minPQ.Insert(8);
            minPQ.Insert(3);
            minPQ.Insert(7);
            minPQ.Insert(4);
            minPQ.Insert(6);
            minPQ.Insert(5);
            minPQ.Insert(10);

            for (int i = 1; i < 11; i++)
            {   
                Assert.Equal(i, minPQ.Min);
                Assert.Equal(i, minPQ.DeleteMin());
            }
        }
    }
}