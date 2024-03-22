using FluentAssertions;
using DataStructures;
using NUnit.Framework;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
    /// 
    /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    /// </summary>
    class AddTwoNumbersWithLinkedList
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            bool carry = false;

            ListNode answer = null;
            ListNode tail = null;

            while (l1 != null || l2 != null || carry)
            {
                int currDigit = 0;
                int addOne = 0;
                int addTwo = 0;
                if (l1 != null)
                {
                    addOne = l1.val;
                }

                if (l2 != null)
                {
                    addTwo = l2.val;
                }

                if (carry && l1 == null && l2 == null)
                {
                    tail.next = new ListNode(1);
                    return answer;
                }

                if (carry)
                {
                    currDigit = addOne + addTwo + 1;
                }
                else
                {
                    currDigit = addOne + addTwo;
                }

                if (currDigit >= 10)
                {
                    carry = true;
                    currDigit = currDigit % 10;
                }
                else
                {
                    carry = false;
                }


                if (answer == null)
                {
                    answer = new ListNode(currDigit);
                    tail = answer;
                }
                else
                {
                    tail.next = new ListNode(currDigit);
                    tail = tail.next;
                }

                if (l1 != null && l1.next != null)
                {
                    l1 = l1.next;
                }
                else
                {
                    l1 = null;
                }

                if (l2 != null && l2.next != null)
                {
                    l2 = l2.next;
                }
                else
                {
                    l2 = null;
                }

            }

            return answer;
        }
    }

    [TestFixture]
    class AddTwoNumbersWithLinkedListTests
    {
        AddTwoNumbersWithLinkedList _practice = new AddTwoNumbersWithLinkedList();

        [Test]
        public void LongestSubstring_WithValidLists_ShouldReturnExpected()
        {
            //Arrange
            ListNode node2 = new ListNode(2);
            ListNode node4 = new ListNode(4);
            ListNode node3 = new ListNode(3);
            node2.next = node4;
            node4.next = node3;
            ListNode list1 = node2;

            ListNode node5 = new ListNode(5);
            ListNode node6 = new ListNode(6);
            ListNode node4a = new ListNode(4);
            node5.next = node6;
            node6.next = node4a;
            ListNode list2 = node5;

            ListNode node7 = new ListNode(7);
            ListNode node0 = new ListNode(0);
            ListNode node8 = new ListNode(8);
            node7.next = node0;
            node0.next = node8;
            ListNode expected = node7;

            //Act
            ListNode result = _practice.AddTwoNumbers(list1, list2);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
