using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {

        [Test]
        public void Push_WhenObjectIsNull_ThrowArgumentNullException()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_WhenObjectIsNotNull_AddTheObjectToTheStack()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            stack.Push("a");
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithObjects_ReturnTheLastObjectAddedToTheStack()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            var result = stack.Pop();
            Assert.That(result, Is.EqualTo("b"));
        }


        [Test]
        public void Pop_StackWithObjects_RemoveTheLastObjectAddedToTheStack()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Pop();
            Assert.That(stack.Count, Is.EqualTo(1));
        }


        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ReturnTheLastObjectAddedToTheStack()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            var result = stack.Peek();
            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveTheLastObjectAddedToTheStack()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Peek();
            Assert.That(stack.Count, Is.EqualTo(2));

        }
    }
}
